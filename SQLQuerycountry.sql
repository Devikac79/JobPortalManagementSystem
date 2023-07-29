use Database_JobPortal;



CREATE TABLE Table_Countries (
    countryId INT PRIMARY KEY,
    countryName VARCHAR(100)
);

CREATE TABLE Table_States (
    stateId INT PRIMARY KEY,
    stateName VARCHAR(100),
    countryId INT FOREIGN KEY REFERENCES Table_Countries(countryId)
);

CREATE TABLE Table_Cities (
    cityId INT PRIMARY KEY,
    cityName VARCHAR(100),
    stateId INT FOREIGN KEY REFERENCES Table_States(stateId)
);


ALTER TABLE Table_Signup
ADD countryId int;

ALTER TABLE Table_Signup
ADD stateId int;

ALTER TABLE Table_Signup
ADD cityId int;

INSERT INTO Table_Countries (countryId, countryName)
VALUES
    (1, 'India'),
    (2, 'USA');


INSERT INTO Table_States (stateId, stateName, countryId)
VALUES
    (1, 'Tamil Nadu', 1),
    (2, 'Kerala', 1),
    (3, 'Maharashtra', 1);

	INSERT INTO Table_States (stateId, stateName, countryId)
VALUES
    (4, 'California', 2),
    (5, 'Texas', 2)
   


	INSERT INTO Table_Cities (cityId, cityName, stateId)
VALUES
    (1, 'Chennai', 1),
    (2, 'Coimbatore', 1),
    (3, 'Madurai', 1),
	(4, 'Kochi', 2),
    (5, 'kozhikode', 2),
    (6, 'kannur', 2),
	(7, 'Mumbai', 3),
    (8, 'Pune', 3),
	(9, 'Los Angeles', 4),
    (10, 'San Francisco', 4),
	(11, 'Houstan', 5),
    (12, 'Austin', 5);


	select * from Table_Countries;

   	select * from Table_States;
	select * from Table_Cities;


