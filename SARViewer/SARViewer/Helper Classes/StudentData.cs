using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Runtime.Serialization;

namespace SARViewer.Models
{
    [DataContract (Namespace ="")]
    class StudentData
    {
        private const string FILEPATH = @"..\..\XMLStudentData\studentData.xml";
        private List<Student> studentDirectory = new List<Student>();

        [DataMember]
        public List<Student> StudentDirectory { get { return studentDirectory; } set { studentDirectory = value; } }

        public StudentData deserializeFromXML()
        {
            StudentData data = new StudentData();
            if (!File.Exists(FILEPATH))
            {
                return null;
            }

            DataContractSerializer deserializer = new DataContractSerializer(typeof(StudentData));

            using (Stream stream = File.OpenRead(FILEPATH))
            {
                 data = (StudentData)deserializer.ReadObject(stream);
            }


            return data;
        }
    }

}
