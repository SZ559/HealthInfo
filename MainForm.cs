using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthInfo
{
    public partial class MainForm : Form
    {
        EmployeeData data = new EmployeeData();
        
        public MainForm()
        {
            InitializeComponent();
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            SubForm editForm = new SubForm(this, null, "add");
            editForm.Show();
        }
        public void MainGetValue(Employee employee, string option)
        {
            switch ( option )
            {
                case "Edit": data.AddNew(employee); break;
                case "Delete": data.DataDict.Remove(int.Parse(employee.Gin)); break;
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            int currentGin = int.Parse(textBox1.Text);
            try 
            {
                Employee employee = data.DataDict[currentGin];
                MessageBox.Show("Target employee found" + "\n" + employee.ToString());
                SubForm editForm = new SubForm(this, employee, "Modify");
                editForm.Show();
            }
            catch 
            { 
                MessageBox.Show("No corresponding record."); 
            }
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            string path = "EmployeeData.csv";
            if ( !File.Exists(path) )
            {
                File.Create(path).Close();
            }
            StreamReader reader = new StreamReader(path);
            while ( !reader.EndOfStream )
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                try
                {
                    Employee newEmployee = new Employee(values[0], values[1], Convert.ToDouble(values[2]), Convert.ToBoolean(values[3]), Convert.ToBoolean(values[4]));
                    data.AddNew(newEmployee);
                }
                catch { }
            }
            reader.Close();
            RefreshButton_Click(sender, e);
            MessageBox.Show("Data loaded");
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string path = "EmployeeData.csv";
            StreamWriter writer = new StreamWriter(new FileStream(path, FileMode.Create, FileAccess.Write));
            writer.WriteLine("Gin" + "," + "Name" + "," + "Body Temperature" + "," + "Traveled to Hubei" + "," + "Having Symptoms");
            foreach ( var employee in data.DataDict.Values )
            {
                writer.WriteLine(employee.Gin + "," + employee.Name + "," + employee.BodyTemperature.ToString() + "," + employee.HubeiTravelStatus + "," + employee.UnderTheWeather);
            }
            writer.Flush();
            writer.Close();
            MessageBox.Show("Data saved to csv file");
        }
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            foreach ( var currentEmployee in data.DataDict.Values )
            {
                dataGridView1.Rows.Add(currentEmployee.Gin, currentEmployee.Name, currentEmployee.BodyTemperature.ToString(), currentEmployee.HubeiTravelStatus.ToString(),currentEmployee.UnderTheWeather.ToString(), currentEmployee.Alert().ToString());
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
