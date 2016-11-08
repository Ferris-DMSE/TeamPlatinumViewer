using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SARViewer.Models;

namespace SARViewerUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private StudentData studentData = new StudentData();

        public MainWindow()
        {
            InitializeComponent();

            studentData = StudentData.DeserializeFromXML(); //Gets data's value from deserializing the XML file
        }

        public void KeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                DisplayResults();

            }
        }

        private void tbxStudentID_KeyDownHandler(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Return)
            {
                DisplayResults(true);

            }
        }

        public void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            DisplayResults();
        }

        public void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearScreen();
        }

        public void DisplayResults(bool useStudentID = false)
        {
            List<Student> studentResults = useStudentID ? SearchStudents(tbxStudentID.Text) :SearchStudents(tbxFName.Text, tbxLName.Text, tbxStudentID.Text);
            String msg = ValidateSearchResults(studentResults);
            if (!String.IsNullOrEmpty(msg))
            {
                MessageBox.Show(msg, "SARViewerUI");
                ClearScreen();
                return;
            }
            else
            {
                Student s = studentResults[0];
                grdCourses.DataContext = s.CoursesRegistered;
                tbxStudentID.Text = s.ID.ToString();
                tbxFName.Text = s.FirstName;
                tbxLName.Text = s.LastName;

                IEnumerable<Course> completedCourses = s.CoursesRegistered.Where(c => c.Grade.ToUpper() != "I" && c.Grade.ToUpper() != "W");
                int coursesTaken = s.CoursesRegistered.Count;
                int coursesWithdrawn = s.CoursesRegistered.Count(c => c.Grade.ToUpper() == "W");
                int coursesIncompleted = s.CoursesRegistered.Count(c => c.Grade.ToUpper() == "I");
                int coursesCompleted = coursesTaken - coursesIncompleted - coursesWithdrawn;
                
                int CoreCompleted = completedCourses.Count(c => c.CourseType.ToUpper().Contains("CORE"));
                int GenEdCompleted = completedCourses.Count(c => c.CourseType.ToUpper().Contains("GEN"));
                int ElectCompleted = completedCourses.Count(c => c.CourseType.ToUpper().Contains("ELECT"));

                tbxCoursesCompleted.Text = coursesCompleted.ToString();
                tbxCoreCompleted.Text = GetPercentage(CoreCompleted, coursesTaken).ToString();
                tbxGenEdCompleted.Text = GetPercentage(GenEdCompleted, coursesTaken).ToString();
                tbxElectiveCompleted.Text = GetPercentage(ElectCompleted, coursesTaken).ToString();
            }
        }

        public void ClearScreen()
        {
            tbxFName.Text = String.Empty;
            tbxLName.Text = String.Empty;
            tbxStudentID.Text = String.Empty;

            grdCourses.DataContext = null;
            grdCourses.Items.Refresh();
            tbxCoreCompleted.Text = String.Empty;
            tbxGenEdCompleted.Text = String.Empty;
            tbxElectiveCompleted.Text = String.Empty;
            tbxCoursesCompleted.Text = String.Empty;
        }

        public decimal GetPercentage(int part, int whole)
        {
            return Decimal.Round((part / Convert.ToDecimal(whole) * 100), 2);
        }

        public string ValidateSearchResults(List<Student> students)
        {
            if (studentData == null) return "Data file could not be found or loaded.";
            if (students == null || students.Count == 0) return String.Format(SARViewer.Strings.No_Students_Found_0_1, tbxFName.Text, tbxLName.Text);
            else if (students.Count > 1) return SARViewer.Strings.Returned_More_Than_One_Student;
            return String.Empty;
        }

        public List<Student> SearchStudents(string FName, string LName, string studentID = "")
        {
            if (studentData == null) return null;

            FName = FName.ToUpper();
            LName = LName.ToUpper();

            IEnumerable<Student> query = from student in studentData.StudentDirectory select student;

            if (!String.IsNullOrWhiteSpace(FName))
            {
                query = from student in query
                        where student.FirstName.ToUpper().Contains(FName)
                        select student;
            }

            if (!String.IsNullOrWhiteSpace(LName))
            {
                query = from student in query
                        where student.LastName.ToUpper().Contains(LName)
                        select student;
            }

            if (!String.IsNullOrWhiteSpace(studentID))
            {
                query = from student in query
                        where student.ID.ToString().Equals(studentID)
                        select student;
            }

            return query.ToList();
        }

        public List<Student> SearchStudents(string studentID)
        {
            if (studentData == null) return null;

            IEnumerable<Student> query = from student in studentData.StudentDirectory
                                         where student.ID.ToString().Equals(studentID)
                                         select student;
            return query.ToList();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            StudentData Data = StudentData.DeserializeFromXML(); //Gets data's value from deserializing the XML file
        }
    }
}

