CREATE PROCEDURE SPI_JobPost(
	@Id int=,
    @title VARCHAR(50),
    @location VARCHAR(50),
    @min_salary INT,
    @max_salary INT,
    @job_category VARCHAR(50),
    @job_nature VARCHAR(50),
    @post_date DATE,
    @end_date DATE,
    @description VARCHAR(100)
)
AS
BEGIN
    INSERT INTO Table_Jobposts (title, location, min_salary, max_salary, job_category, job_nature, post_date, end_date, description)
    VALUES (@title, @location, @min_salary, @max_salary, @job_category, @job_nature, @post_date, @end_date, @description);
END




CREATE PROCEDURE SPS_JobPost
AS
BEGIN
    SELECT title, location, min_salary, max_salary, job_category, job_nature, post_date, end_date, description
    FROM Table_Jobposts;
END 
