CREATE PROCEDURE GetCountries
AS
BEGIN
    SELECT countryId, countryName FROM Table_Countries;
END;

CREATE PROCEDURE GetStatesByCountry
    @countryId INT
AS
BEGIN
    SELECT stateId, stateName FROM Table_States WHERE countryId = @countryId;
END;

CREATE PROCEDURE GetCitiesByState
    @stateId INT
AS
BEGIN
    SELECT cityId, cityName FROM Table_Cities WHERE stateId = @stateId;
END;

EXEC GetStatesByCountry @countryId = 2;


