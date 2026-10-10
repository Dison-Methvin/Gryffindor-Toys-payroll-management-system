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
    public partial class Settings_component : Form
    {
        public Settings_component()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DISON_PC\\SQLEXPRESS;Initial Catalog=payroll;Integrated Security=True");

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Prompt user with dialog box
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to save this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                // Check user's response
                if (dialogResult == DialogResult.Yes)
                {
                    // Construct SQL INSERT statement
                    string insertQuery = @"INSERT INTO Settings (Setting_ID, Annual_Leave_Days, Goverment_Tax_rate, Salary_Cycle_Days, Salary_Cycle_Start_Date, Salary_Cycle_End_Date, Monthly_Salary) 
                                VALUES (@SettingID, @AnnualLeaveDays, @GovermentTaxRate, @SalaryCycleDays, @SalaryCycleStartDate, @SalaryCycleEndDate, @MonthlySalary)";

                    // Create SQL command with parameters
                    SqlCommand cmd = new SqlCommand(insertQuery, con);
                    cmd.Parameters.AddWithValue("@SettingID", txtSettings_ID.Text);
                    cmd.Parameters.AddWithValue("@AnnualLeaveDays", txtAnualLeaveDays.Text);
                    cmd.Parameters.AddWithValue("@GovermentTaxRate", txtGovermentTaxRate.Text);
                    cmd.Parameters.AddWithValue("@SalaryCycleDays", txtSalaryCycleDays.Text);
                    cmd.Parameters.AddWithValue("@SalaryCycleStartDate", dateTimePickerSalaeyCycleStartDate.Value.Date);
                    cmd.Parameters.AddWithValue("@SalaryCycleEndDate", dateTimePickerSalaryCycleStopDate.Value.Date);
                    cmd.Parameters.AddWithValue("@MonthlySalary", txtMonthlySalary.Text);

                    // Open connection
                    con.Open();

                    // Execute the query
                    cmd.ExecuteNonQuery();

                    // Close connection
                    con.Close();

                    MessageBox.Show("Record saved successfully!");
                }
                else
                {
                    // User canceled, do nothing
                    MessageBox.Show("Record not saved.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message);
            }
        }

        private void UpdateData(int settingID, int annualLeaveDays, int governmentTaxRate, int salaryCycleDays, DateTime salaryCycleStartDate, DateTime salaryCycleEndDate, int monthlySalary)
        {
            try
            {
                // Construct SQL UPDATE statement
                string updateQuery = @"UPDATE Settings 
                               SET Annual_Leave_Days = @AnnualLeaveDays, Goverment_Tax_rate = @GovermentTaxRate, 
                                   Salary_Cycle_Days = @SalaryCycleDays, Salary_Cycle_Start_Date = @SalaryCycleStartDate, 
                                   Salary_Cycle_End_Date = @SalaryCycleEndDate, Monthly_Salary = @MonthlySalary
                               WHERE Setting_ID = @SettingID";

                // Create SQL command with parameters
                SqlCommand cmd = new SqlCommand(updateQuery, con);
                cmd.Parameters.AddWithValue("@SettingID", settingID);
                cmd.Parameters.AddWithValue("@AnnualLeaveDays", annualLeaveDays);
                cmd.Parameters.AddWithValue("@GovermentTaxRate", governmentTaxRate);
                cmd.Parameters.AddWithValue("@SalaryCycleDays", salaryCycleDays);
                cmd.Parameters.AddWithValue("@SalaryCycleStartDate", salaryCycleStartDate);
                cmd.Parameters.AddWithValue("@SalaryCycleEndDate", salaryCycleEndDate);
                cmd.Parameters.AddWithValue("@MonthlySalary", monthlySalary);

                // Open connection
                con.Open();

                // Execute the query
                cmd.ExecuteNonQuery();

                // Close connection
                con.Close();

                var result = MessageBox.Show("Record updated successfuly", "Successful!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message);
            }
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                // Construct SQL SELECT statement to retrieve data based on Setting ID
                string selectQuery = @"SELECT * FROM Settings WHERE Setting_ID = @SettingID";

                // Create SQL command with parameters
                SqlCommand cmd = new SqlCommand(selectQuery, con);
                cmd.Parameters.AddWithValue("@SettingID", txtSettings_ID.Text);

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
                    txtAnualLeaveDays.Text = reader["Annual_Leave_Days"].ToString();
                    txtGovermentTaxRate.Text = reader["Goverment_Tax_rate"].ToString();
                    txtSalaryCycleDays.Text = reader["Salary_Cycle_Days"].ToString();
                    dateTimePickerSalaeyCycleStartDate.Value = Convert.ToDateTime(reader["Salary_Cycle_Start_Date"]);
                    dateTimePickerSalaryCycleStopDate.Value = Convert.ToDateTime(reader["Salary_Cycle_End_Date"]);
                    txtMonthlySalary.Text = reader["Monthly_Salary"].ToString();

                    // Close reader
                    reader.Close();
                }
                else
                {
                    MessageBox.Show("Setting ID not found.");
                }

                // Close connection
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Open connection
                con.Open();

                // Construct SQL DELETE statement
                string deleteQuery = "DELETE FROM Settings WHERE Setting_ID = @SettingID";

                // Create SQL command with parameters
                SqlCommand cmd = new SqlCommand(deleteQuery, con);
                cmd.Parameters.AddWithValue("@SettingID", txtSettings_ID.Text);

                // Prompt user with dialog box
                DialogResult dialogResult = MessageBox.Show("Do you really want to delete this record?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                // Check user's response
                if (dialogResult == DialogResult.OK)
                {
                    // Execute the delete query
                    cmd.ExecuteNonQuery();

                    // Clear textboxes
                    txtSettings_ID.Text = "";
                    txtAnualLeaveDays.Text = "";
                    txtGovermentTaxRate.Text = "";
                    txtSalaryCycleDays.Text = "";
                    dateTimePickerSalaeyCycleStartDate.Value = DateTime.Now; // Reset DateTimePicker to current date
                    dateTimePickerSalaryCycleStopDate.Value = DateTime.Now; // Reset DateTimePicker to current date
                    txtMonthlySalary.Text = "";

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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    // Prompt user with dialog box
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to update this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    // Check user's response
                    if (dialogResult == DialogResult.Yes)
                    {
                        // User confirmed, proceed with updating data
                        UpdateData(Convert.ToInt32(txtSettings_ID.Text), Convert.ToInt32(txtAnualLeaveDays.Text), Convert.ToInt32(txtGovermentTaxRate.Text),
                                   Convert.ToInt32(txtSalaryCycleDays.Text), dateTimePickerSalaeyCycleStartDate.Value.Date,
                                   dateTimePickerSalaryCycleStopDate.Value.Date, Convert.ToInt32(txtMonthlySalary.Text));
                    }
                    else
                    {
                        // User canceled, do nothing
                        MessageBox.Show("Record not updated.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occurred: " + ex.Message);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSettings_ID.Text = "";
            txtAnualLeaveDays.Text = "";
            txtGovermentTaxRate.Text = "";
            txtSalaryCycleDays.Text = "";
            dateTimePickerSalaeyCycleStartDate.Value = DateTime.Now; // Reset DateTimePicker to current date
            dateTimePickerSalaryCycleStopDate.Value = DateTime.Now; // Reset DateTimePicker to current date
            txtMonthlySalary.Text = "";
        }

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
    }
}
