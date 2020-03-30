using System;
using System.IO;
using System.Collections.Generic;
namespace HealthInfo
{
    class MainMenu
    {
        public static void MainControlPanel(List<Employee> employeeInfoList)
        {
            while (true)
            {
                Console.WriteLine("---What would you like to do?(Read/Edit/Print/Quit)---");
                string mode = Console.ReadLine();
                switch (mode)
                {
                    case "Read":
                        {
                            Console.WriteLine("---Reading in new employee data---");
                            Operations.ReadInfo(employeeInfoList);
                            break;
                        }
                    case "Edit":
                        {
                            if (employeeInfoList.Count == 0)
                            {
                                Console.WriteLine("---No existing record. Please read in.---");
                            }
                            else
                            {
                                Console.WriteLine("---Editing existing employee data---");
                                Operations.EditInfo(employeeInfoList);
                            }
                            break;
                        }
                    case "Print":
                        {
                            if (employeeInfoList.Count == 0)
                            {
                                Console.WriteLine("---No existing record. Please read in.---");
                            }
                            else
                            {
                                Console.WriteLine("---Printing out data per request---");
                                Operations.PrintInfo(employeeInfoList);
                            }
                            break;
                        }
                    case "Quit":
                        {
                            break;
                        }
                    default:
                        throw new InvalidOperationException();
                }
                if (mode == "Quit")
                {
                    break;
                }
            }
        }
    }

}