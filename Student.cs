using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDOOP
{
    internal class Student
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Course { get; set; }
        public string Fee { get; set; }

        public void Register(string name, string course, string fee)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=sombordev;Initial Catalog=StudentCRUD;Integrated Security=True;Encrypt=False");
            string query = "insert into Student1(name, course, fee) values ('" + name + "', '" + course + "', '" + fee + "'); select @@identity";
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            int cmd = int.Parse(sqlCommand.ExecuteScalar().ToString());
            sqlConnection.Close();
        }

        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            SqlConnection sqlConnection = new SqlConnection("Data Source=sombordev;Initial Catalog=StudentCRUD;Integrated Security=True;Encrypt=False");
            string query = "select * from Student1";
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Student student = new Student();
                student.StudentID = (int)sqlDataReader["id"];
                student.Name = sqlDataReader["name"].ToString();
                student.Course = sqlDataReader["course"].ToString();
                student.Fee = sqlDataReader["fee"].ToString();

                students.Add(student);
            }


            return students;
        }


    }
}
