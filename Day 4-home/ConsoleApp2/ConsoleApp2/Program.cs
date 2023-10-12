using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=DESKTOP-0CVDBSG\\SQLEXPRESS;Database=5049_DB;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                
                using (SqlCommand command=new SqlCommand("Task7_1", connection))
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


                using (SqlCommand command = new SqlCommand("Task7_2", connection))
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

                using (SqlCommand command = new SqlCommand("Task7_3", connection))
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

                using (SqlCommand command = new SqlCommand("Task7_4", connection))
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

                using (SqlCommand command = new SqlCommand("Task7_5", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Console.WriteLine("Courses that have no students enrolled in them are: ");
                    int n = 0;
                    while (reader.Read())
                    {
                        n++;
                        Console.WriteLine($"CourseID : {reader["CourseID"]} with {reader["Occurance"]} Occurances.");
                    }
                    if (n==0)
                    {
                        Console.WriteLine("None");
                    }
                    connection.Close();
                }

                using (SqlCommand command = new SqlCommand("Task7_6", connection))
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

                using (SqlCommand command = new SqlCommand("Task7_7", connection))
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
