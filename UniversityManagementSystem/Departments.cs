using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UniversityManagementSystem
{
    public partial class Departments : Form
    {
        public Departments()
        {
            InitializeComponent();
            ShowDep();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\UniversityOb.mdf;Integrated Security=True;Connect Timeout=30");
        private void ShowDep()
        {
            Con.Open();
            string Query = "select * from DepartmentTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DepDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void Reset()
        {
            DepNameTb.Text = "";
            DepIntakeTb.Text = "";
            DepFeesTb.Text = "";
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (DepNameTb.Text=="" || DepIntakeTb.Text=="" || DepFeesTb.Text=="")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into DepartmentTbl(DepName,DepIntake,DepFees)values(@DN,@DI,@DF)", Con);
                    cmd.Parameters.AddWithValue("@DN", DepNameTb.Text);
                    cmd.Parameters.AddWithValue("@DI", DepIntakeTb.Text);
                    cmd.Parameters.AddWithValue("@DF", DepFeesTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Departments Added");
                    Con.Close();
                    ShowDep();
                    Reset();



                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}
