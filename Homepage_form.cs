using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Griffindo_toys_system
{
    public partial class Homepage_form : Form
    {
        public Homepage_form()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure, Do you really wanna exit...?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void linkLabelLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure, Do you wanna Logout...?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                Login_form obj = new Login_form();
                obj.Show();
            }
        }

        private void btnEmployeeViewMore_Click(object sender, EventArgs e)
        {
            this.Hide();
            Employee_component obj = new Employee_component();
            obj.Show();
        }

        private void btnSalaryViewMore_Click(object sender, EventArgs e)
        {
            this.Hide();
            Salary_Component obj = new Salary_Component();
            obj.Show();
        }

        private void btnSettingsViewMore_Click(object sender, EventArgs e)
        {
            this.Hide();
            Settings_component obj = new Settings_component();
            obj.Show();
        }
    }
}
