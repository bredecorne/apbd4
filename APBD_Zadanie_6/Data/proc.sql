CREATE PROCEDURE AddProductToWarehouse (
    IN IdProduct INT,
    IN IdWarehouse INT,
    IN Amount INT,
    IN CreatedAt DATETIME
)
BEGIN  

    DECLARE IdProductFromDb INT;
    DECLARE IdOrder INT;
    DECLARE Price DECIMAL(5,2);  

    -- MySQL equivalent of TOP 1 and handling potential NULLs
SELECT o.IdOrder INTO IdOrder
FROM `Order` o
         LEFT JOIN Product_Warehouse pw ON o.IdOrder = pw.IdOrder
WHERE o.IdProduct = IdProduct AND o.Amount = Amount AND pw.IdProductWarehouse IS NULL AND
    o.CreatedAt < CreatedAt
    LIMIT 1;

SELECT Product.IdProduct, Product.Price INTO IdProductFromDb, Price
FROM Product
WHERE IdProduct = IdProduct;

IF IdProductFromDb IS NULL THEN 
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Invalid parameter: Provided IdProduct does not exist';
END IF;

    IF IdOrder IS NULL THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Invalid parameter: There is no order to fulfill';
END IF;

    IF NOT EXISTS (SELECT 1 FROM Warehouse WHERE IdWarehouse = IdWarehouse) THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Invalid parameter: Provided IdWarehouse does not exist';
END IF;

START TRANSACTION; -- MySQL equivalent of XACT_ABORT ON

UPDATE `Order` SET
    FulfilledAt = CreatedAt
WHERE IdOrder = IdOrder;

INSERT INTO Product_Warehouse (IdWarehouse, IdProduct, IdOrder, Amount, Price, CreatedAt)
VALUES (IdWarehouse, IdProduct, IdOrder, Amount, Amount * Price, CreatedAt);

SELECT LAST_INSERT_ID() AS NewId; -- Get Auto-Incremented ID

COMMIT;
END
