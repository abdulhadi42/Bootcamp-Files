CREATE PROCEDURE AddStudents
	@StudentID INT,
	@FirstName VARCHAR(50),
	@LastName VARCHAR(50),
	@Age INT,
	@CourseID INT
AS
	BEGIN
		INSERT INTO Students (StudentID,FirstName,LastName,Age,CourseID)
		VALUES (@StudentID,@FirstName,@LastName,@Age,@CourseID);
	END;
GO

CREATE PROCEDURE UpdateAge
	@StudentID INT,
	@NewAge INT
AS 
	BEGIN
		UPDATE Students
		SET Age=@NewAge
		WHERE StudentID=@StudentID;
	END;
GO

CREATE PROCEDURE DeleteStudent
	@StudentID INT
AS 
	BEGIN
		DELETE FROM Students
		WHERE StudentID=@StudentID;
	END;
GO

CREATE PROCEDURE ListStudent
AS 
	BEGIN
		SELECT * FROM Students
	END;
GO