using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.ConstrainedExecution;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //cmdlhrdb01
            string connectionString = "Server=cmdlhrdb01;Database=5049_DB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                // Task 7:
                // Execute Stored Procedure to list all Students
                using (SqlCommand command = new SqlCommand("AddStudent", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", "Abdul");
                    command.Parameters.AddWithValue("@LastName", "Hadi");
                    command.Parameters.AddWithValue("@Age", 23);
                    command.Parameters.AddWithValue("@CourseID", 5);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }


                // Execute Stored Procedure to update age of Student
                using (SqlCommand command = new SqlCommand("UpdateAge", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StudentID", 11);
                    command.Parameters.AddWithValue("@NewAge", 23);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                // Execute Stored Procedure to delete a Student
                using (SqlCommand command = new SqlCommand("deletestudent", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StudentID", 11);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }



                // Execute Stored Procedure to list all Students
                using (SqlCommand command = new SqlCommand("ListStudents", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine($"StudentID: {reader["StudentID"]} , Fisrt Name: {reader["FirstName"]} , Last Name: {reader["LastName"]} , Age: {reader["Age"]} , CourseID: {reader["CourseID"]}");
                    }
                    connection.Close();
                }


                //Task 9

                //1
                using (SqlCommand command = new SqlCommand("Task9_1", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Console.WriteLine("The Students with no courses registered are: ");
                    while (reader.Read())
                    {
                        Console.WriteLine($"StudentID : {reader["StudentID"]}, Name : {reader["Firstname"]} {reader["Lastname"]}");
                    }
                    connection.Close();
                }

                //2
                using (SqlCommand command = new SqlCommand("Task9_2", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Console.WriteLine("Most Popular Course is: ");
                    while (reader.Read())
                    {
                        Console.WriteLine($"CourseID : {reader["CourseID"]} with {reader["Occurance"]} Occurances.");
                    }
                    connection.Close();
                }
                //3
                using (SqlCommand command = new SqlCommand("Task9_3", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Console.WriteLine("Students Whose age is greater than average are: ");
                    while (reader.Read())
                    {
                        Console.WriteLine($"StudentID: {reader["StudentID"]} , Fisrt Name: {reader["FirstName"]} , Last Name: {reader["LastName"]} , Age: {reader["Age"]} , CourseID: {reader["CourseID"]}");
                    }
                    connection.Close();
                }
                //4
                using (SqlCommand command = new SqlCommand("Task9_4", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Console.WriteLine("The total number of students and average age for each course are: ");
                    while (reader.Read())
                    {
                        Console.WriteLine($"CourseID : {reader["CourseID"]}, Total_Number_of_Students : {reader["Total_Number_of_Students"]} , Average_Age : {reader["Average_Age"]}.");
                    }
                    connection.Close();
                }
                //5
                using (SqlCommand command = new SqlCommand("Task9_5", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Console.WriteLine("Courses that have no students enrolled in them are: ");
                    int n = 0;
                    while (reader.Read())
                    {
                        n++;
                        Console.WriteLine($"CourseID : {reader["CourseID"]} , {reader["CourseName"]} ");
                    }
                    if (n == 0)
                    {
                        Console.WriteLine("None");
                    }
                    connection.Close();
                }
                //6
                using (SqlCommand command = new SqlCommand("Task9_6", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Console.WriteLine("students who share courses with a specific student with Student ID 2 are: ");
                    while (reader.Read())
                    {
                        Console.WriteLine($"StudentID: {reader["StudentID"]} , Fisrt Name: {reader["FirstName"]} , Last Name: {reader["LastName"]} , Age: {reader["Age"]} , CourseID: {reader["CourseID"]}");
                    }
                    connection.Close();
                }
                //7
                using (SqlCommand command = new SqlCommand("Task9_7", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Console.WriteLine("For Each Course the youngest and Oldest are : ");
                    int n = 0;
                    while (reader.Read())
                    {
                        n++;
                        Console.WriteLine($"CourseID : {reader["CourseID"]} Youngest {reader["Youngest"]} Oldest {reader["Oldest"]} .");
                    }
                    if (n == 0)
                    {
                        Console.WriteLine("None");
                    }
                    connection.Close();
                }
















            }



            Console.ReadLine();
        }

    }
}