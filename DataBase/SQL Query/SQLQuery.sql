CREATE DATABASE RestauranteApp
GO
USE RestauranteApp
GO
CREATE TABLE FirstCourses
(
ID INT IDENTITY PRIMARY KEY,
NAME VARCHAR(75),
PRICE DECIMAL(13,2)
)
GO
CREATE TABLE MainCourses
(
ID INT IDENTITY PRIMARY KEY,
NAME VARCHAR(75),
PRICE DECIMAL(13,2)
)
GO
CREATE TABLE Desserts
(
ID INT IDENTITY PRIMARY KEY,
NAME VARCHAR(75),
PRICE DECIMAL(13,2)
)
GO
CREATE TABLE Drinks
(
ID INT IDENTITY PRIMARY KEY,
NAME VARCHAR(75),
PRICE DECIMAL(13,2)
)
GO
CREATE TABLE States
(
ID INT IDENTITY PRIMARY KEY,
NAME VARCHAR(15)
)
GO

CREATE TABLE Orders
(
ID INT IDENTITY PRIMARY KEY,
CLIENTE_NAME VARCHAR(75),
FIRST_COURSE INT FOREIGN KEY REFERENCES FirstCourses(ID),
MAIN_COURSE INT FOREIGN KEY REFERENCES MainCourses(ID),
DESSERTS INT FOREIGN KEY REFERENCES Desserts(ID),
DRINKS INT FOREIGN KEY REFERENCES Drinks(ID),
STATES INT FOREIGN KEY REFERENCES States(ID) DEFAULT 1,
CREATE_DATE DATETIME DEFAULT CURRENT_TIMESTAMP,
SUB_TOTAL DECIMAL(13,2),
ITBIS DECIMAL(13,2),
TOTAL DECIMAL(13,2),
)

GO
CREATE VIEW VW_Orders
AS
SELECT O.ID,O.CLIENTE_NAME,F.NAME AS FirstCourses, M.NAME AS MainCourses,DE.NAME AS Desserts,DR.NAME AS Drinks,S.NAME AS Status,O.CREATE_DATE,O.SUB_TOTAL,O.ITBIS,O.TOTAL FROM Orders O
LEFT JOIN FirstCourses F ON F.ID = O.FIRST_COURSE
LEFT JOIN MainCourses M ON M.ID = O.MAIN_COURSE
LEFT JOIN Desserts DE ON DE.ID = O.DESSERTS
LEFT JOIN Drinks DR ON DR.ID = O.DRINKS
LEFT JOIN States S ON S.ID = O.STATES

GO

-----------------------------INSERTING-----------------------------------------

INSERT INTO MainCourses VALUES ('Pollo a la Parmesana',510.45),('Camarones Jumbo',842.95),('Arroz con Mariscos',420.30),
							   ('Arroz con Camarones',521.69),('Atún a la Plancha',410.25),('Filete de Pescado',451.38),
							   ('Pescado Entero Frito',960.50),('Sopa de Mariscos',1050.47),('Espaguetti de la Casa',705.14),
							   ('Linguini con Camarones',420.25)
INSERT INTO FirstCourses VALUES ('Tournedo Rossini',1402.21),('Pollo salteado con patatas parisién',1202.14),('Bacalao con costra de mahonesa de pera',2010.87),
								('Pollo cocido a la cazuela con riesling y rebozuelos',920.45),('Chuletón de vaca',1051.35),('Corvina con salsa de chile dulce',701.62),
								('Magret de pato y granada',2501.69),('Bacalao a la gallega con el toque mágico de Olei',3201.45),('Rosbif, Yorkshire pudding, salsa Robert y su jugo',3201.76),
								('Pastel o tarta de picantón y verduras,',1540.32)
INSERT INTO Desserts VALUES ('Flan',521.96),('Pudín de Pan',549.32),('Tres Leches',410.54),
							('Bizcocho Dominicano',309.21),('Arroz con Leche',501.31),('Maíz Caquiao',710.85),
							('Dulce Frío',452.18),('Arepa',620.14),('Habichuelas con Dulce',632.10),
							('Paletas de Coco',521.96)
INSERT INTO Drinks VALUES ('Cerveza Regular',450.52),('Cerveza Light',500.14),('Vino Tinto',840.21),
						  ('Vino Blanco',921.32),('Vodka',3201.45),('Ron',1720.36),
						  ('Whisky',4051.65),('Jugo de Naranjas', 405.54),('Jugo de Limón',405.54),
						  ('Agua Oxigenada',320.24)
INSERT INTO States VALUES('Pending'),('In Process'),('To Deliver'),('Done')

