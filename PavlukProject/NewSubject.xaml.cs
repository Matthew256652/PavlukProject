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
using System.Windows.Shapes;
using ClassLibrary1;
using PavlukProject;
namespace PavlukProject
{
    /// <summary>
    /// Логика взаимодействия для NewSubject.xaml
    /// </summary>
    public partial class NewSubject : Window

    {
        
        public Subject subject1;
        public bool editing;
        public bool creating;
        public NewSubject()
        {
            creating = true;
            InitializeComponent();
            //this.Owner = MainWindow;
        }

        public NewSubject(Subject subject)
        {
            editing = true;
            //Subject subject = new Subject(subjectName, teacherName);
            subject1 = subject;
            SubjName.Text = subject.name;
            SubjTeacher.Text = subject.teacher;
            InitializeComponent();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (creating)
            {
                Subject subject = new Subject(SubjName.Text, SubjTeacher.Text);
                //subject1 = subject;
                MainWindow mainWindow = (MainWindow)this.Owner;
                mainWindow.mainCollection.subjects.Add(subject);
                this.Close();
            }
            if (editing)
            {
                Subject subject = new Subject(SubjName.Text, SubjTeacher.Text);
                MainWindow mainWindow = (MainWindow)this.Owner;
                mainWindow.SubjectList.SelectedItem = subject;
                //mainWindow.mainCollection. = subject;
            }
            
        }
    }
}
