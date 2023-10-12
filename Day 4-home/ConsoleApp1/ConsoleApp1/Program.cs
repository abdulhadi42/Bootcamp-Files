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
            string connectionString= "Server=DESKTOP-0CVDBSG\\SQLEXPRESS;Database=5049_DB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {


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
            }

            Console.ReadLine();
        }

    }
}
