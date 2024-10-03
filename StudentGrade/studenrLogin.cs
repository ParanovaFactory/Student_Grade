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
    public partial class studenrLogin : Form
    {
        public studenrLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            StudentForm studentForm = new StudentForm();
            studentForm.id = maskedTextBox1.Text;
            studentForm.Show();
            this.Hide();
        }
    }
}
