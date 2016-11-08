using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;

namespace SARViewer.Models 
{
    /// <summary>
    /// Represents a collection of student data with associated course data.
    /// </summary>
    [DataContract(Namespace ="")]
    public class StudentData
    {
        /// <summary>
        /// Relative filepath constant for file generated and loaded.
        /// </summary>
        private static readonly string FILEPATH = AppDomain.CurrentDomain.BaseDirectory + @"\Resources\studentData.xml";

        /// <summary>
        /// Gets and Sets List of Students.
        /// </summary>
        [DataMember]
        public List<Student> StudentDirectory { get; set; }

        /// <summary>
        /// Creates a new StudentData object from a specific XML file.
        /// </summary>
        /// <remarks>This method is meant to take place of the traditional constructor.
        /// It searches for a specific file, deserializes it, then returns the data
        /// within a new Student Data object.</remarks>
        /// <returns>StudentData object.</returns>
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
