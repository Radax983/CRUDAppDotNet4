using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDOOP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSaveStudentClicked(object sender, EventArgs e)
        {
            Student student = new Student();
            student.Register(txtStudentName.Text, txtStudentCourse.Text, txtStudentFee.Text);
            MessageBox.Show("Record Added");
        }

        private void btnViewStudentClicked(object sender, EventArgs e)
        {
            Student student = new Student();
            List<Student> students = student.GetStudents();
            dataGridView1.DataSource = students;

        }
    }
}
