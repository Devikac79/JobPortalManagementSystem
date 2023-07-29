CREATE TABLE Table_Jobposts (
    Id INT PRIMARY KEY Identity(1,1),
    title VARCHAR(100) NOT NULL,
    description VARCHAR(500) NOT NULL,
    postedDate DATETIME NOT NULL
);


