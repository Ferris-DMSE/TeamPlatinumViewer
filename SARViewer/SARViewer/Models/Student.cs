using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SARViewer.Models
{
    /// <summary>
    /// Represents a Student from XML
    /// </summary>
    [DataContract (Namespace = "")]
    class Student
    {
        /// <summary>
        /// Gets or Sets the student's first name.
        /// </summary>
        [DataMember(Order = 0)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or Sets the student's last name.
        /// </summary>
        [DataMember(Order = 1)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or Sets the student's ID.
        /// </summary>
        [DataMember(Order = 2)]
        public int ID { get; set; }

        /// <summary>
        /// Gets or Sets the student's Courses Registered
        /// </summary>
        /// <remarks>Gives access to the List of Courses
        /// that a student is registered for.</remarks>
        [DataMember(Order = 3)]
        public List<Course> CoursesRegistered { get; set; }

        public override string ToString()
        {
            string returnString = "";
            returnString += "\n\nStudent Info:\n" +
            FirstName + " " + LastName + "   ID: " +
            ID + "\n\n" + "Student's Course List:\n" +
            "-------------------------\n";
            foreach (Course course in CoursesRegistered)
            {
                returnString += course.ToString();
            }

            return returnString; 
        }

    }
}
