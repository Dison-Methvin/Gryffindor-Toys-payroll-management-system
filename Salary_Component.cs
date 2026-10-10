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
    
    public partial class Salary_Component : Form
    {
       
        public Salary_Component()
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input data here
                // Check if the salary cycle dates are valid according to the settings
                // Validate other input fields as needed

                // Show confirmation dialog
                DialogResult result = MessageBox.Show("Are you sure you want to save this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    con.Open();

                    // Insert salary details into the database
                    string command = @"INSERT INTO Salary (Salary_Date_Range_Start, Salary_Date_Range_Stop, No_Of_Leaves, No_Of_Absent_Days, No_Of_Holidays, Overtime_Hours, No_Pay_Values, Base_Pay_Values, Gross_Pay_Values, Employee_ID, Setting_ID)
                               VALUES (@StartDate, @StopDate, @Leaves, @AbsentDays, @Holidays, @OvertimeHours, @NoPayValues, @BasePayValues, @GrossPayValues, @EmployeeID, @SettingID)";

                    SqlCommand cmd = new SqlCommand(command, con);
                    cmd.Parameters.AddWithValue("@StartDate", dateTimePickerSalar_date_range_start.Value);
                    cmd.Parameters.AddWithValue("@StopDate", dateTimePickerSalar_date_range_stop.Value);
                    cmd.Parameters.AddWithValue("@Leaves", int.Parse(txtNO_of_leaves.Text));
                    cmd.Parameters.AddWithValue("@AbsentDays", int.Parse(txtNO_Of_Absent_Days.Text));
                    cmd.Parameters.AddWithValue("@Holidays", int.Parse(txtNO_Of_HoliDays.Text));
                    cmd.Parameters.AddWithValue("@OvertimeHours", int.Parse(txtOvertimeHours.Text));
                    cmd.Parameters.AddWithValue("@NoPayValues", int.Parse(txtNOpayValues.Text));
                    cmd.Parameters.AddWithValue("@BasePayValues", int.Parse(txtBasePayValue.Text));
                    cmd.Parameters.AddWithValue("@GrossPayValues", int.Parse(txtGrossPayValue.Text));
                    // Assuming you have employee and settings ID available somewhere in your form
                    cmd.Parameters.AddWithValue("@EmployeeID", int.Parse(txtEmployeeID.Text));
                    cmd.Parameters.AddWithValue("@SettingID", int.Parse(txtSettingsID.Text));

                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Record saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string command1 = "UPDATE Salary SET ('" + txtSalaryID.Text + "','" + txtEmployeeID.Text + "','" + txtSettingsID.Text + "','" + dateTimePickerSalar_date_range_start.Text + "'," +
                    "'" + dateTimePickerSalar_date_range_stop.Text + "', '" + txtNO_of_leaves.Text + "','" + txtNO_Of_Absent_Days.Text + "', '" + txtNO_Of_HoliDays.Text + "', " +
                    "'" + txtOvertimeHours.Text + "', '" + txtNOpayValues.Text + "', '" + txtBasePayValue.Text + "', '" + txtGrossPayValue.Text + "', '" + txtEmployeeID.Text + "'," +
                    " '" + txtSettingsID.Text + "')";

                SqlCommand comm1 = new SqlCommand(command1, con);

                DialogResult = MessageBox.Show("Do you wanna update this record?", "SUCCESS", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.OK)
                {
                    comm1.ExecuteNonQuery();
                    MessageBox.Show("Record updated successfuly!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con.Close();

            }
            catch
            {
                MessageBox.Show("Something went wrong,Please try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {

        }
    }
}
