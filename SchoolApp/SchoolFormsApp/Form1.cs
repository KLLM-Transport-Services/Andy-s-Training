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
using SchoolLibrary;

namespace SchoolFormsApp
{
    public partial class Form1 : Form

    {
        string connectionString = @"Data Source=KLLM-SQLTEST;Initial Catalog=SchoolDB;Integrated Security = SSPI;";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPushToTest_Click(object sender, EventArgs e)
        {
            var testSchool = new School();
            testSchool.Name = txtName.Text;
            testSchool.Address = txtAddress.Text;
            testSchool.City = txtCity.Text;
            testSchool.State = txtState.Text;
            testSchool.Zip = txtZip.Text;
            testSchool.PhoneNumber = txtPhone.Text;
            try
            {
                testSchool.TwitterAddress = txtTwitter.Text;
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            MessageBox.Show(testSchool.ToString());
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand sda = new SqlCommand("Insert Into Schools (SchoolName, SchoolAddress, SchoolCity, SchoolState, SchoolZip, SchoolPhone, SchoolTwitter) " +
                    "Values(@Name,@Address,@City,@State, @Zip,@Phone,@Twitter)", con))
                {
                    sda.Parameters.AddWithValue("@Name", txtName.Text);
                    sda.Parameters.AddWithValue("@Address", txtAddress.Text);
                    sda.Parameters.AddWithValue("@City", txtCity.Text);
                    sda.Parameters.AddWithValue("@State", txtState.Text);
                    sda.Parameters.AddWithValue("@Zip", txtCity.Text);
                    sda.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    sda.Parameters.AddWithValue("@Twitter", txtTwitter.Text);
                    con.Open();
                    sda.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}