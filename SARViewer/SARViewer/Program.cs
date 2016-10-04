using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SARViewer.Models;
using SARViewer.Helper_Classes;

namespace SARViewer
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentData Data = StudentData.DeserializeFromXML();

            foreach (Student student in Data.StudentDirectory)
            {
                Console.WriteLine(student.FirstName + ", " + student.LastName);
            }

            Console.ReadKey();
        }
    }
}
