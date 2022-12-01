using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public interface ISubject
    {
        string name { get; set; }
        string teacher { get; set; }
        List<String> dataList { get; set; }

    }
}
