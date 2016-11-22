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

        private void tbxStudentID_KeyDownHandler(object sender, KeyEventArgs e)//activated when the user presses a button
        {
            
            if (e.Key == Key.Return)//display results is prompted when the user hits the enter key
            {
                DisplayResults(true);

            }
        }

        public void btnSearch_Click(object sender, RoutedEventArgs e)//prompts when the user clicks the search button
        {
            DisplayResults();
        }

        public void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearScreen();//when the clear button is pressed ClearScreen() is prompted and clears out the screen and search bars
        }

        public void DisplayResults(bool useStudentID = false)//prompted when the user hits enter or clicks the search button
        {
            List<Student> studentResults = useStudentID ? SearchStudents(tbxStudentID.Text) :SearchStudents(tbxFName.Text, tbxLName.Text, tbxStudentID.Text);
            String msg = ValidateSearchResults(studentResults);//validates the information of the student
            if (!String.IsNullOrEmpty(msg))//prompts if no information is found
            {
                MessageBox.Show(msg, "SARViewerUI");
                ClearScreen();
                return;
            }
            else
            {//when a student is found it gathers the information and puts it into the query
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

                tbxCoursesCompleted.Text = coursesCompleted.ToString();//shows courses complete
                tbxCoreCompleted.Text = GetPercentage(CoreCompleted, coursesTaken).ToString();//gets percetn of core courses completed
                tbxGenEdCompleted.Text = GetPercentage(GenEdCompleted, coursesTaken).ToString();//gets percent of gen ed courses completed
                tbxElectiveCompleted.Text = GetPercentage(ElectCompleted, coursesTaken).ToString();//gets percent of elective courses completed
            }
        }

        public void ClearScreen()//class which clears the screen when needed
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

        public decimal GetPercentage(int part, int whole)//gathers the percent of the courses
        {
            return Decimal.Round((part / Convert.ToDecimal(whole) * 100), 2);
        }

        public string ValidateSearchResults(List<Student> students)//used to validate student info prompts if student is not found or multiple are found
        {
            if (studentData == null) return "Data file could not be found or loaded.";
            if (students == null || students.Count == 0) return String.Format(SARViewer.Strings.No_Students_Found_0_1, tbxFName.Text, tbxLName.Text);
            else if (students.Count > 1) return SARViewer.Strings.Returned_More_Than_One_Student;
            return String.Empty;
        }

        public List<Student> SearchStudents(string FName, string LName, string studentID = "")//puts student information into list to be displayed to user
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

        public List<Student> SearchStudents(string studentID)//searches for student
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

        private void btnReportGen_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

