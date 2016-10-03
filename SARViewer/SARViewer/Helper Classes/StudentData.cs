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
        private const string FILEPATH = @"C:\Users\USER\Documents\Git\TeamPlatinumViewer\SARViewer\SARViewer\XMLStudentData\studentData.xml";
        private List<Student> studentDirectory = new List<Student>();

        [DataMember]
        public List<Student> StudentDirectory { get { return studentDirectory; } set { studentDirectory = value; } }

        public StudentData deserializeFromXML()
        {
            StudentData sd = new StudentData();
            if (!File.Exists(FILEPATH))
            {
                return null;
            }

            DataContractSerializer deserializer = new DataContractSerializer(typeof(StudentData));

            using (Stream stream = File.OpenRead(FILEPATH))
            {
                 sd = (StudentData)deserializer.ReadObject(stream);
            }


            return sd;
        }
    }

    public static class Serialization<T> where T : class
    {

        public static T DeserializeFromXmlFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return null;
            }

            DataContractSerializer deserializer = new DataContractSerializer(typeof(T));

            using (Stream stream = File.OpenRead(fileName))
            {
                return (T)deserializer.ReadObject(stream);
            }
        }
    }
}
