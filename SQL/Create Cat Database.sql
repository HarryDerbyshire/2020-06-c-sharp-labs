USE master

DROP DATABASE IF EXISTS CatDB
GO

CREATE DATABASE CatDB
GO

USE CatDB
GO

DROP TABLE IF EXISTS Cats
DROP TABLE IF EXISTS Breeds


CREATE TABLE Cats (
	CatID int not null identity primary key,
	CatName nvarchar(50),
	Age int,
	CatDescription nvarchar(50)
)

CREATE TABLE Breeds (
	BreedID int not null identity primary key,
	BreedName nvarchar(50)
)

INSERT INTO Cats VALUES ('Ozzy', 15,'Mainecoon')
INSERT INTO Cats VALUES ('Lucy', 3,'Sphinx')
INSERT INTO Cats VALUES ('Jasper', 1,'Great cat')

INSERT INTO Breeds values ('Mainecoon')
INSERT INTO Breeds values ('Tabby')
INSERT INTO Breeds values ('Sphinx')

SELECT * FROM  Cats
SELECT * FROM  Breeds