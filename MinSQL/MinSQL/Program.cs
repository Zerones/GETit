using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Net;
using MinSQL.TDbModel;

namespace MinSQL
{
    class Program
    {
        static string ConnectionString => ConfigurationManager.ConnectionStrings["TestDb"].ConnectionString;

        static void Main(string[] args)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                RunDemo(connection);
                Console.ReadKey();
            }
        }

        private static void RunDemo(SqlConnection connection)
        {
            var selectStudent = new SelectStudent();
            var insertStudent = new InsertUser();
            var deleteStudent = new DeleteUser();
            var elev = new Student
            {
                Name = "",
                Path = "[dbo].[Student]"
            };
            Console.Write("You can Delete, Insert, Update or Select a user {Template: [Command] [User]}: ");
            var input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                var command = input.Split(' ');
                switch (command[0].ToLower())
                {
                    case "delete":
                        elev.Name = command[1];
                        deleteStudent.DeleteUser(connection, elev.Name, elev.Path);
                        Console.WriteLine($"Deleting user {elev.Name}...");
                        break;
                    case "insert":
                        elev.Name = command[1];
                        insertStudent.AddUser(connection, elev.Name, elev.Path);
                        Console.WriteLine($"Creating new user {elev.Name}...");
                        break;
                    case "update":
                        break;
                    case "select":
                        break;
                    default:
                        Console.WriteLine("Invalid input, please try again..." + Environment.NewLine);
                        break;
                }

            }
            else
            {
                Console.WriteLine("Invalid input, please try again..." + Environment.NewLine);
            }
            Console.WriteLine("Outputting list of all students: ");
            var students = selectStudent.GetAllStudents(connection);
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }
    }
}
