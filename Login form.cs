using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Griffindo_toys_system
{
    public partial class Login_form : Form
    {
        public Login_form()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DISON_PC\\SQLEXPRESS;Initial Catalog=payroll;Integrated Security=True");

        private void btnExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure, Do you really wanna exit...?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 obj = new Form1();
            obj.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            con.Open();
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            string query_select = "SELECT * FROM LoginDetails WHERE username = '" + username + "' AND password = '" + password + "'";
            SqlCommand cmnd = new SqlCommand(query_select, con);
            SqlDataReader row = cmnd.ExecuteReader();

            if (row.HasRows)
            {
                this.Hide();
                Homepage_form obj = new Homepage_form();
                obj.Show();
            }
            else
            {
                MessageBox.Show("Inavlid sign in credentials, Please check username and password and try again !", "Invalid signin details", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
    }
}
