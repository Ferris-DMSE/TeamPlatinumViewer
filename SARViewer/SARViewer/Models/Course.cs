using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace SARViewer.Models
{
    /// <summary>
    /// Represents a course from XML file.
    /// </summary>
    [DataContract(Namespace = "")]
    class Course
    {
        /// <summary>
        /// Gets or Sets the course's unique ID.
        /// </summary>
        [DataMember(Order = 0)]
        public int UniqueID { get; set; }

        /// <summary>
        /// Gets or Sets the course's course number.
        /// </summary>
        [DataMember(Order = 1)]
        public string CourseNumber { get; set; }

        /// <summary>
        /// Gets or Sets the course's name.
        /// </summary>
        [DataMember(Order = 2)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets the course's credit value.
        /// </summary>
        [DataMember(Order = 3)]
        public int Credits { get; set; }

        /// <summary>
        /// Gets or Sets the course's academic year held.
        /// </summary>
        [DataMember(Order = 4)]
        public int Year { get; set; }

        /// <summary>
        /// Gets or Sets the course's semester held.
        /// </summary>
        [DataMember(Order = 5)]
        public string Semester { get; set; }

        /// <summary>
        /// Gets or Sets the course's academic type.
        /// </summary>
        [DataMember(Order = 6)]
        public string CourseType { get; set; }

        /// <summary>
        /// Gets or Sets the student's grade in the course.
        /// </summary>
        [DataMember(Order = 7)]
        public string Grade { get; set; }

    }
}
