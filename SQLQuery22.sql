﻿Create table Invoices (
Id Int IDENTITY (1,1) PRIMARY KEY,
Invoice varchar (20) NOT NULL,
Date DATE not null,
Customer VARCHAR (100) not null,
Total DECIMAL (10,2) NOT NULL
)
select * from Invoices

INSERT INTO Invoices (Invoice, Date, Customer, Total)
VALUES
    ('FAC001', '2023-07-01', 'Cliente A', 150.50),
    ('FAC002', '2023-07-02', 'Cliente B', 200.25),
    ('FAC003', '2023-07-03', 'Cliente C', 75.80),
    ('FAC004', '2023-07-04', 'Cliente D', 350.00),
    ('FAC005', '2023-07-05', 'Cliente E', 90.25),
    ('FAC006', '2023-07-06', 'Cliente A', 280.30),
    ('FAC007', '2023-07-07', 'Cliente B', 50.00),
    ('FAC008', '2023-07-08', 'Cliente C', 180.75),
    ('FAC009', '2023-07-09', 'Cliente D', 60.50),
    ('FAC010', '2023-07-10', 'Cliente E', 320.00),
    ('FAC011', '2023-07-11', 'Cliente A', 190.20),
    ('FAC012', '2023-07-12', 'Cliente B', 70.10),
    ('FAC013', '2023-07-13', 'Cliente C', 420.80),
    ('FAC014', '2023-07-14', 'Cliente D', 85.75),
    ('FAC015', '2023-07-15', 'Cliente E', 220.00),
    ('FAC016', '2023-07-16', 'Cliente A', 300.90),
    ('FAC017', '2023-07-17', 'Cliente B', 110.00),
    ('FAC018', '2023-07-18', 'Cliente C', 75.50),
    ('FAC019', '2023-07-19', 'Cliente D', 410.30),
    ('FAC020', '2023-07-20', 'Cliente E', 95.10),
    ('FAC021', '2023-07-21', 'Cliente A', 520.20),
    ('FAC022', '2023-07-22', 'Cliente B', 200.00),
    ('FAC023', '2023-07-23', 'Cliente C', 60.75),
    ('FAC024', '2023-07-24', 'Cliente D', 300.25),
    ('FAC025', '2023-07-25', 'Cliente E', 40.00),
    ('FAC026', '2023-07-25', 'Cliente A', 175.30),
    ('FAC027', '2023-07-25', 'Cliente B', 90.10),
    ('FAC028', '2023-07-25', 'Cliente C', 410.80),
    ('FAC029', '2023-07-25', 'Cliente D', 75.75),
    ('FAC030', '2023-07-25', 'Cliente E', 320.50),
    ('FAC031', '2023-07-24', 'Cliente A', 200.20),
    ('FAC032', '2023-07-23', 'Cliente B', 50.10),
    ('FAC033', '2023-07-22', 'Cliente C', 180.80),
    ('FAC034', '2023-07-21', 'Cliente D', 95.75),
    ('FAC035', '2023-07-20', 'Cliente E', 240.00),
    ('FAC036', '2023-07-19', 'Cliente A', 280.90),
    ('FAC037', '2023-07-18', 'Cliente B', 120.00),
    ('FAC038', '2023-07-17', 'Cliente C', 85.50),
    ('FAC039', '2023-07-16', 'Cliente D', 320.30),
    ('FAC040', '2023-07-15', 'Cliente E', 70.10),
    ('FAC041', '2023-07-14', 'Cliente A', 390.20),
    ('FAC042', '2023-07-13', 'Cliente B', 60.00),
    ('FAC043', '2023-07-12', 'Cliente C', 120.75),
    ('FAC044', '2023-07-11', 'Cliente D', 400.25),
    ('FAC045', '2023-07-10', 'Cliente E', 55.00),
    ('FAC046', '2023-07-09', 'Cliente A', 215.30),
    ('FAC047', '2023-07-08', 'Cliente B', 80.10),
    ('FAC048', '2023-07-07', 'Cliente C', 310.80),
    ('FAC049', '2023-07-06', 'Cliente D', 100.75),
    ('FAC050', '2023-07-05', 'Cliente E', 360.50);