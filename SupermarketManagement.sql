CREATE DATABASE SupermarketManagement;
GO

USE SupermarketManagement;
GO

/* =====================================================
   1. ROLES
   ===================================================== */
CREATE TABLE roles (
    id INT IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(50) NOT NULL UNIQUE,
    description VARCHAR(MAX),
    created_at DATETIME NOT NULL DEFAULT GETDATE()
);
GO


/* =====================================================
   2. EMPLOYEES
   ===================================================== */
CREATE TABLE employees (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    phone VARCHAR(20),
    email VARCHAR(100),
    position VARCHAR(50),
    salary DECIMAL(10,2),
    hire_date DATE,
    created_at DATETIME NOT NULL DEFAULT GETDATE()
);
GO


/* =====================================================
   3. USERS
   ===================================================== */
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
GO


/* =====================================================
   4. STORE INFO
   ===================================================== */
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
GO


/* =====================================================
   5. CUSTOMERS
   ===================================================== */
CREATE TABLE customers (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    phone VARCHAR(20),
    email VARCHAR(100),
    address VARCHAR(MAX),
    points INT NOT NULL DEFAULT 0,
    created_at DATETIME NOT NULL DEFAULT GETDATE()
);
GO


/* =====================================================
   6. SUPPLIERS
   ===================================================== */
CREATE TABLE suppliers (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    company_name VARCHAR(100) NOT NULL,
    contact_name VARCHAR(100),
    phone VARCHAR(20) NOT NULL,
    email VARCHAR(100),
    address VARCHAR(MAX),
    created_at DATETIME NOT NULL DEFAULT GETDATE()
);
GO


/* =====================================================
   7. CATEGORIES
   ===================================================== */
CREATE TABLE categories (
    id INT IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(50) NOT NULL UNIQUE,
    description VARCHAR(MAX),
    created_at DATETIME NOT NULL DEFAULT GETDATE()
);
GO


/* =====================================================
   8. UNITS
   ===================================================== */
CREATE TABLE units (
    id INT IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    short_name VARCHAR(10)
);
GO


/* =====================================================
   9. PRODUCTS
   ===================================================== */
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
GO


/* =====================================================
   10. PROMOTIONS
   ===================================================== */
CREATE TABLE promotions (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    title VARCHAR(100),
    discount_type VARCHAR(10) NOT NULL,
    discount_value DECIMAL(10,2),
    start_date DATETIME NOT NULL,
    end_date DATETIME NOT NULL,
    status VARCHAR(10) NOT NULL DEFAULT 'active',

    CONSTRAINT CK_promotions_discount_type
        CHECK (discount_type IN ('percentage', 'fixed')),

    CONSTRAINT CK_promotions_status
        CHECK (status IN ('active', 'inactive'))
);
GO


/* =====================================================
   11. PURCHASES
   ===================================================== */
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
GO


/* =====================================================
   12. PURCHASE DETAILS
   ===================================================== */
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
GO


/* =====================================================
   13. SALES
   ===================================================== */
CREATE TABLE sales (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,

    customer_id BIGINT NULL,
    user_id BIGINT NOT NULL,
    promotion_id BIGINT NULL,
    subtotal DECIMAL(10,2),
    discount_amount DECIMAL(10,2),
    grand_total DECIMAL(10,2),
    payment_method VARCHAR(10) NOT NULL,
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
GO


/* =====================================================
   14. SALE DETAILS
   ===================================================== */
CREATE TABLE sale_details (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    invoice_number VARCHAR(50) NOT NULL UNIQUE,
    sale_id BIGINT NOT NULL,
    product_id BIGINT NOT NULL,
    quantity INT NOT NULL,
    unit_price DECIMAL(10,2) NOT NULL,
    subtotal DECIMAL(10,2) NOT NULL,

    CONSTRAINT FK_sale_details_sales
        FOREIGN KEY (sale_id)
        REFERENCES sales(id),

    CONSTRAINT FK_sale_details_products
        FOREIGN KEY (product_id)
        REFERENCES products(id)
);
GO


/* =====================================================
   15. STOCK ADJUSTMENTS
   ===================================================== */
CREATE TABLE stock_adjustments (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    product_id BIGINT NOT NULL,
    user_id BIGINT NOT NULL,
    type VARCHAR(10) NOT NULL,
    quantity INT NOT NULL,
    reason VARCHAR(255),
    adjusted_at DATETIME NOT NULL DEFAULT GETDATE(),

    CONSTRAINT FK_stock_adjustments_products
        FOREIGN KEY (product_id)
        REFERENCES products(id),

    CONSTRAINT FK_stock_adjustments_users
        FOREIGN KEY (user_id)
        REFERENCES users(id),

    CONSTRAINT CK_stock_adjustments_type
        CHECK (type IN ('addition', 'subtraction'))
);
GO

/* =====================================================
   16. VIEWS PRODUCTS
   ===================================================== */
CREATE VIEW vw_Products AS
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
/*  ========================================
    17. VIEW SALE HISTORY
    ========================================*/

ALTER VIEW vw_SaleHistory AS
SELECT 
    sd.id AS SaleHistoryID,
    sd.sale_id,
    sd.invoice_number,
    s.sale_date,
    sd.product_id,
    p.name AS product_name,
    sd.quantity,
    sd.unit_price,
    sd.subtotal,
    s.payment_method,
    s.status
FROM sale_details sd
LEFT JOIN sales s ON sd.sale_id = s.id
LEFT JOIN products p ON sd.product_id = p.id;
GO
/*  ========================================
    18. VIEW STOCK ADJUSTMENT
    ========================================*/

CREATE VIEW vw_Stock_adjustments AS 
SELECT 
    sa.id AS StockId,
    sa.product_id,
    p.name AS product_name,
    sa.user_id,
    u.username,
    sa.type,
    sa.quantity,
    sa.reason,
    sa.adjusted_at
FROM stock_adjustments sa
LEFT JOIN products p ON sa.product_id = p.id
LEFT JOIN users u ON sa.user_id = u.id;
GO

----------------------------
-- Create Sale
--------------------------
CREATE PROCEDURE sp_CreateSale
    @UserId BIGINT,
    @InvoiceNumber VARCHAR(50),
    @SaleDate DATETIME,
    @PaymentMethod VARCHAR(50),
    @Status VARCHAR(20),
    @DetailsJSON NVARCHAR(MAX), -- We pass the list of items as a JSON string
    @NewSaleId BIGINT OUTPUT,   -- To return the newly generated Sale ID to C#
    @IsSuccess BIT OUTPUT,
    @ErrorMessage NVARCHAR(MAX) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        BEGIN TRANSACTION;

        -- 1. Insert into the main 'sales' table
        INSERT INTO sales (user_id, sale_date, payment_method, status)
        VALUES (@UserId, @SaleDate, @PaymentMethod, @Status);

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

--------------------------
-- Cance lSale
---------------------------
CREATE PROCEDURE sp_CancelSale
    @SaleId BIGINT,                   -- The Sale ID you want to cancel
    @IsSuccess BIT OUTPUT,            -- To return the result to C# (1 = Success, 0 = Failed)
    @ErrorMessage NVARCHAR(MAX) OUTPUT -- To return the error message to C#
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @CurrentStatus VARCHAR(20);

    -- 1. Check if the sale exists and get its current status
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

    -- Start Transaction
    BEGIN TRY
        BEGIN TRANSACTION;

        -- 2. Update sale status to 'Canceled'
        UPDATE sales
        SET status = 'Canceled'
        WHERE id = @SaleId;

        -- 3. Return stock quantity (by joining with sale_details)
        UPDATE p
        SET p.stock_quantity = p.stock_quantity + sd.quantity
        FROM products p
        INNER JOIN sale_details sd ON p.id = sd.product_id
        WHERE sd.sale_id = @SaleId;

        -- Commit Transaction on success
        COMMIT TRANSACTION;
        
        SET @IsSuccess = 1;
        SET @ErrorMessage = N'';
        
    END TRY
    BEGIN CATCH
        -- Rollback data if any error occurs
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        SET @IsSuccess = 0;
        SET @ErrorMessage = ERROR_MESSAGE(); -- Get the error message from SQL Server
    END CATCH
END;
GO

