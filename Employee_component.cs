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

namespace Griffindo_toys_system
{
    public partial class Employee_component : Form
    {
        public Employee_component()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DISON_PC\\SQLEXPRESS;Initial Catalog=payroll;Integrated Security=True");

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Homepage_form obj = new Homepage_form();
            obj.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure, Do you really wanna exit...?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }



        private void UpdateData(string employeeID, string firstName, string lastName, string nic, int monthlySalary, int overtimeRate, int allowances, string houseNO, string laneName, string city, string notes, string email, string contactNo)
        {
            try
            {
                // Construct SQL UPDATE statement
                string updateQuery = @"UPDATE Employee 
                               SET F_name = @FirstName, L_name = @LastName, NIC = @NIC, 
                                   Monthly_Salary = @MonthlySalary, Overtime_Rate = @OvertimeRate, Allowances = @Allowances, 
                                   House_NO = @HouseNO, Lane_Name = @LaneName, City = @City, Note = @Notes,
                                   Email = @Email1, ContactNo = @ContactNo1
                               WHERE Employee_ID = @EmployeeID";

                // Create SQL command with parameters
                SqlCommand cmd = new SqlCommand(updateQuery, con);
                cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@NIC", nic);
                cmd.Parameters.AddWithValue("@MonthlySalary", monthlySalary);
                cmd.Parameters.AddWithValue("@OvertimeRate", overtimeRate);
                cmd.Parameters.AddWithValue("@Allowances", allowances);
                cmd.Parameters.AddWithValue("@HouseNO", houseNO);
                cmd.Parameters.AddWithValue("@LaneName", laneName);
                cmd.Parameters.AddWithValue("@City", city);
                cmd.Parameters.AddWithValue("@Notes", notes);
                cmd.Parameters.AddWithValue("@Email1", email);
                cmd.Parameters.AddWithValue("@ContactNo1", contactNo);

                // Open connection
                con.Open();

                // Execute the query
                cmd.ExecuteNonQuery();

                // Close connection
                con.Close();

                MessageBox.Show("Record updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Prompt user with dialog box
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to update this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            // Check user's response
            if (dialogResult == DialogResult.Yes)
            {
                // User confirmed, proceed with updating data
                UpdateData(txtEmployeeID.Text, txtFirstName.Text, txtLastName.Text, txtNIC.Text,
                           Convert.ToInt32(txtMonthlySalary.Text), Convert.ToInt32(txtOvertimeRate.Text), Convert.ToInt32(txtAllowences.Text),
                           txtHomeNO.Text, txtLaneName.Text, txtCity.Text, txtNotes.Text, txtEmail1.Text, txtContactNO1.Text);
            }
            else
            {
                // User canceled, do nothing
                MessageBox.Show("Record not updated.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Open connection
                con.Open();

                // Construct SQL DELETE statement
                string deleteQuery = "DELETE FROM Employee WHERE Employee_ID = @EmployeeID";

                // Create SQL command with parameters
                SqlCommand cmd = new SqlCommand(deleteQuery, con);
                cmd.Parameters.AddWithValue("@EmployeeID", txtEmployeeID.Text);

                // Prompt user with dialog box
                DialogResult dialogResult = MessageBox.Show("Do you really want to delete this record?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                // Check user's response
                if (dialogResult == DialogResult.OK)
                {
                    // Execute the delete query
                    cmd.ExecuteNonQuery();

                    // Clear textboxes
                    txtEmployeeID.Text = "";
                    txtFirstName.Text = "";
                    txtLastName.Text = "";
                    txtNIC.Text = "";
                    txtEmail1.Text = "";
                    txtContactNO1.Text = "";
                    txtHomeNO.Text = "";
                    txtLaneName.Text = "";
                    txtCity.Text = "";
                    txtMonthlySalary.Text = "";
                    txtOvertimeRate.Text = "";
                    txtAllowences.Text = "";
                    txtNotes.Text = "";

                    // Enable save button
                    btnSave.Enabled = true;

                    MessageBox.Show("Record deleted successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Close connection
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close(); // Ensure connection is closed in case of exception
            }
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            txtEmployeeID.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtNIC.Text = "";
            txtEmail1.Text = "";
            txtContactNO1.Text = "";
            txtHomeNO.Text = "";
            txtLaneName.Text = "";
            txtCity.Text = "";
            txtMonthlySalary.Text = "";
            txtOvertimeRate.Text = "";
            txtAllowences.Text = "";
            txtNotes.Text = "";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                // Construct SQL SELECT statement to retrieve data based on Employee ID
                string selectQuery = @"SELECT * FROM Employee WHERE Employee_ID = @EmployeeID";

                // Create SQL command with parameters
                SqlCommand cmd = new SqlCommand(selectQuery, con);
                cmd.Parameters.AddWithValue("@EmployeeID", txtEmployeeID.Text);

                // Open connection
                con.Open();

                // Execute the query and retrieve data
                SqlDataReader reader = cmd.ExecuteReader();

                // Check if any data is retrieved
                if (reader.HasRows)
                {
                    // Read the first row
                    reader.Read();

                    // Populate textboxes with retrieved values
                    txtFirstName.Text = reader["F_name"].ToString();
                    txtLastName.Text = reader["L_name"].ToString();
                    txtNIC.Text = reader["NIC"].ToString();
                    txtMonthlySalary.Text = reader["Monthly_Salary"].ToString();
                    txtOvertimeRate.Text = reader["Overtime_Rate"].ToString();
                    txtAllowences.Text = reader["Allowances"].ToString();
                    txtHomeNO.Text = reader["House_NO"].ToString();
                    txtLaneName.Text = reader["Lane_Name"].ToString();
                    txtCity.Text = reader["City"].ToString();
                    txtNotes.Text = reader["Note"].ToString();
                    txtEmail1.Text = reader["Email"].ToString();
                    txtContactNO1.Text = reader["ContactNO"].ToString();

                    // Close reader
                    reader.Close();
                }
                else
                {
                    MessageBox.Show("Employee ID not found.");
                }

                // Close connection
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Prompt user with dialog box
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to save this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            // Check user's response
            if (dialogResult == DialogResult.Yes)
            {
                // User confirmed, proceed with inserting data
                try
                {
                    // Construct SQL INSERT statement
                    string insertQuery = @"INSERT INTO Employee (Employee_ID, F_name, L_name, NIC, Monthly_Salary, Overtime_Rate, Allowances, House_NO, Lane_Name, City, Note, Email, ContactNo) 
                             VALUES (@EmployeeID, @FirstName, @LastName, @NIC, @MonthlySalary, @OvertimeRate, @Allowances, @HouseNO, @LaneName, @City, @Notes, @Email, @ContactNo)";

                    // Create SQL command with parameters
                    SqlCommand cmd = new SqlCommand(insertQuery, con);
                    cmd.Parameters.AddWithValue("@EmployeeID", txtEmployeeID.Text);
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@NIC", txtNIC.Text);
                    cmd.Parameters.AddWithValue("@MonthlySalary", Convert.ToInt32(txtMonthlySalary.Text));
                    cmd.Parameters.AddWithValue("@OvertimeRate", Convert.ToInt32(txtOvertimeRate.Text));
                    cmd.Parameters.AddWithValue("@Allowances", Convert.ToInt32(txtAllowences.Text));
                    cmd.Parameters.AddWithValue("@HouseNO", txtHomeNO.Text);
                    cmd.Parameters.AddWithValue("@LaneName", txtLaneName.Text);
                    cmd.Parameters.AddWithValue("@City", txtCity.Text);
                    cmd.Parameters.AddWithValue("@Notes", txtNotes.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail1.Text);
                    cmd.Parameters.AddWithValue("@ContactNo", txtContactNO1.Text);

                    // Open connection
                    con.Open();

                    // Execute the query
                    cmd.ExecuteNonQuery();

                    // Close connection
                    con.Close();

                    MessageBox.Show("Record saved successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occurred: " + ex.Message);
                }
            }
            else
            {
                // User canceled, do nothing
                MessageBox.Show("Record not saved.");
            }
        }

    }

}
