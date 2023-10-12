--Task 7: Selection queries



--1
CREATE PROCEDURE Task7_1
	
AS
	BEGIN
		SELECT StudentID,Firstname, LastName FROM Students
		WHERE CourseID IS NULL;
	END;
GO

--2
CREATE PROCEDURE Task7_2
	
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




CREATE PROCEDURE Task7_3
	
AS
	BEGIN
		SELECT * FROM Students
		WHERE Age > (sELECT AVG(Age) FROM Students); 

	END;
GO




CREATE PROCEDURE Task7_4
	
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




CREATE PROCEDURE Task7_5
	
AS
	BEGIN
		SELECT
			CourseID,
			COUNT(CourseID) as Occurance
		FROM
			Students
		WHERE
			CourseID IS NOT NULL
		
		GROUP BY
			CourseID
		HAVING 
				COUNT(CourseID)=0
		ORDER BY
			Occurance ASC;
	END;
GO




CREATE PROCEDURE Task7_6
	
AS
	BEGIN
		SELECT * FROM Students
		WHERE courseID=(SELECT CourseID FROM Students WHERE StudentID=2) AND NOT StudentID =2 

	END;
GO




CREATE PROCEDURE Task7_7
	
AS
	BEGIN
		SELECT
			CourseID,
			min(age) AS Youngest, 
			max(age) AS Oldest
		FROM
			Students
		GROUP BY
			CourseID
	END;
GO














--7

