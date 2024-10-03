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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            studenrLogin studenrLogin = new studenrLogin();
            studenrLogin.Show();
        }

        private void btnTeacher_Click(object sender, EventArgs e)
        {
            teacherLogin teacherLogin = new teacherLogin();
            teacherLogin.Show();
        }
    }
}
