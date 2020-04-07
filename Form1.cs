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
    public partial class Form1 : Form
    {
        EmployeeDict data = new EmployeeDict();
        public Form1()
        {
            InitializeComponent();
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            Employee currentEmployee = new Employee(textBox1.Text, textBox2.Text, double.Parse(textBox3.Text), ( checkBox1.Checked ) ? true : false, ( checkBox2.Checked ) ? true : false);
            data.DataSet.Add(int.Parse(currentEmployee.Gin), currentEmployee);
            MessageBox.Show("New employee added");
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            int currentGin = int.Parse(textBox1.Text);
            if ( data.DataSet.ContainsKey(currentGin) )
            {
                data.DataSet.TryGetValue(currentGin, out Employee target);
                MessageBox.Show("Target employee found"+"\n"+target.ToString());
                EditForm editForm = new EditForm(target);
                editForm.Show();
            }
            else
            {
                MessageBox.Show("Target not found, please double check input gin");
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
                    data.DataSet.Add(int.Parse(values[0]), newEmployee);
                }
                catch { }
            }
            reader.Close();
            MessageBox.Show("Data loaded, please refresh");
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string path = "EmployeeData.csv";
            StreamWriter writer = new StreamWriter(new FileStream(path, FileMode.Create, FileAccess.Write));
            writer.WriteLine("Gin" + "," + "Name" + "," + "Body Temperature" + "," + "Traveled to Hubei" + "," + "Having Symptoms");
            foreach ( KeyValuePair<int, Employee> pair in data.DataSet )
            {
                writer.WriteLine(pair.Value.Gin + "," + pair.Value.Name + "," + pair.Value.BodyTemperature.ToString() + "," + pair.Value.HubeiTravelStatus + "," + pair.Value.UnderTheWeather);
            }
            writer.Flush();
            writer.Close();
            MessageBox.Show("Data saved to csv file");
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void RefreshButton(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            foreach (var currentEmployee in data.DataSet.Values )
            {
                dataGridView1.Rows.Add(currentEmployee.Gin, currentEmployee.Name, currentEmployee.BodyTemperature.ToString(), currentEmployee.HubeiTravelStatus.ToString(),
                    currentEmployee.UnderTheWeather.ToString(), currentEmployee.Alert().ToString());
            }
        }
    }
}
