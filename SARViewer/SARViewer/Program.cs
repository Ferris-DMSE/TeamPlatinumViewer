using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SARViewer.Models;

namespace SARViewer
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentData data = new StudentData();
            data = data.deserializeFromXML();

            
            if (data != null)
            {
                char choice;
                do
                {
                    queryAndDisplayLogic(data);
                    Console.WriteLine("Press 1 to search for another student or press 2 to exit the application.");
                    choice = Console.ReadKey().KeyChar;
                    Console.Clear();
                }
                while (choice != '2');

            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            
        }

        private static void queryAndDisplayLogic(StudentData data)
        {
            Console.WriteLine("Please enter the name of the student to view their SAR.");
            string userQuery = Console.ReadLine();
            userQuery = userQuery.ToUpper();
            var query = from student in data.StudentDirectory
                        where student.FirstName == userQuery || student.LastName == userQuery
                        select student;

            if (query.Count() == 0)
                Console.WriteLine("No students by that name.\n");
            foreach (Student student in query)
            {
                Console.WriteLine("\t" + student.FirstName);
                Console.WriteLine("\t" + student.LastName);
                Console.WriteLine("\t" + student.ID);
                Console.WriteLine("--------------------------------------");

                foreach (Course course in student.CoursesRegistered)
                {
                    Console.WriteLine(course.ID);
                    Console.WriteLine(course.Name);
                    Console.WriteLine(course.Semester);
                    Console.WriteLine(course.Grade);
                    Console.WriteLine(course.Credits);
                    Console.WriteLine();
                }
            }
        }
    }
}
