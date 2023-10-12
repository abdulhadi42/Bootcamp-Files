--Task 1: Create a Database

--CREATE DATABASE 5049_DB;

--Task 2: Create Tables

--2
CREATE TABLE Courses(
  CourseID INT PRIMARY KEY,
  CourseName VARCHAR(50)
 );


--1

CREATE TABLE Students(
  StudentID INT PRIMARY KEY,
  FirstName VARCHAR(50),
  LastName VARCHAR(50),
  Age INT,
  CourseID INT,
  CONSTRAINT FK_Course
  FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
 );

 --Task 3: Insert Data
 --1
INSERT INTO Courses (CourseID,CourseName)
VALUES 	(1, 'Machine Vision'),
		(2, 'Inteligent Systems'),
        (3, 'Mobile Robotics'),
        (4, 'DSA'),
        (5, 'OOP');

--2
INSERT into Students (StudentID,FirstName,LastName,Age,CourseID)
VALUES 	(1,'Muhammad', 'Ali',19,1),
		(2,'Muhammad', 'Ali',20,2),
		(3,'Muhammad', 'Ahmed',22,4),
		(4,'Ali', 'Hamza',18,5),
		(5,'Muhammad', 'Haseeb',24,3),
		(6,'Usman', 'Tariq',20,2),
		(7,'Shaheer', 'Khan',21,5),
		(8,'Dawood', 'Imtiaz',21,4),
		(9,'Dawood', 'Tahir',22,2),
		(10,'Usman', 'Irshad',23,1);

--Task 4: Update and Delete Records
--1
UPDATE Students
SET Age=25
WHERE StudentID=2;

--2
DELETE FROM Students WHERE StudentID=4;



--Task 5: Queries and Filters
--1
SELECT FirstName, LastName
FROM Students
WHERE Age>20;


--2
SELECT * FROM Students
INNER JOIN Courses ON Courses.CourseID = Students.CourseID
where Students.CourseID=2;


--Task 6: Aggregation Functions
--1
SELECT COUNT(*)
FROM Students;

--2
SELECT AVG(Age)
FROM Students;


--Task 7: Selection queries

--1
SELECT Firstname, LastName FROM Students
WHERE CourseID=NULL;


--2
SELECT TOP 1
  CourseID,
  COUNT(CourseID) AS Occurance

FROM
  Students
  
GROUP BY 
  CourseID
  
ORDER BY 
  Occurance DESC;
  

--3
SELECT * FROM Students
WHERE Age > (sELECT AVG(Age) FROM Students); 



--4
SELECT
	CourseID,
	COUNT(*) AS Total_Number_of_Students,
	AVG(Age) AS Average_Age
FROM
	Students
GROUP BY
	CourseID
ORDER BY
	CourseID ASC

--5
SELECT
	CourseID,
	COUNT(*) as Occurance
FROM
	Students
WHERE
	CourseID=NULL
GROUP BY
	CourseID

--6

SELECT * FROM Students
WHERE courseID=(SELECT CourseID FROM Students WHERE StudentID=3)



--7
SELECT
	CourseID,
	min(age) AS Youngest, 
    max(age) AS Oldest
FROM
	Students
GROUP BY
	CourseID
