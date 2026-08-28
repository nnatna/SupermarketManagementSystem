IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'SupermarketManagement')
BEGIN
    CREATE DATABASE SupermarketManagement;
END
GO

ALTER DATABASE SupermarketManagement SET COMPATIBILITY_LEVEL = 130;
GO

USE SupermarketManagement;
GO

/* =====================================================
   1. ROLES
   ===================================================== */
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'roles')
BEGIN
    CREATE TABLE roles (
        id INT IDENTITY(1,1) PRIMARY KEY,
        name VARCHAR(50) NOT NULL UNIQUE,
        description VARCHAR(MAX),
        created_at DATETIME NOT NULL DEFAULT GETDATE()
    );
END
GO


/* =====================================================
   2. EMPLOYEES
   ===================================================== */
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'employees')
BEGIN
    CREATE TABLE employees (
        id BIGINT IDENTITY(1,1) PRIMARY KEY,
        fullname NVARCHAR(500) NULL,
        gender VARCHAR(10),
        phone VARCHAR(20),
        email VARCHAR(100),
        position VARCHAR(50),
        salary DECIMAL(10,2),
        hire_date DATE,
        photo_path NVARCHAR(500) NULL,
        created_at DATETIME NOT NULL DEFAULT GETDATE()
    );
END
GO


/* =====================================================
   3. USERS
   ===================================================== */
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'users')
BEGIN
    CREATE TABLE users (
        id BIGINT IDENTITY(1,1) PRIMARY KEY,
        employee_id BIGINT NULL,
        role_id INT NOT NULL,
        username VARCHAR(50) NOT NULL UNIQUE,
        password VARCHAR(255) NOT NULL,
        status VARCHAR(10) NOT NULL DEFAULT 'active',

        created_at DATETIME NOT NULL DEFAULT GETDATE(),

        CONSTRAINT FK_users_employees
            FOREIGN KEY (employee_id)
            REFERENCES employees(id),

        CONSTRAINT FK_users_roles
            FOREIGN KEY (role_id)
            REFERENCES roles(id),

        CONSTRAINT CK_users_status
            CHECK (status IN ('active', 'inactive'))
    );
END
GO


/* =====================================================
   4. STORE INFO
   ===================================================== */
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'store_info')
BEGIN
    CREATE TABLE store_info (
        id INT IDENTITY(1,1) PRIMARY KEY,
        store_name VARCHAR(100) NOT NULL,
        phone VARCHAR(20),
        email VARCHAR(100),
        address VARCHAR(MAX),
        logo VARCHAR(255),
        tax_number VARCHAR(50),
        currency VARCHAR(10) DEFAULT 'USD',
        updated_at DATETIME NOT NULL DEFAULT GETDATE()
    );
END
GO


/* =====================================================
   5. CUSTOMERS
   ===================================================== */
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'customers')
BEGIN
    CREATE TABLE customers (
        id BIGINT IDENTITY(1,1) PRIMARY KEY,
        name VARCHAR(100) NOT NULL,
        phone VARCHAR(20),
        email VARCHAR(100),
        address VARCHAR(MAX),
        points INT NOT NULL DEFAULT 0,
        created_at DATETIME NOT NULL DEFAULT GETDATE()
    );
END
GO


/* =====================================================
   6. SUPPLIERS
   ===================================================== */
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'suppliers')
BEGIN
    CREATE TABLE suppliers (
        id BIGINT IDENTITY(1,1) PRIMARY KEY,
        company_name VARCHAR(100) NOT NULL,
        contact_name VARCHAR(100),
        phone VARCHAR(20) NOT NULL,
        email VARCHAR(100),
        address VARCHAR(MAX),
        created_at DATETIME NOT NULL DEFAULT GETDATE()
    );
END
GO


/* =====================================================
   7. CATEGORIES
   ===================================================== */
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'categories')
BEGIN
    CREATE TABLE categories (
        id INT IDENTITY(1,1) PRIMARY KEY,
        name VARCHAR(50) NOT NULL UNIQUE,
        description VARCHAR(MAX),
        created_at DATETIME NOT NULL DEFAULT GETDATE()
    );
END
GO


/* =====================================================
   8. UNITS
   ===================================================== */
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'units')
BEGIN
    CREATE TABLE units (
        id INT IDENTITY(1,1) PRIMARY KEY,
        name VARCHAR(50) NOT NULL,
        short_name VARCHAR(10)
    );
END
GO


/* =====================================================
   9. PRODUCTS
   ===================================================== */
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'products')
BEGIN
    CREATE TABLE products (
        id BIGINT IDENTITY(1,1) PRIMARY KEY,
        barcode VARCHAR(50) UNIQUE NULL,
        name VARCHAR(150) NOT NULL,
        category_id INT NOT NULL,
        unit_id INT NOT NULL,
        cost_price DECIMAL(10,2),
        selling_price DECIMAL(10,2),
        stock_quantity INT NOT NULL DEFAULT 0,
        stock_alert_level INT NOT NULL DEFAULT 5,
        discount_percent DECIMAL(5, 2) NOT NULL DEFAULT 0.00
            CONSTRAINT CK_Products_DiscountPercent CHECK (discount_percent >= 0 AND discount_percent <= 100),
        image VARCHAR(255),
        created_at DATETIME NOT NULL DEFAULT GETDATE(),
        supplier_id BIGINT NULL,

        CONSTRAINT FK_products_categories
            FOREIGN KEY (category_id)
            REFERENCES categories(id),

        CONSTRAINT FK_products_units
            FOREIGN KEY (unit_id)
            REFERENCES units(id),

        CONSTRAINT FK_Products_Suppliers 
            FOREIGN KEY (supplier_id) 
            REFERENCES suppliers(id)
    );
END
-- Ensure discount_percent column exists in products for existing databases
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('products') AND name = 'discount_percent')
BEGIN
    ALTER TABLE products
    ADD discount_percent DECIMAL(5, 2) NOT NULL DEFAULT 0.00
        CONSTRAINT CK_Products_DiscountPercent CHECK (discount_percent >= 0 AND discount_percent <= 100);
END
GO

/* =====================================================
   10. PROMOTIONS
   ===================================================== */
-- If promotions table exists with old schema (missing product_id), recreate it safely
IF EXISTS (SELECT * FROM sys.tables WHERE name = 'promotions') 
   AND NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('promotions') AND name = 'product_id')
BEGIN
    IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_sales_promotions')
    BEGIN
        ALTER TABLE sales DROP CONSTRAINT FK_sales_promotions;
    END

    DROP TABLE promotions;
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'promotions')
BEGIN
    CREATE TABLE promotions (
        id BIGINT IDENTITY(1,1) PRIMARY KEY,
        product_id BIGINT NOT NULL,
        promotion_name NVARCHAR(150) NOT NULL,
        discount_percent DECIMAL(5,2) NOT NULL DEFAULT 0.00,
        start_date DATETIME NOT NULL,
        end_date DATETIME NOT NULL,
        created_at DATETIME NOT NULL DEFAULT GETDATE(),

        CONSTRAINT FK_promotions_products 
            FOREIGN KEY (product_id) 
            REFERENCES products(id) 
            ON DELETE CASCADE,

        CONSTRAINT CK_promotions_discount_percent 
            CHECK (discount_percent >= 0.00 AND discount_percent <= 100.00)
    );
END
GO

-- Reconnect foreign key from sales to promotions if missing
IF EXISTS (SELECT * FROM sys.tables WHERE name = 'sales') 
   AND EXISTS (SELECT * FROM sys.tables WHERE name = 'promotions')
   AND NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_sales_promotions')
BEGIN
    ALTER TABLE sales
        ADD CONSTRAINT FK_sales_promotions 
        FOREIGN KEY (promotion_id) 
        REFERENCES promotions(id) 
        ON DELETE SET NULL;
END
GO

-- Seed sample promotions if empty and products exist
IF NOT EXISTS (SELECT 1 FROM promotions) AND EXISTS (SELECT 1 FROM products)
BEGIN
    INSERT INTO promotions (product_id, promotion_name, discount_percent, start_date, end_date)
    SELECT TOP 1 
        id, 
        N'Weekly Special Discount', 
        10.00, 
        DATEADD(DAY, -5, GETDATE()), 
        DATEADD(DAY, 25, GETDATE())
    FROM products 
    ORDER BY id ASC;

    INSERT INTO promotions (product_id, promotion_name, discount_percent, start_date, end_date)
    SELECT TOP 1 
        id, 
        N'Flash Clearance 20% OFF', 
        20.00, 
        DATEADD(DAY, -10, GETDATE()), 
        DATEADD(DAY, 15, GETDATE())
    FROM products 
    ORDER BY id DESC;
END
GO


/* =====================================================
   11. PURCHASES
   ===================================================== */
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'purchases')
BEGIN
    CREATE TABLE purchases (
        id BIGINT IDENTITY(1,1) PRIMARY KEY,
        purchase_number VARCHAR(50) NOT NULL UNIQUE,
        supplier_id BIGINT NOT NULL,
        user_id BIGINT NOT NULL,
        total_amount DECIMAL(10,2),
        status VARCHAR(10) NOT NULL DEFAULT 'received',
        purchase_date DATETIME NOT NULL,

        CONSTRAINT FK_purchases_suppliers
            FOREIGN KEY (supplier_id)
            REFERENCES suppliers(id),

        CONSTRAINT FK_purchases_users
            FOREIGN KEY (user_id)
            REFERENCES users(id),

        CONSTRAINT CK_purchases_status
            CHECK (status IN ('pending', 'received', 'canceled'))
    );
END
GO


/* =====================================================
   12. PURCHASE DETAILS
   ===================================================== */
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'purchase_details')
BEGIN
    CREATE TABLE purchase_details (
        id BIGINT IDENTITY(1,1) PRIMARY KEY,
        purchase_id BIGINT NOT NULL,
        product_id BIGINT NOT NULL,
        quantity INT NOT NULL,
        unit_cost DECIMAL(10,2) NOT NULL,
        subtotal DECIMAL(10,2) NOT NULL,

        CONSTRAINT FK_purchase_details_purchases
            FOREIGN KEY (purchase_id)
            REFERENCES purchases(id),

        CONSTRAINT FK_purchase_details_products
            FOREIGN KEY (product_id)
            REFERENCES products(id)
    );
END
GO


/* =====================================================
   13. SALES
   ===================================================== */
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'sales')
BEGIN
    CREATE TABLE sales (
        id BIGINT IDENTITY(1,1) PRIMARY KEY,
        customer_id BIGINT NULL,
        user_id BIGINT NOT NULL,
        promotion_id BIGINT NULL,
        subtotal DECIMAL(10,2),
        discount_amount DECIMAL(10,2),
        grand_total DECIMAL(10,2),
        payment_method VARCHAR(20) NOT NULL,
        sale_date DATETIME NOT NULL DEFAULT GETDATE(),
        status VARCHAR(20) DEFAULT 'Completed',

        CONSTRAINT FK_sales_customers
            FOREIGN KEY (customer_id)
            REFERENCES customers(id),

        CONSTRAINT FK_sales_users
            FOREIGN KEY (user_id)
            REFERENCES users(id),

        CONSTRAINT FK_sales_promotions
            FOREIGN KEY (promotion_id)
            REFERENCES promotions(id),

        CONSTRAINT CK_sales_payment_method
            CHECK (payment_method IN ('Cash', 'Credit Card', 'KHQR'))
    );
END
GO


/* =====================================================
   14. SALE DETAILS
   ===================================================== */
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'sale_details')
BEGIN
    CREATE TABLE sale_details (
        id BIGINT IDENTITY(1,1) PRIMARY KEY,
        invoice_number VARCHAR(50) NOT NULL UNIQUE,
        
        sale_id BIGINT NOT NULL,
        product_id BIGINT NOT NULL,
        quantity INT NOT NULL,
        unit_price DECIMAL(10,2) NOT NULL,
        subtotal DECIMAL(10,2) NOT NULL,
        status VARCHAR(50) NOT NULL DEFAULT 'Completed',

        CONSTRAINT FK_sale_details_sales
            FOREIGN KEY (sale_id)
            REFERENCES sales(id),

        CONSTRAINT FK_sale_details_products
            FOREIGN KEY (product_id)
            REFERENCES products(id)
    );
END
GO
/* =====================================================
   15. STOCK ADJUSTMENTS
   ===================================================== */
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'stock_adjustments')
BEGIN
    CREATE TABLE stock_adjustments (
        id BIGINT IDENTITY(1,1) PRIMARY KEY,
        product_id BIGINT NOT NULL,
        user_id BIGINT NOT NULL,
        type VARCHAR(20) NOT NULL,
        quantity INT NOT NULL,
        reason VARCHAR(255),
        adjusted_at DATETIME NOT NULL DEFAULT GETDATE(),
        status VARCHAR(20) DEFAULT 'Pending',

        CONSTRAINT FK_stock_adjustments_products
            FOREIGN KEY (product_id)
            REFERENCES products(id),

        CONSTRAINT FK_stock_adjustments_users
            FOREIGN KEY (user_id)
            REFERENCES users(id),

        CONSTRAINT CK_stock_adjustments_type
            CHECK (type IN ('addition', 'subtraction'))
    );
END
GO

/* =====================================================
   16. VIEWS PRODUCTS
   ===================================================== */
CREATE OR ALTER VIEW vw_Products AS
SELECT 
    p.id AS ProductId,
    p.barcode AS Barcode,
    p.name AS Name,
    p.category_id AS CategoryId,
    c.name AS CategoryName,
    p.unit_id AS UnitId,
    u.name AS UnitName,
    p.cost_price AS Cost_price,
    p.selling_price AS Selling_price,
    p.stock_quantity AS Stock_quantity,
    p.stock_alert_level AS Stock_alert_level,
    p.image AS Image
FROM products p
LEFT JOIN categories c ON p.category_id = c.id
LEFT JOIN units u ON p.unit_id = u.id;
GO

/* =====================================================
   17. VIEW SALE HISTORY
   ===================================================== */
CREATE OR ALTER VIEW vw_SaleHistory AS
SELECT 
    sd.id AS SaleHistoryID,
    sd.sale_id,
    sd.invoice_number,
    c.name AS customer_name,
    s.customer_id,
    s.sale_date,
    sd.product_id,
    p.name AS product_name,
    sd.quantity,
    CAST(CASE 
        WHEN (sd.unit_price * sd.quantity) > sd.subtotal 
        THEN (sd.unit_price * sd.quantity) - sd.subtotal 
        ELSE 0.00 
    END AS DECIMAL(10,2)) AS discount_amount,
    sd.unit_price,
    sd.subtotal,
    s.payment_method,
    CASE 
        WHEN sd.status = 'Cancelled' THEN 'Cancelled'
        WHEN s.status = 'Cancelled' THEN 'Cancelled'
        ELSE ISNULL(sd.status, 'Completed')
    END AS status
FROM dbo.sale_details sd
LEFT JOIN dbo.sales s ON sd.sale_id = s.id
LEFT JOIN dbo.customers c ON s.customer_id = c.id
LEFT JOIN dbo.products p ON sd.product_id = p.id;
GO

/* =====================================================
   18. VIEW STOCK ADJUSTMENT
   ===================================================== */
CREATE OR ALTER VIEW vw_Stock_adjustments AS 
SELECT 
    sa.id AS StockId,
    sa.product_id,
    p.name AS product_name,
    p.stock_quantity AS current_stock,
    sa.user_id,
    u.username,
    sa.type,
    sa.quantity,
    sa.reason,
    sa.adjusted_at,
    sa.status
FROM stock_adjustments sa
LEFT JOIN products p ON sa.product_id = p.id
LEFT JOIN users u ON sa.user_id = u.id;
GO

/* =====================================================
   19. VIEW STOCK ALERT
   ===================================================== */
CREATE OR ALTER VIEW vw_StockAlert AS
SELECT 
    p.[id] AS PartID,
    p.[barcode] AS Barcode,
    p.[name] AS ProductName,
    p.[category_id] AS CategoryID,
    ISNULL(c.name, 'Uncategorized') AS CategoryName, 
    p.[stock_quantity] AS CurrentStock,
    p.[stock_alert_level] AS AlertQty,
    COALESCE(
        (SELECT TOP 1 CONVERT(VARCHAR(10), pu.purchase_date, 120) 
         FROM [dbo].[purchase_details] pd 
         INNER JOIN [dbo].[purchases] pu ON pd.purchase_id = pu.id 
         WHERE pd.product_id = p.id 
         ORDER BY pu.purchase_date DESC), 
        'Never'
    ) AS LastRestocked,
    CASE 
        WHEN p.[stock_quantity] = 0 THEN 'Out of Stock'
        WHEN p.[stock_quantity] <= p.[stock_alert_level] THEN 'Low Stock'
        WHEN p.[stock_quantity] <= p.[stock_alert_level] * 2 THEN 'Medium Stock'
        ELSE 'Normal'
    END AS StatusText
FROM 
    [dbo].[products] p
LEFT JOIN 
    [dbo].[categories] c ON p.[category_id] = c.id
WHERE 
    p.[stock_quantity] <= p.[stock_alert_level] * 2;
GO

/* =====================================================
   20. VIEW PURCHASES ORDER
   ===================================================== */
CREATE OR ALTER VIEW vw_PurchasesOrder AS
SELECT
    pd.id                         AS purchase_detail_id,
    p.id                          AS purchase_id,
    p.purchase_number             AS purchase_number,
    p.purchase_date               AS purchase_date,
    p.supplier_id                 AS supplier_id,
    s.company_name                AS supplier_name,
    s.contact_name                AS contact_name,
    s.phone                       AS supplier_phone,
    p.user_id                     AS user_id,
    u.username                    AS username,
    pd.product_id                 AS product_id,
    pr.name                       AS product_name,
    pr.barcode                    AS barcode,
    pd.quantity                   AS quantity,
    pd.unit_cost                  AS unit_cost,
    pd.subtotal                   AS subtotal,
    p.total_amount                AS total_amount,
    p.status                      AS status
FROM purchase_details pd
INNER JOIN purchases p ON pd.purchase_id = p.id
LEFT JOIN suppliers s ON p.supplier_id = s.id
LEFT JOIN users u ON p.user_id = u.id
LEFT JOIN products pr ON pd.product_id = pr.id;
GO

/* =====================================================
   21. VIEW USER
   ===================================================== */
CREATE OR ALTER VIEW dbo.vw_Users AS
SELECT
    u.id,
    u.employee_id,
    e.fullname AS employee,
    e.photo_path,
    u.username,
    u.role_id,
    r.name AS role,
    u.password,
    u.status,
    u.created_at
FROM dbo.users u
LEFT JOIN dbo.employees e ON u.employee_id = e.id
LEFT JOIN dbo.roles r ON u.role_id = r.id;
GO
/* =====================================================
   22. VIEW PROMOTIONS
   ===================================================== */
CREATE OR ALTER VIEW dbo.vw_Promotions AS
SELECT 
    pr.id AS PromotionId,
    pr.promotion_name AS PromotionName,
    pr.product_id AS ProductId,
    p.barcode AS Barcode,
    p.name AS ProductName,
    p.cost_price AS CostPrice,
    p.selling_price AS OriginalPrice,
    pr.discount_percent AS DiscountPercent,
    CAST(p.selling_price * (1.0 - (pr.discount_percent / 100.0)) AS DECIMAL(10,2)) AS DiscountedPrice,
    CAST(p.selling_price * (pr.discount_percent / 100.0) AS DECIMAL(10,2)) AS DiscountAmount,
    pr.start_date AS StartDate,
    pr.end_date AS EndDate,
    pr.created_at AS CreatedAt,
    CASE 
        WHEN GETDATE() BETWEEN pr.start_date AND pr.end_date THEN 'Active'
        WHEN GETDATE() < pr.start_date THEN 'Upcoming'
        ELSE 'Expired'
    END AS Status
FROM dbo.promotions pr
INNER JOIN dbo.products p ON pr.product_id = p.id;
GO

/* =====================================================
   22. CREATE SALE PROCEDURE
   ===================================================== */
CREATE OR ALTER PROCEDURE sp_CreateSale
    @UserId BIGINT,
    @InvoiceNumber VARCHAR(50),
    @SaleDate DATETIME,
    @PaymentMethod VARCHAR(50),
    @Status VARCHAR(20),
    @DetailsJSON NVARCHAR(MAX),
    @CustomerId BIGINT = NULL,
    @PromotionId BIGINT = NULL,
    @Subtotal DECIMAL(10,2) = 0.00,
    @DiscountAmount DECIMAL(10,2) = 0.00,
    @GrandTotal DECIMAL(10,2) = 0.00,
    @NewSaleId BIGINT OUTPUT,
    @IsSuccess BIT OUTPUT,
    @ErrorMessage NVARCHAR(MAX) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        BEGIN TRANSACTION;

        -- 1. Insert into the main 'sales' table
        INSERT INTO sales (customer_id, user_id, promotion_id, subtotal, discount_amount, grand_total, sale_date, payment_method, status)
        VALUES (@CustomerId, @UserId, @PromotionId, @Subtotal, @DiscountAmount, @GrandTotal, @SaleDate, @PaymentMethod, @Status);

        -- Get the newly generated ID
        SET @NewSaleId = SCOPE_IDENTITY();

        -- 2. Insert into 'sale_details' by reading the JSON string
        INSERT INTO sale_details (sale_id, invoice_number, product_id, quantity, unit_price, subtotal)
        SELECT 
            @NewSaleId, 
            COALESCE(invoice_number, @InvoiceNumber),
            product_id, 
            quantity, 
            unit_price, 
            subtotal
        FROM OPENJSON(@DetailsJSON)
        WITH (
            invoice_number VARCHAR(50) '$.Invoice_number',
            product_id INT '$.Product_id',
            quantity INT '$.Quantity',
            unit_price DECIMAL(18,2) '$.Unit_price',
            subtotal DECIMAL(18,2) '$.Subtotal'
        );

        -- 3. Deduct stock quantity in the 'products' table
        UPDATE p
        SET p.stock_quantity = CASE 
                                  WHEN p.stock_quantity - d.quantity < 0 THEN 0 
                                  ELSE p.stock_quantity - d.quantity 
                               END
        FROM products p
        INNER JOIN OPENJSON(@DetailsJSON)
        WITH (
            product_id INT '$.Product_id',
            quantity INT '$.Quantity'
        ) d ON p.id = d.product_id;

        -- Commit if everything succeeds
        COMMIT TRANSACTION;
        
        SET @IsSuccess = 1;
        SET @ErrorMessage = N'';

    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        SET @IsSuccess = 0;
        SET @ErrorMessage = ERROR_MESSAGE();
    END CATCH
END;
GO

/* =====================================================
   23. CANCEL SALE PROCEDURE
   ===================================================== */
CREATE OR ALTER PROCEDURE sp_CancelSale
    @SaleId BIGINT,
    @IsSuccess BIT OUTPUT,
    @ErrorMessage NVARCHAR(MAX) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @CurrentStatus VARCHAR(20);

    SELECT @CurrentStatus = status 
    FROM sales 
    WHERE id = @SaleId;

    IF @CurrentStatus IS NULL
    BEGIN
        SET @IsSuccess = 0;
        SET @ErrorMessage = N'Sale not found in the system.';
        RETURN;
    END

    IF @CurrentStatus = 'Canceled'
    BEGIN
        SET @IsSuccess = 0;
        SET @ErrorMessage = N'This sale has already been canceled.';
        RETURN;
    END

    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE sales
        SET status = 'Canceled'
        WHERE id = @SaleId;

        UPDATE p
        SET p.stock_quantity = p.stock_quantity + sd.quantity
        FROM products p
        INNER JOIN sale_details sd ON p.id = sd.product_id
        WHERE sd.sale_id = @SaleId;

        COMMIT TRANSACTION;
        
        SET @IsSuccess = 1;
        SET @ErrorMessage = N'';
        
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        SET @IsSuccess = 0;
        SET @ErrorMessage = ERROR_MESSAGE();
    END CATCH
END;
GO
