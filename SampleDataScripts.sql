/* Delete Queries
delete from Product;
delete from Retailer;
delete from ProductGroup;
delete from RetailerProducts;
*/
-- Product List
/**
INSERT INTO Product (Name, GroupId, MRP) VALUES ("Asus Rog", 1, 1200.0);
INSERT INTO Product (Name, GroupId, MRP) VALUES ("HP Pavalion", 1, 650.0);
INSERT INTO Product (Name, GroupId, MRP) VALUES ("Dell", 1, 500.0);
INSERT INTO Product (Name, GroupId, MRP) VALUES ("Asus Zenbook", 1, 769.0);
INSERT INTO Product (Name, GroupId, MRP) VALUES ("Asus Vivobook", 1, 678.0);
INSERT INTO Product (Name, GroupId, MRP) VALUES ("MSI", 1, 999.0);
INSERT INTO Product (Name, GroupId, MRP) VALUES ("Macbook M1 Air 8Gb", 1, 1020.0);
INSERT INTO Product (Name, GroupId, MRP) VALUES ("Macbook M2 Air 16gb", 1, 1620.0);

INSERT INTO Product (Name, GroupId, MRP) VALUES ("Asus Rog 8 Pro", 2, 1100.0);
INSERT INTO Product (Name, GroupId, MRP) VALUES ("IPhone 14", 2, 800.0);
INSERT INTO Product (Name, GroupId, MRP) VALUES ("IPhone 15", 2, 1000.0);
INSERT INTO Product (Name, GroupId, MRP) VALUES ("Remdi Note 12", 2, 500.0);
INSERT INTO Product (Name, GroupId, MRP) VALUES ("OnePlus 12", 2, 799.0);
INSERT INTO Product (Name, GroupId, MRP) VALUES ("Samsung A25", 2, 899.0);
INSERT INTO Product (Name, GroupId, MRP) VALUES ("Google Pixel 8", 2, 999.0);

INSERT INTO Product (Name, GroupId, MRP) VALUES ("XBOX X", 3, 489.0);
INSERT INTO Product (Name, GroupId, MRP) VALUES ("XBox S", 3, 333.0);
INSERT INTO Product (Name, GroupId, MRP) VALUES ("PS 4 500GB", 3, 199.0);
INSERT INTO Product (Name, GroupId, MRP) VALUES ("PS 5 Slim", 3, 449.0);
*/
-- With ID
INSERT INTO Product (Id, Name, GroupId, MRP) VALUES (1, "Asus Rog", 1, 1200.0);
INSERT INTO Product (Id, Name, GroupId, MRP) VALUES (2, "HP Pavalion", 1, 650.0);
INSERT INTO Product (Id, Name, GroupId, MRP) VALUES (3, "Dell", 1, 500.0);
INSERT INTO Product (Id, Name, GroupId, MRP) VALUES (4, "Asus Zenbook", 1, 769.0);
INSERT INTO Product (Id, Name, GroupId, MRP) VALUES (5, "Asus Vivobook", 1, 678.0);
INSERT INTO Product (Id, Name, GroupId, MRP) VALUES (6, "MSI", 1, 999.0);
INSERT INTO Product (Id, Name, GroupId, MRP) VALUES (7, "Macbook M1 Air 8Gb", 1, 1020.0);
INSERT INTO Product (Id, Name, GroupId, MRP) VALUES (8, "Macbook M2 Air 16gb", 1, 1620.0);

INSERT INTO Product (Id, Name, GroupId, MRP) VALUES (9, "Asus Rog 8 Pro", 2, 1100.0);
INSERT INTO Product (Id, Name, GroupId, MRP) VALUES (10, "IPhone 14", 2, 800.0);
INSERT INTO Product (Id, Name, GroupId, MRP) VALUES (11, "IPhone 15", 2, 1000.0);
INSERT INTO Product (Id, Name, GroupId, MRP) VALUES (12, "Remdi Note 12", 2, 500.0);
INSERT INTO Product (Id, Name, GroupId, MRP) VALUES (13, "OnePlus 12", 2, 799.0);
INSERT INTO Product (Id, Name, GroupId, MRP) VALUES (14,"Samsung A25", 2, 899.0);
INSERT INTO Product (Id, Name, GroupId, MRP) VALUES (15, "Google Pixel 8", 2, 999.0);

INSERT INTO Product (Id, Name, GroupId, MRP) VALUES (16, "XBOX X", 3, 489.0);
INSERT INTO Product (Id, Name, GroupId, MRP) VALUES (17, "XBox S", 3, 333.0);
INSERT INTO Product (Id, Name, GroupId, MRP) VALUES (18, "PS 4 500GB", 3, 199.0);
INSERT INTO Product (Id, Name, GroupId, MRP) VALUES (19, "PS 5 Slim", 3, 449.0);



-- Retailer List

INSERT INTO Retailer VALUES (1, "Apple Official");
INSERT INTO Retailer VALUES (2, "Media Markt");
INSERT INTO Retailer VALUES (3, "ELV Elektronik");

-- delete from Retailer;

-- Product Group List

INSERT INTO ProductGroup VALUES (1, "Laptops");
INSERT INTO ProductGroup VALUES (2, "Mobile Phones");
INSERT INTO ProductGroup VALUES (3, "Home Video Game");

-- delete from ProductGroup;

-- Association of Product and Retailer

-- More data for RetailerProducts, ensuring one product to many retailers

-- Asus Rog sold by multiple retailers
INSERT INTO RetailerProducts VALUES (20, 1, 1, 1150.00, 1100.00); -- Apple Official
INSERT INTO RetailerProducts VALUES (21, 2, 1, 1170.00, 1120.00); -- Media Markt
INSERT INTO RetailerProducts VALUES (22, 3, 1, 1160.00, 1110.00); -- ELV Elektronik

-- HP Pavilion sold by multiple retailers
INSERT INTO RetailerProducts VALUES (23, 1, 2, 630.00, 600.00); -- Apple Official
INSERT INTO RetailerProducts VALUES (24, 2, 2, 640.00, 610.00); -- Media Markt
INSERT INTO RetailerProducts VALUES (25, 3, 2, 620.00, 590.00); -- ELV Elektronik

-- Dell sold by multiple retailers
INSERT INTO RetailerProducts VALUES (26, 1, 3, 480.00, 460.00); -- Apple Official
INSERT INTO RetailerProducts VALUES (27, 2, 3, 490.00, 470.00); -- Media Markt
INSERT INTO RetailerProducts VALUES (28, 3, 3, 470.00, 450.00); -- ELV Elektronik

-- Asus Zenbook sold by multiple retailers
INSERT INTO RetailerProducts VALUES (29, 1, 4, 750.00, 730.00); -- Apple Official
INSERT INTO RetailerProducts VALUES (30, 2, 4, 760.00, 740.00); -- Media Markt
INSERT INTO RetailerProducts VALUES (31, 3, 4, 740.00, 720.00); -- ELV Elektronik

-- Asus Vivobook sold by multiple retailers
INSERT INTO RetailerProducts VALUES (32, 1, 5, 670.00, 650.00); -- Apple Official
INSERT INTO RetailerProducts VALUES (33, 2, 5, 680.00, 660.00); -- Media Markt
INSERT INTO RetailerProducts VALUES (34, 3, 5, 660.00, 640.00); -- ELV Elektronik

-- MSI sold by multiple retailers
INSERT INTO RetailerProducts VALUES (35, 1, 6, 980.00, 960.00); -- Apple Official
INSERT INTO RetailerProducts VALUES (36, 2, 6, 990.00, 970.00); -- Media Markt
INSERT INTO RetailerProducts VALUES (37, 3, 6, 970.00, 950.00); -- ELV Elektronik

-- Macbook M1 Air 8Gb sold by multiple retailers
INSERT INTO RetailerProducts VALUES (38, 1, 7, 1000.00, 980.00); -- Apple Official
INSERT INTO RetailerProducts VALUES (39, 2, 7, 1020.00, 1000.00); -- Media Markt
INSERT INTO RetailerProducts VALUES (40, 3, 7, 990.00, 970.00); -- ELV Elektronik

-- Macbook M2 Air 16gb sold by multiple retailers
INSERT INTO RetailerProducts VALUES (41, 1, 8, 1600.00, 1580.00); -- Apple Official
INSERT INTO RetailerProducts VALUES (42, 2, 8, 1620.00, 1600.00); -- Media Markt
INSERT INTO RetailerProducts VALUES (43, 3, 8, 1580.00, 1560.00); -- ELV Elektronik

-- Asus Rog 8 Pro sold by multiple retailers
INSERT INTO RetailerProducts VALUES (44, 1, 9, 1080.00, 1060.00); -- Apple Official
INSERT INTO RetailerProducts VALUES (45, 2, 9, 1100.00, 1080.00); -- Media Markt
INSERT INTO RetailerProducts VALUES (46, 3, 9, 1060.00, 1040.00); -- ELV Elektronik

-- IPhone 14 sold by multiple retailers
INSERT INTO RetailerProducts VALUES (47, 1, 10, 790.00, 770.00); -- Apple Official
INSERT INTO RetailerProducts VALUES (48, 2, 10, 800.00, 780.00); -- Media Markt
INSERT INTO RetailerProducts VALUES (49, 3, 10, 780.00, 760.00); -- ELV Elektronik

-- IPhone 15 sold by multiple retailers
INSERT INTO RetailerProducts VALUES (50, 1, 11, 980.00, 960.00); -- Apple Official
INSERT INTO RetailerProducts VALUES (51, 2, 11, 1000.00, 980.00); -- Media Markt
INSERT INTO RetailerProducts VALUES (52, 3, 11, 960.00, 940.00); -- ELV Elektronik

-- Remdi Note 12 sold by multiple retailers
INSERT INTO RetailerProducts VALUES (53, 1, 12, 490.00, 470.00); -- Apple Official
INSERT INTO RetailerProducts VALUES (54, 2, 12, 500.00, 480.00); -- Media Markt
INSERT INTO RetailerProducts VALUES (55, 3, 12, 480.00, 460.00); -- ELV Elektronik

-- OnePlus 12 sold by multiple retailers
INSERT INTO RetailerProducts VALUES (56, 1, 13, 780.00, 760.00); -- Apple Official
INSERT INTO RetailerProducts VALUES (57, 2, 13, 800.00, 780.00); -- Media Markt
INSERT INTO RetailerProducts VALUES (58, 3, 13, 760.00, 740.00); -- ELV Elektronik

-- Samsung A25 sold by multiple retailers
INSERT INTO RetailerProducts VALUES (59, 1, 14, 880.00, 860.00); -- Apple Official
INSERT INTO RetailerProducts VALUES (60, 2, 14, 900.00, 880.00); -- Media Markt
INSERT INTO RetailerProducts VALUES (61, 3, 14, 860.00, 840.00); -- ELV Elektronik

-- Google Pixel 8 sold by multiple retailers
INSERT INTO RetailerProducts VALUES (62, 1, 15, 980.00, 960.00); -- Apple Official
INSERT INTO RetailerProducts VALUES (63, 2, 15, 1000.00, 980.00); -- Media Markt
INSERT INTO RetailerProducts VALUES (64, 3, 15, 960.00, 940.00); -- ELV Elektronik

-- XBOX X sold by multiple retailers
INSERT INTO RetailerProducts VALUES (65, 1, 16, 470.00, 450.00); -- Apple Official
INSERT INTO RetailerProducts VALUES (66, 2, 16, 480.00, 460.00); -- Media Markt
INSERT INTO RetailerProducts VALUES (67, 3, 16, 460.00, 440.00); -- ELV Elektronik

-- XBox S sold by multiple retailers
INSERT INTO RetailerProducts VALUES (68, 1, 17, 320.00, 310.00); -- Apple Official
INSERT INTO RetailerProducts VALUES (69, 2, 17, 330.00, 320.00); -- Media Markt
INSERT INTO RetailerProducts VALUES (70, 3, 17, 310.00, 300.00); -- ELV Elektronik

-- PS 4 500GB sold by multiple retailers
INSERT INTO RetailerProducts VALUES (71, 1, 18, 190.00, 180.00); -- Apple Official
INSERT INTO RetailerProducts VALUES (72, 2, 18, 200.00, 190.00); -- Media Markt
INSERT INTO RetailerProducts VALUES (73, 3, 18, 180.00, 170.00); -- ELV Elektronik

-- PS 5 Slim sold by multiple retailers
INSERT INTO RetailerProducts VALUES (74, 1, 19, 430.00, 420.00); -- Apple Official
INSERT INTO RetailerProducts VALUES (75, 2, 19, 440.00, 430.00); -- Media Markt
INSERT INTO RetailerProducts VALUES (76, 3, 19, 420.00, 410.00); -- ELV Elektronik


