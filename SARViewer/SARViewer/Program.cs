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
            List<Student> stLst;
            //stLst = sd.parseStudents();
            int count = 0;
            StudentData sdd = Serialization<StudentData>.DeserializeFromXmlFile(@"C:\Users\USER\Documents\Git\TeamPlatinumViewer\SARViewer\SARViewer\XMLStudentData\studentData.xml");
            foreach (Student student in sdd.StudentDirectory)
            {
                Console.WriteLine(student.ID);
                Console.WriteLine(student.FirstName);
                Console.WriteLine(student.LastName);
                Console.WriteLine();
                Console.WriteLine();

                foreach (Course course in student.CoursesRegistered)
                {
                    Console.WriteLine(course.ID);
                    Console.WriteLine(course.Name);
                    Console.WriteLine(course.Semester);
                    Console.WriteLine(course.CourseType);
                    Console.WriteLine(course.Credits);
                }
                count++;
            }
            Console.WriteLine(count);
            Console.ReadKey();
        }
    }
}
