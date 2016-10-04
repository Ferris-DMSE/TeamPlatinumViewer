using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;

namespace SARViewer.Models 
{
    [DataContract(Namespace ="")]
    class StudentData
    {
        private const string FILEPATH = @"..\..\XMLStudentData\studentData.xml";

        [DataMember]
        public List<Student> StudentDirectory { get; set; }

        public static StudentData DeserializeFromXML()
        {
            StudentData data = new StudentData();

            if (!File.Exists(FILEPATH))
            {
                return null;
            }

            DataContractSerializer Deserializer = new DataContractSerializer(typeof(StudentData));

            using (Stream stream = File.OpenRead(FILEPATH))
            {
                data = (StudentData)Deserializer.ReadObject(stream);
            }

            return data;

        }
        


    }
}
