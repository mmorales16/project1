Create table Invoices (
Id Int IDENTITY (1,1) PRIMARY KEY,
Invoice varchar (20) NOT NULL,
Date DATE not null,
Customer VARCHAR (100) not null,
Total DECIMAL (10,2) NOT NULL
)

SELECT * FROM Invoices
