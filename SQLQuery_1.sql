CREATE DATABASE products
USE products
CREATE TABLE brands
(
    Id INT PRIMARY KEY IDENTITY,
    NAME NVARCHAR(100) NOT NULL,
    YEAR DATETIME2
)
SELECT * from brands