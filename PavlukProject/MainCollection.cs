using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using ClassLibrary1;

namespace PavlukProject
{
    public class MainCollection //главная коллекция, в которой хранятся объекты Subject
    {
        public ObservableCollection<Subject> subjects;
        public List<int> id;
        public MainCollection()
        {
            ObservableCollection<Subject> subjects1 = new ObservableCollection<Subject>();
            subjects = subjects1;
        }
    }
}
