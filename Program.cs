using System;
using System.IO;
using System.Collections.Generic;
namespace HealthInfo
{
    class Program
    {
        public void Main()
        {
            string path = "EmployeeData.csv";
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
            List<Employee> employeeInfoList = Operations.ReadData();

            Console.WriteLine($"---Current list contains {employeeInfoList.Count} employee(s)---");

            MainMenu.MainControlPanel(employeeInfoList);

            Console.WriteLine("---Saving all current data---");
            Operations.SaveData(employeeInfoList);
            Console.WriteLine("---Program terminated---");
        }
    }
}