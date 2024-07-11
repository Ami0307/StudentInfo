using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private string connectionString;
        private Student currentStudent = null;

        public Form1()
        {
            InitializeComponent();
            string path = Directory.GetCurrentDirectory();
            this.connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + path +
  "\\student.mdf;Integrated Security=True;Connect Timeout=30";
            LoadData();
        }

        private void LoadData()
        {
            StudentsList.Items.Clear();
            ProgramsBox.Items.Clear();

            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {
                myConnection.Open();

                // Load Students
                string sql = "SELECT * FROM students";
                SqlCommand myCommand = new SqlCommand(sql, myConnection);
                SqlDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    Student student = new Student
                    {
                        StudentID = myReader.GetInt32(0),
                        Name = myReader.GetString(1),
                        Email = myReader.GetString(2),
                        MajorID = myReader.GetInt32(3)
                    };
                    StudentsList.Items.Add(student);
                }
                myReader.Close();

                // Load Majors
                sql = "SELECT * FROM programs";
                myCommand = new SqlCommand(sql, myConnection);
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    Major major = new Major
                    {
                        MajorID = myReader.GetInt32(0),
                        Name = myReader.GetString(1)
                    };
                    ProgramsBox.Items.Add(major);
                }

                myConnection.Close();
            }
        }

        private void StudentsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (StudentsList.SelectedIndex != -1)
            {
                currentStudent = (Student)StudentsList.SelectedItem;
                NameBox.Text = currentStudent.Name;
                EmailBox.Text = currentStudent.Email;

                for (int i = 0; i < ProgramsBox.Items.Count; i++)
                {
                    if (((Major)ProgramsBox.Items[i]).MajorID == currentStudent.MajorID)
                    {
                        ProgramsBox.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            currentStudent = null;
            StudentsList.SelectedIndex = -1;
            NameBox.Text = "";
            EmailBox.Text = "";
            ProgramsBox.SelectedIndex = -1;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string name = NameBox.Text;
            string email = EmailBox.Text;
            Major selectedProgram = (Major)ProgramsBox.SelectedItem;
            int programID = selectedProgram.MajorID;
            string sql = "";

            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {
                myConnection.Open();

                if (currentStudent == null)
                {
                    sql = "INSERT INTO students (name, email, programID) VALUES (@name, @mail, @progId)";
                }
                else
                {
                    sql = "UPDATE students SET name=@name, email=@mail, programID=@progId WHERE studentID=@studId";
                }

                using (SqlCommand myCommand = new SqlCommand(sql, myConnection))
                {
                    myCommand.Parameters.AddWithValue("@name", name);
                    myCommand.Parameters.AddWithValue("@mail", email);
                    myCommand.Parameters.AddWithValue("@progId", programID);
                    if (currentStudent != null)
                    {
                        myCommand.Parameters.AddWithValue("@studId", currentStudent.StudentID);
                    }

                    myCommand.ExecuteNonQuery();
                }

                myConnection.Close();
            }

            ClearButton_Click(sender, e);
            LoadData();
        }

        private void NameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }

    public class Major
    {
        public int MajorID { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class Student
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int MajorID { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Email}, {MajorID})";
        }
    }
}