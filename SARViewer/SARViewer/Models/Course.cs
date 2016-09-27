using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SARViewer.Models
{
    class Course
    {
        public int CourseID;            //All the fields each course requires
        public string CourseNumber;
        public string CourseName;
        public int Credit;
        public string Semester;
        public int Year;
        public string CourseType;
        public string Grade;
        public bool Completed;
        
        public Course(int courseID, int credit, int year, string coursenumber, string coursename, string semester, string coursetype, string grade, bool completed)
        {                              //Construction of the course object
            Completed = completed;
            CourseID = courseID;           
            CourseNumber = coursenumber;
            CourseName = coursename;
            Credit = credit;
            Semester = semester;
            Year = year;
            CourseType = coursetype;
            Grade = grade;
            
        }
    }
}
