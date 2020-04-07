using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthInfo
{
    class EmployeeDict
    {
        private SortedDictionary<int, Employee> dataSet = new SortedDictionary<int, Employee>();
        public SortedDictionary<int, Employee> DataSet
        {
            get
            {
                return dataSet;
            }
            set
            {
                dataSet = value;
            }
        }
    }
}
