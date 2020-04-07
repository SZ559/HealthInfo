using System;
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
    public partial class EditForm : Form
    {

        public EditForm(Employee target)
        {
            InitializeComponent();
            label2.Text = target.Gin;
            label3.Text = target.Name;
            label4.Text = target.BodyTemperature.ToString();
            label5.Text = "Been Hubei";
            label5.Text = "Not feeling well";
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void SaveChanges_Click(object sender, EventArgs e)
        {

        }
    }
}
