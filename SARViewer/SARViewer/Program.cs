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
            StudentData sd = new StudentData();
            sd = sd.deserializeFromXML();

            //StudentData sdd = Serialization<StudentData>.DeserializeFromXmlFile(@"C:\Users\USER\Documents\Git\TeamPlatinumViewer\SARViewer\SARViewer\XMLStudentData\studentData.xml");
            if (sd != null)
            {
                foreach (Student student in sd.StudentDirectory)
                {
                    Console.WriteLine();
                    Console.WriteLine("\t" + student.ID);
                    Console.WriteLine("\t" + student.FirstName);
                    Console.WriteLine("\t" + student.LastName);
                    Console.WriteLine();


                    foreach (Course course in student.CoursesRegistered)
                    {
                        Console.WriteLine(course.ID);
                        Console.WriteLine(course.Name);
                        Console.WriteLine(course.Semester);
                        Console.WriteLine(course.CourseType);
                        Console.WriteLine(course.Credits);
                        Console.WriteLine();
                    }

                }
            }
            
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
