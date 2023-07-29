CREATE PROCEDURE SPI_JobPost
    @title VARCHAR(100),
    @description VARCHAR(500)
AS
BEGIN
    INSERT INTO Table_Jobposts (title, description, postedDate)
    VALUES (@title, @description, GETDATE());
END;

CREATE PROCEDURE SPS_JobPost
AS
BEGIN
    SELECT * FROM Table_Jobposts ORDER BY postedDate DESC;
END;
