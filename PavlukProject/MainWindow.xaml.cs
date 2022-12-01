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
using ClassLibrary1;
using Microsoft.Win32;
using System.Xml;
using System.Xml.Serialization;
namespace PavlukProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainCollection mainCollection = new MainCollection();

        public MainWindow()
        {
            InitializeComponent();
            SubjectList.ItemsSource = mainCollection.subjects;
        }

        private void ListViev_SelectionChanged(object sender, SelectionChangedEventArgs e) //при изменении выбранного
                                                                                           // предмета меняет отображаемые 
        {                                                                                  //данные во второй таблице
            DataCollection datacollection = new DataCollection((Subject)SubjectList.SelectedItem);
            CurrentDataList.ItemsSource = datacollection.dataList;
        }

        private void AddSubject_Click(object sender, RoutedEventArgs e) //добавить новый предмет
        {
            NewSubject newSubject = new NewSubject();
            newSubject.Owner = this;
            newSubject.Show();
        }

        private void DeleteSubject_Click(object sender, RoutedEventArgs e)  //удалить выбранный предмет
        {
            if (SubjectList.SelectedItem != null)
            {
                mainCollection.subjects.Remove((Subject)SubjectList.SelectedItem);
                SubjectList.Items.Refresh();
            }
                

        }

        private void AddData_Click(object sender, RoutedEventArgs e) //добавить файл
        {
            if (SubjectList.SelectedItem != null) { 
                DataCollection datacollection = new DataCollection((Subject)SubjectList.SelectedItem);
                CurrentDataList.ItemsSource = datacollection.dataList;

                Subject subject = (Subject)SubjectList.SelectedItem;

                OpenFileDialog openFileDialog = new OpenFileDialog();

                if (openFileDialog.ShowDialog() == true)
                    subject.dataList.Add(openFileDialog.FileName);

                CurrentDataList.Items.Refresh();
            }

            //subject.dataList.Add("Аааааааааааа");
            //DataCollection datacollection = new DataCollection((Subject)SubjectList.SelectedItem);
            //CurrentDataList.ItemsSource = datacollection.dataList;
            //CurrentDataList.UpdateLayout();
        }

        private void DeleteData_Click(object sender, RoutedEventArgs e) // удалить выбранный файл
        {
            Subject subject = (Subject)SubjectList.SelectedItem;
            if(CurrentDataList.SelectedItem!=null)
                subject.dataList.Remove((String)CurrentDataList.SelectedItem);
            CurrentDataList.Items.Refresh();
        }

        private void SaveData_Click(object sender, RoutedEventArgs e) //сохранить данные в базу
        {
            XmlSerializer xmlWriter = new XmlSerializer(typeof(MainCollection));
            var path = "data.xml";
            System.IO.FileStream file = System.IO.File.Create(path);

            xmlWriter.Serialize(file, mainCollection);
            file.Close();
        }

        private void EditSubject_Click(object sender, RoutedEventArgs e) 
        {
            if (SubjectList.SelectedItem != null)
            {
                NewSubject newSubject = new NewSubject((Subject)SubjectList.SelectedItem);
                newSubject.Owner = this;
                newSubject.Show();
            }
            
        }

        private void LoadData_Click(object sender, RoutedEventArgs e) //загрузить данные из базы
        {
            XmlSerializer xmlReader = new XmlSerializer(typeof(MainCollection));
            var path = "data.xml";
            System.IO.StreamReader file = new System.IO.StreamReader(path);
             mainCollection = (MainCollection)xmlReader.Deserialize(file);
            SubjectList.ItemsSource = mainCollection.subjects;
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e) //заустить выбранный файл
        {
            //System.IO.File
            try
            {
                if (CurrentDataList.SelectedItem != null)
                {
                    System.Diagnostics.Process p = new System.Diagnostics.Process();
                    p.StartInfo.FileName = (String)CurrentDataList.SelectedItem;
                    p.Start();
                }
            }
            catch
            {
                MessageBox.Show("Не удалость открыть файл по данному пути, возможно данный путь более не действителен", "!");
            }
        }

        private void CurrentDataList_DragEnter(object sender, DragEventArgs e) //реализация DragNDrop
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.Copy;
            }
        }
        //реализация DragNDrop
        private void CurrentDataList_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] s = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string ss in s)
                {
                    if (SubjectList.SelectedItem != null)
                    {
                        Subject subject = (Subject)SubjectList.SelectedItem;
                        subject.dataList.Add(ss);
                    }
                    
                    //fileList.AddFile(new MyFile(ss));
                }
                CurrentDataList.Items.Refresh();
            }
        }


        //при двойном нажатии на путь к файлу, файл запустится
        private void CurrentDataList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        { 
            try
            {
                if (CurrentDataList.SelectedItem != null)
                {
                    System.Diagnostics.Process p = new System.Diagnostics.Process();
                    p.StartInfo.FileName = (String)CurrentDataList.SelectedItem;
                    p.Start();
                }
            }
            catch
            {
                MessageBox.Show("Не удалость открыть файл по данному пути, возможно данный путь более не действителен", "!");
            }
        }

        private void ShowTeachers_Click(object sender, RoutedEventArgs e) //притянутое за уши LINQ,
                                                                          //показывает список всех преподователей
        {
            var Teachers = from t in mainCollection.subjects 
                         select t.teacher;
            String str = "Список преподователей: \n";
            foreach (string s in Teachers)
                str += s + "\n";
            MessageBox.Show(str, " Преподователи");
        }
    }
}
