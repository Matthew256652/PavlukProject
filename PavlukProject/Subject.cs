using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
namespace PavlukProject
{
    public class Subject : ISubject //класс Предмет
    {
        public Subject(string Name, string Teacher, List<string> DataList)  //параметрический конструктор
        {
            name = Name;            
            teacher = Teacher;      
            dataList = DataList;    
        }
        public Subject(string Name, string Teacher)     //параметрический конструктор
        {
            name = Name;
            teacher = Teacher;
            List<string> dataList1 = new List<string>();
            dataList = dataList1;
        }

        public Subject() //безпараметрический конструктор
        {

        }
        public string name { get; set; }            //название
        public string teacher { get; set; }         //имя преподователя
        public List<string> dataList { get; set; }  //список путей к файлам по этому предмету


    }
}
