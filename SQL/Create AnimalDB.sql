DROP DATABASE IF EXISTS Animal2DB

CREATE DATABASE Animal2DB

USE Animal2DB

CREATE TABLE Animals (
	AnimalID int not null identity primary key,
	AnimalName nvarchar(50),
	AnimalTypeID int foreign key references AnimalTypes(AnimalTypeID)
)

CREATE TABLE AnimalTypes (
	AnimalTypeID int not null identity primary key,
	TypeName nvarchar(50)
)

INSERT INTO AnimalTypes VALUES ('Big Cat')
INSERT INTO AnimalTypes VALUES ('Bird of Prey')
INSERT INTO AnimalTypes VALUES ('Fish')

SELECT * FROM AnimalTypes

INSERT INTO Animals VALUES ('Tiger', 1)
INSERT INTO Animals VALUES ('Eagle', 2)
INSERT INTO Animals VALUES ('Salmon', 3)

SELECT * FROM Animals a INNER JOIN AnimalTypes t ON t.AnimalTypeID = a.AnimalTypeID