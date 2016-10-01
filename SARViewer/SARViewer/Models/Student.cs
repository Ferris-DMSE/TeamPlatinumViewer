using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SARViewer.Models
{
    class Student
    {
        public static int StudentID;
        public string StudentFirstName = string.Empty;
        public string StudentLastName = string.Empty;
        List<string> CourseList = new List<string>();
    }
}
