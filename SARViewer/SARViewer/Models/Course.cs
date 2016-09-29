using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SARViewer.Models
{
    class Course
    {
        #region Fields
        private int courseID;            //All the fields each course requires
        private string courseNumber;
        private string courseName;
        private int credit;
        private string semester;
        private int year;
        private string courseType;
        private string grade;
        private bool completed;
        #endregion

        #region Properties

        public int CourseID
        {
            get { return courseID; }
            set { courseID = value; }
        }

        public string CourseNumber
        {
            get { return courseNumber; }
            set { courseNumber = value; }
        }
        public string CourseName
        {
            get { return courseName; }
            set { courseName = value; }
        }

        public int Credit            
        {
            get { return credit; }
            set { credit = value; }
        }
        
        public string Semester
        {
            get { return semester; }
            set { semester = value; }
        }
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        public string CourseType
        {
            get { return courseType; }
            set { courseType = value; }
        }
        public string Grade
        {
            get { return grade; }
            set { grade = value; }
        }
        public bool Completed
        {
            get
            {
                if (grade != "I" && grade != "W" )
                {
                    return true;
                }
                else
                {
                    return false;
                } 
            }
            set { }
        }
        #endregion


        public Course() //Empty Constructor 
        {                                         
            
        }
    }
}
