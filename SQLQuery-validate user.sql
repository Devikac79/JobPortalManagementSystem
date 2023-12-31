USE [Database_JobPortal]
GO
/****** Object:  StoredProcedure [dbo].[SPS_ValidateUser]    Script Date: 27-07-2023 16:04:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SPS_ValidateUser]
    @username VARCHAR(50),
    @password VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    -- Declare a variable to hold the count of matching users
    DECLARE @userCount INT;

    -- Check if the provided username and password match any user in the database
    SELECT @userCount = COUNT(*)
    FROM Table_Signup
    WHERE Username = @username AND Password = @password;

    -- Return 1 if a matching user is found, 0 otherwise
    IF @userCount > 0
        SELECT 1 AS Result;
    ELSE
        SELECT 0 AS Result;
END
