using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SARViewer.Models
{
    [DataContract(Namespace ="")]
    class Course
    {
        #region Fields
        private string courseID;            //All the fields each course requires
        private string courseName;
        private int credit;
        private string semester;
        private int year;
        private string courseType;
        private string grade;
        #endregion

        #region Properties
        [DataMember(Order = 0)]
        public string ID
        {
            get { return courseID; }
            set { courseID = value; }
        }
        [DataMember(Order =1)]
        public string Name
        {
            get { return courseName; }
            set { courseName = value; }
        }
        [DataMember(Order = 2)]
        public int Credits            
        {
            get { return credit; }
            set { credit = value; }
        }
        [DataMember(Order = 3)]
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

        [DataMember(Order = 4)]
        public string CourseType
        {
            get { return courseType; }
            set { courseType = value; }
        }

        [DataMember(Order = 5)]
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
