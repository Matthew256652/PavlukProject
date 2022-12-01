using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace PavlukProject
{
    class DataCollection
    {
        public List<String> dataList;

        public DataCollection(Subject subject)
        {
            if(subject!=null)
                dataList = subject.dataList;
        }
    }
}
