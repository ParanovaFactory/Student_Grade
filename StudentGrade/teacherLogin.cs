using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentGrade
{
    public partial class teacherLogin : Form
    {
        public teacherLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text == "1111")
            {
                TeacherPage teacherPage = new TeacherPage();
                teacherPage.Show();
            }
        }
    }
}
