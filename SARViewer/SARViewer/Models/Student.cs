using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SARViewer.Models
{
    [DataContract (Namespace = "")]
    class Student
    {
        [DataMember(Order = 0)]
        public string FirstName { get; set; }
        [DataMember(Order = 1)]
        public string LastName { get; set; }
        [DataMember(Order = 2)]
        public int ID { get; set; }
        [DataMember(Order = 3)]
        public List<Course> CoursesRegistered { get; set; }
       
    }
}
