-- Establece la base de datos en la que se ejecutarán los siguientes comandos.
USE MyDatabaseName
GO;

-- Elimina la tabla OrderReports si ya existe, para evitar errores al crearla.
DROP TABLE IF EXISTS OrderReports
GO;

-- Crea una nueva tabla llamada OrderReports con varias columnas para almacenar informes de órdenes.
CREATE TABLE OrderReports
(
    ReportId     INT PRIMARY KEY IDENTITY, -- Columna ReportId como clave primaria, autoincrementable.
    OrderId      INT,                      -- Columna OrderId para almacenar el ID de la orden.
    CustomerName VARCHAR(255),             -- Columna CustomerName para almacenar el nombre del cliente.
    Quantity     decimal(18, 2),           -- Columna Quantity para almacenar la cantidad, con precisión decimal.
    ReportDate   DATETIME                  -- Columna ReportDate para almacenar la fecha del reporte.
)
GO;

-- Crea un nuevo procedimiento almacenado llamado GenerateOrderReports.
CREATE PROCEDURE GenerateOrderReports
AS
BEGIN
    -- Primero, borra cualquier dato existente en la tabla OrderReports.
    DELETE FROM OrderReports;

    -- Luego, inserta nuevos registros en OrderReports.
    -- Estos registros son el resultado de una consulta que combina datos de las tablas Orders y Customers.
    INSERT INTO OrderReports (OrderId, CustomerName, Quantity, ReportDate)
    SELECT o.Id,       -- Selecciona el ID de la orden.
           c.Name,     -- Selecciona el nombre del cliente.
           o.Quantity, -- Selecciona la cantidad de la orden.
           GETDATE()   -- Usa la fecha y hora actual para ReportDate.
    FROM Orders o -- Desde la tabla Orders.
             INNER JOIN
         Customers c ON o.CustomerId = c.Id -- Une la tabla Customers donde los IDs de cliente coincidan.
END
GO;
