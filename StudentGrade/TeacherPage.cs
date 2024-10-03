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
    public partial class TeacherPage : Form
    {
        public TeacherPage()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(@"Data Source=PREDATOR;Initial Catalog=StudentGrade;Integrated Security=True;TrustServerCertificate=True");

        void list()
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from TblStudentGrades", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
        }

        private void TeacherPage_Load(object sender, EventArgs e)
        {
            list();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            decimal avg = (decimal.Parse(txtExam1.Text) + decimal.Parse(txtExam2.Text) + decimal.Parse(txtExam3.Text)) / 3;
            connection.Open();
            SqlCommand cmd = new SqlCommand("insert into TblStudentGrades (stdNo,stdName,stdSurname,stdLecture,stdExam1,stdExam2,stdExam3,stdAverage,stdStatus) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", connection);
            cmd.Parameters.AddWithValue("@p1", txtNumber.Text);
            cmd.Parameters.AddWithValue("@p2", txtName.Text);
            cmd.Parameters.AddWithValue("@p3", txtSurname.Text);
            cmd.Parameters.AddWithValue("@p4", txtLecture.Text);
            cmd.Parameters.AddWithValue("@p5", decimal.Parse(txtExam1.Text));
            cmd.Parameters.AddWithValue("@p6", decimal.Parse(txtExam2.Text));
            cmd.Parameters.AddWithValue("@p7", decimal.Parse(txtExam3.Text));
            cmd.Parameters.AddWithValue("@p8", avg);
            if (avg >= 50)
            {
                cmd.Parameters.AddWithValue("@p9", 1);
            }
            else
            {
                cmd.Parameters.AddWithValue("@p9", 0);
            }
            cmd.ExecuteNonQuery();
            connection.Close();
            list();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            decimal avg = (decimal.Parse(txtExam1.Text) + decimal.Parse(txtExam2.Text) + decimal.Parse(txtExam3.Text)) / 3;
            connection.Open();
            SqlCommand cmd = new SqlCommand("update TblStudentGrades set stdExam1=@p1,stdExam2=@p2,stdExam3=@p3,stdAverage=@p4,stdStatus=@p5 where stdId = @p6", connection);
            cmd.Parameters.AddWithValue("@p1", decimal.Parse(txtExam1.Text));
            cmd.Parameters.AddWithValue("@p2", decimal.Parse(txtExam2.Text));
            cmd.Parameters.AddWithValue("@p3", decimal.Parse(txtExam3.Text));
            cmd.Parameters.AddWithValue("@p4", avg);
            if (avg >= 50)
            {
                cmd.Parameters.AddWithValue("@p5", 1);
            }
            else
            {
                cmd.Parameters.AddWithValue("@p5", 0);
            }
            cmd.Parameters.AddWithValue("@p6", lblId.Text);
            cmd.ExecuteNonQuery();
            connection.Close();
            list();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("delete from TblStudentGrades where stdId = @p1", connection);
            cmd.Parameters.AddWithValue("@p1", lblId.Text);
            cmd.ExecuteNonQuery();
            connection.Close();
            list();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSurname.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtNumber.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtLecture.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtExam1.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtExam2.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtExam3.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            lblId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
    }
}
