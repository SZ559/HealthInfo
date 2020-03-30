using System;
using System.IO;
using System.Collections.Generic;
namespace HealthInfo
{
    class Operations
    {
        public static void ReadInfo(List<Employee> employeeInfoList)
        {
            while (true)
            {
                Console.WriteLine("---Please enter new employee's information suggested below, seperated by comma---");
                Console.WriteLine("---Gin Number, Name, Body Temperature, Traveled to Hubei(true/false), Having symptoms(true/false)---");
                string currentInformation = Console.ReadLine();
                try
                {
                    Employee newEmployee = new Employee(currentInformation.Split(",")[0], currentInformation.Split(",")[1], Convert.ToDouble(currentInformation.Split(",")[2]), Convert.ToBoolean(currentInformation.Split(",")[3]), Convert.ToBoolean(currentInformation.Split(",")[4]));
                    int i = -1;
                    Console.WriteLine("---Searching existing records---");
                    foreach (var employee in employeeInfoList)
                    {
                        if (employee.Gin == currentInformation.Split(",")[0])
                        {
                            i = employeeInfoList.IndexOf(employee);
                            Console.WriteLine("---Record exists, please check your gin number---");
                            break;
                        }
                    }
                    if (i == -1)
                    {
                        employeeInfoList.Add(newEmployee);
                        Console.WriteLine("---New record added---");
                    }
                }
                catch
                {
                    Console.WriteLine("---Wrong input format, please carefully examine your information---");
                }

                Console.WriteLine("---Would you like to enter another employee's information?(Yes/No)---");
                string handle = Console.ReadLine();
                if (handle == "No")
                {
                    Console.WriteLine("---Returning to main menu---");
                    break;
                }
            }
        }
        public static void EditInfo(List<Employee> employeeInfoList)
        {
            while (true)
            {
                Console.WriteLine("---Please enter target employee's gin number to proceed---");
                string currentGinNumber = Console.ReadLine();
                int i = -1;
                Console.WriteLine("---Searching existing records---");
                foreach (var employee in employeeInfoList)
                {
                    if (employee.Gin == currentGinNumber)
                    {
                        i = employeeInfoList.IndexOf(employee);
                        break;
                    }
                }
                if (i == -1)
                {
                    Console.WriteLine("---No corresponding record. Please double check.---");
                }
                else
                {

                    Console.WriteLine("---Current employee information---");
                    Console.WriteLine($"---Gin {employeeInfoList[i].Gin}, Name {employeeInfoList[i].Name}, Body Temperature {employeeInfoList[i].BodyTemperature}---");
                    Console.WriteLine($"---Traveled to Hubei? { employeeInfoList[i].HubeiTravelStatus.ToString()}, Having symptoms? { employeeInfoList[i].UnderTheWeather.ToString()}---");
                    Console.WriteLine("---What option would you like to proceed?(Edit/Delete/Quit)---");
                    string option = Console.ReadLine();
                    switch (option)
                    {
                        case "Edit":
                            {
                                while (true)
                                {
                                    Console.WriteLine("---Please enter the field you would like to edit.(Gin/Name/Temperature/Hubei/Symptom)---");
                                    string field = Console.ReadLine();
                                    switch (field)
                                    {
                                        case "Gin":
                                            {
                                                Console.WriteLine($"---Please enter updated gin number. (Current gin {employeeInfoList[i].Gin})---");
                                                employeeInfoList[i].Gin = Console.ReadLine();
                                                Console.WriteLine($"---Gin number updated: {employeeInfoList[i].Gin}---");
                                                break;
                                            }
                                        case "Name":
                                            {
                                                Console.WriteLine($"---Please enter updated name. (Current name {employeeInfoList[i].Name})---");
                                                employeeInfoList[i].Name = Console.ReadLine();
                                                Console.WriteLine($"---Employee name updated: {employeeInfoList[i].Name}---");
                                                break;
                                            }
                                        case "Temperature":
                                            {
                                                Console.WriteLine($"---Please enter updated body temperature. (Current gin {employeeInfoList[i].BodyTemperature})---");
                                                employeeInfoList[i].BodyTemperature = Convert.ToDouble(Console.ReadLine());
                                                Console.WriteLine($"---Body temperature updated: {employeeInfoList[i].BodyTemperature}---");
                                                break;
                                            }
                                        case "Hubei":
                                            {
                                                Console.WriteLine($"---Please enter updated status of Hubei traveling(true/false). (Current status {employeeInfoList[i].HubeiTravelStatus})---");
                                                employeeInfoList[i].HubeiTravelStatus = Convert.ToBoolean(Console.ReadLine());
                                                Console.WriteLine($"---Hubei Travel Status updated: {employeeInfoList[i].HubeiTravelStatus}---");
                                                break;
                                            }
                                        case "Symptom":
                                            {
                                                Console.WriteLine($"---Please enter updated symtoms status of employee(true/false). (Current gin {employeeInfoList[i].UnderTheWeather})---");
                                                employeeInfoList[i].UnderTheWeather = Convert.ToBoolean(Console.ReadLine());
                                                Console.WriteLine($"---Gin number updated: {employeeInfoList[i].UnderTheWeather}---");
                                                break;
                                            }
                                        default: throw new InvalidOperationException();
                                    }
                                    Console.WriteLine("---Edit other fields under the same record?(Yes/No)---");
                                    string confirmation = Console.ReadLine();
                                    if (confirmation == "No")
                                    {
                                        break;
                                    }
                                }
                                break;
                            }
                        case "Delete":
                            {
                                Console.WriteLine($"---Are you sure about deleting {employeeInfoList[i].Name}'s record?(Yes/No)---");
                                string confirmation = Console.ReadLine();
                                if (confirmation == "Yes")
                                {
                                    employeeInfoList.Remove(employeeInfoList[i]);
                                    Console.WriteLine("---Record Deleted---");
                                }
                                break;
                            }
                        case "Quit":
                            {
                                break;
                            }
                        default: throw new InvalidOperationException();
                    }
                }
                Console.WriteLine("---Would you like to edit another employee's information?(Yes/No)---");
                string handle = Console.ReadLine();
                if (handle == "No")
                {
                    Console.WriteLine("---Returning to main menu---");
                    break;
                }
            }

        }
        public static void PrintInfo(List<Employee> employeeInfoList)
        {
            while (true)
            {
                Console.WriteLine("---Please enter any printing option(All/Single/Alerted/Quit)---");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "All":
                        {
                            Console.WriteLine("---Printing all existing records---");
                            foreach (var employee in employeeInfoList)
                            {
                                Console.WriteLine($"---Gin {employee.Gin}, Name {employee.Name}, Body Temperature {employee.BodyTemperature}Traveled to Hubei? { employee.HubeiTravelStatus.ToString()}. Having symptoms? { employee.UnderTheWeather.ToString()}---");
                            }
                            Console.WriteLine("---Print complete---");
                            break;
                        }
                    case "Single":
                        {
                            while (true)
                            {
                                Console.WriteLine("---Please enter target employee's gin number to proceed---");
                                string currentGinNumber = Console.ReadLine();
                                int i = -1;
                                Console.WriteLine("---Searching existing records---");
                                foreach (var employee in employeeInfoList)
                                {
                                    if (employee.Gin == currentGinNumber)
                                    {
                                        i = employeeInfoList.IndexOf(employee);
                                        break;
                                    }
                                }
                                if (i == -1)
                                {
                                    Console.WriteLine("---No corresponding record. Please double check.---");
                                }
                                else
                                {
                                    Console.WriteLine("---Current employee information---");
                                    Console.WriteLine($"---Gin {employeeInfoList[i].Gin}, Name {employeeInfoList[i].Name}, Body Temperature {employeeInfoList[i].BodyTemperature} Traveled to Hubei? { employeeInfoList[i].HubeiTravelStatus.ToString()}. Having symptoms? { employeeInfoList[i].UnderTheWeather.ToString()}---");
                                }
                                Console.WriteLine("---Print another single task?(Yes/No)---");
                                string confirmation = Console.ReadLine();
                                if (confirmation == "No")
                                {
                                    break;
                                }
                            }
                            break;
                        }
                    case "Alerted":
                        {
                            Console.WriteLine("---Printing all alerted records---");
                            foreach (var employee in employeeInfoList)
                            {
                                if (employee.Alert())
                                {
                                    Console.WriteLine($"---Gin {employee.Gin}, Name {employee.Name}, Body Temperature {employee.BodyTemperature}, Traveled to Hubei? { employee.HubeiTravelStatus.ToString()}. Having symptoms? { employee.UnderTheWeather.ToString()}---");
                                }
                            }
                            Console.WriteLine("---Print complete---");
                            break;
                        }
                    case "Quit":
                        {
                            break;
                        }
                    default: throw new InvalidOperationException();
                }
                Console.WriteLine("---Any other printing tasks?(Yes/No)---");
                string handle = Console.ReadLine();
                if (handle == "No")
                {
                    break;
                }
            }
        }
        public static void SaveData(List<Employee> employeeInfoList)
        {
            string path = "EmployeeData.csv";
            StreamWriter writer = new StreamWriter(new FileStream(path, FileMode.Create, FileAccess.Write));
            writer.WriteLine("Gin" + "," + "Name" + "," + "Body Temperature" + "," + "Traveled to Hubei" + "," + "Having Symptoms");
            for (int i = 0; i < employeeInfoList.Count; i += 1)
            {
                writer.WriteLine(employeeInfoList[i].Gin + "," + employeeInfoList[i].Name + "," + employeeInfoList[i].BodyTemperature.ToString() + "," + employeeInfoList[i].HubeiTravelStatus + "," + employeeInfoList[i].UnderTheWeather);
            }
            writer.Flush();
            writer.Close();
        }
        public static List<Employee> ReadData()
        {
            List<Employee> employeeInfoList = new List<Employee>();
            string path = "EmployeeData.csv";
            StreamReader reader = new StreamReader(path);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(",");
                try
                {
                    Employee newEmployee = new Employee(values[0], values[1], Convert.ToDouble(values[2]), Convert.ToBoolean(values[3]), Convert.ToBoolean(values[4]));
                    employeeInfoList.Add(newEmployee);
                }
                catch { }
            }
            reader.Close();
            return employeeInfoList;
        }
    }
}