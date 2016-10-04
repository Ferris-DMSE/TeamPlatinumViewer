using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SARViewer.Models
{
    class Course
    {
        public int UniqueID { get; set; }
        public string CourseNumber { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public int Year { get; set; }
        public string Semester { get; set; }
        public string CourseType { get; set; }
        public string Grade { get; set; }

    }
}
