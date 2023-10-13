--Task 9: Selection queries



--1
CREATE PROCEDURE Task9_1
	
AS
	BEGIN
		SELECT StudentID,Firstname, LastName FROM Students
		WHERE CourseID IS NULL;
	END;
GO

--2
CREATE PROCEDURE Task9_2
	
AS
	BEGIN
		
		SELECT TOP 1
		CourseID,
		COUNT(CourseID) AS Occurance
		FROM
			Students
		GROUP BY 
			CourseID
		ORDER BY 
			Occurance DESC;
	END;
GO



--3
CREATE PROCEDURE Task9_3
	
AS
	BEGIN
		SELECT * FROM Students
		WHERE Age > (sELECT AVG(Age) FROM Students); 

	END;
GO



--4
CREATE PROCEDURE Task9_4
	
AS
	BEGIN
		--4
		SELECT
			CourseID,
			COUNT(*) AS Total_Number_of_Students,
			AVG(Age) AS Average_Age
		FROM
			Students
		WHERE
			CourseID IS NOT NULL
		GROUP BY
			CourseID
		ORDER BY
			CourseID ASC

	END;
GO



--5
CREATE PROCEDURE Task9_5
	
AS
	BEGIN
		SELECT *
		FROM 
			Courses
		WHERE 
			CourseID NOT IN   (SELECT NULL FROM Students WHERE Students.CourseID = Courses.CourseID)
	END;
GO




--6
CREATE PROCEDURE Task9_6
	
AS
	BEGIN
		SELECT * FROM Students
		WHERE CourseID=(SELECT CourseID FROM Students WHERE StudentID=2) AND NOT StudentID =2 

	END;
GO



--7
CREATE PROCEDURE Task9_7
	
AS
	BEGIN
		SELECT
			CourseID,
			min(age) AS Youngest, 
			max(age) AS Oldest
		FROM
			Students
		WHERE
			CourseID IS NOT NULL
		
		GROUP BY
			CourseID
	END;
GO

