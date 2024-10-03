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

namespace StudentGrade
{
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
        }

        public string id;

        private void StudentForm_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=PREDATOR;Initial Catalog=StudentGrade;Integrated Security=True;TrustServerCertificate=True");

            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from TblStudentGrades where stdNo = @p1", connection);
            cmd.Parameters.AddWithValue("@p1", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();

            connection.Open();
            SqlCommand cmd2 = new SqlCommand("select stdName,stdSurname,stdNo from TblStudentGrades where stdNo = @p1",connection);
            cmd2.Parameters.AddWithValue("@p1", id);
            SqlDataReader reader = cmd2.ExecuteReader();
            while (reader.Read())
            {
                lblName.Text = reader[0].ToString();
                lblSurname.Text = reader[1].ToString();
                lblNo.Text = reader[2].ToString();
            }
            connection.Close();
        }
    }
}
