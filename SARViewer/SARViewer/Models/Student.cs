using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SARViewer.Models
{
    class Student
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }
        public List<Course> CoursesRegistered { get; set; }
       
    }
}
