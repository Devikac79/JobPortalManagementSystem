CREATE TABLE Table_Jobposts (
	Id int primary key Identity(1,1),
    title VARCHAR(50),
    location VARCHAR(50),
    min_salary int,
    max_salary int,
    job_category VARCHAR(50) CHECK (job_category IN ('Software Engineer', 'Frond End Developer', 'Back End Developer','Software Tester','Quality Analyst','Web Development','UI/UX Designer')),
    job_nature VARCHAR(50) CHECK (job_nature IN ('Full Time','Part Time','Remote')),
    post_date DATE,
    end_date DATE,
    description varchar(100)
);

CREATE TABLE Table_Jobposts (
	Id int primary key Identity(1,1),
    title VARCHAR(50),
    location VARCHAR(50),
    min_salary int,
    max_salary int,
    job_category VARCHAR(50) CHECK (job_category IN ('Software Engineer', 'Frond End Developer', 'Back End Developer','Software Tester','Quality Analyst','Web Development','UI/UX Designer')),
    job_nature VARCHAR(50) CHECK (job_nature IN ('Full Time','Part Time','Remote')),
    post_date DATE,
    end_date DATE,
    description varchar(100)
);


CREATE TABLE Table_JobCategories (
    Id INT PRIMARY KEY,
    category VARCHAR(50)
);

CREATE TABLE Table_JobNature (
    Id INT PRIMARY KEY,
    JobNature VARCHAR(50)
);
CREATE TABLE Table_Jobpost (
	Id int primary key Identity(1,1),
    title VARCHAR(50),
    location VARCHAR(50),
    minSalary int,
    maxSalary int,
    JobCategoryId int,
	JobNatureId int,
    postDate DATE,
    endDate DATE,
    description varchar(100)
);
ALTER TABLE Table_JobPost
ADD CONSTRAINT JobCategoryId
FOREIGN KEY (JobCategoryId) REFERENCES Table_JobCategories(Id);

ALTER TABLE Table_JobPost
ADD CONSTRAINT JobNatureId
FOREIGN KEY (JobNatureId) REFERENCES Table_JobNature(Id);

CREATE PROCEDURE SPI_JobPosts(
	@Id int=null,
    @title VARCHAR(50),
    @location VARCHAR(50),
    @minSalary INT,
    @maxSalary INT,
    @JobCategoryId INT,
	@JobNatureId INT,
    @postDate DATE,
    @endDate DATE,
    @description VARCHAR(100)
)
AS
BEGIN
    INSERT INTO Table_Jobposts (title, location, minSalary, maxSalary, JobCategoryId, JobNatureId, postDate, endDate, description)
    VALUES (@title, @location, @minSalary, @maxSalary, @JobCategoryId, @JobNatureId, @postDate, @endDate, @description);
END

