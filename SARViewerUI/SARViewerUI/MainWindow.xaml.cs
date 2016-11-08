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
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            DisplayResults();
        }
        public void DisplayResults()
        {
            List<Student> studentResults = SearchStudents(tbxFName.Text, tbxLName.Text, tbxStudentID.Text);
            String msg = ValidateSearchResults(studentResults);
            if (!String.IsNullOrEmpty(msg))
            {
                MessageBox.Show(msg, "SARViewerUI");
                grdCourses.Items.Clear();
                return;
            }
            else
            {
                Student s = studentResults[0];
                grdCourses.DataContext = s.CoursesRegistered;
                tbxStudentID.Text = s.ID.ToString();
                tbxFName.Text = s.FirstName;
                tbxLName.Text = s.LastName;

                int coursesTaken = s.CoursesRegistered.Count;
                int coursesWithdrawn = s.CoursesRegistered.Count(c => c.Grade.ToUpper() == "W");
                int coursesIncompleted = s.CoursesRegistered.Count(c => c.Grade.ToUpper() == "I");
                int coursesCompleted = coursesTaken - coursesIncompleted - coursesWithdrawn;


                tbxCoursesTaken.Text = coursesTaken.ToString();
                tbxCoursesWithdrawn.Text = GetPercentage(coursesWithdrawn, coursesTaken).ToString();
                tbxCoursesIncompleted.Text = GetPercentage(coursesIncompleted, coursesTaken).ToString();
                tbxCoursesCompleted.Text = GetPercentage(coursesCompleted, coursesTaken).ToString();
            }
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
                        where student.ID.ToString().Contains(studentID)
                        select student;
            }

            return query.ToList();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            StudentData Data = StudentData.DeserializeFromXML(); //Gets data's value from deserializing the XML file
        }

        private void SetControlAsReadOnly(TextBox textBox)
        {
            textBox.Background = Brushes.LightGray;
            textBox.IsReadOnly = true;
            textBox.BorderThickness = new Thickness(0d);
        }

        private void SetControlAsEditable(TextBox textBox)
        {
            textBox.Background = Brushes.White;
            textBox.IsReadOnly = false;
            textBox.BorderThickness = new Thickness(1d);
        }
    }
}

