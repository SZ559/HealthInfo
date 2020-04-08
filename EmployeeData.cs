using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthInfo
{
    public class EmployeeData
    {
        private SortedDictionary<int, Employee> dataDict = new SortedDictionary<int, Employee>();
        public SortedDictionary<int, Employee> DataDict
        {
            get
            {
                return dataDict;
            }
            set
            {
                dataDict = value;
            }
        }
        public void AddNew(Employee employee)
        {
            try { dataDict.Remove(int.Parse(employee.Gin)); }
            catch { }
            finally { dataDict.Add(int.Parse(employee.Gin), employee); }
        }
    }
}
