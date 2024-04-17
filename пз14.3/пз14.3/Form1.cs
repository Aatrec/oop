using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace пз14._3
{
    public partial class Form1 : Form
    {
        private List<Student> students = new List<Student>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Додайте деякі студенти для демонстрації
            students.Add(new Student { Name = "Іванов Іван", Group = "Група A", IsPresent = false });
            students.Add(new Student { Name = "Петров Петро", Group = "Група B", IsPresent = false });
            students.Add(new Student { Name = "Сидоров Сидір", Group = "Група A", IsPresent = false });

            // Відображення списку студентів у DataGridView
            DisplayStudents(students);
        }

        private void DisplayStudents(List<Student> students)
        {
            dataGridView1.Rows.Clear();
            foreach (var student in students)
            {
                dataGridView1.Rows.Add(new object[] { student.Name, student.Group, student.IsPresent });
            }
        }

        private void buttonMarkAttendance_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBoxGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
      
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_Layout(object sender, LayoutEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedGroup = comboBox1.SelectedItem.ToString();
            List<Student> filteredStudents = students.FindAll(student => student.Group == selectedGroup);
            DisplayStudents(filteredStudents);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchKeyword = textBox1.Text.ToLower();
            List<Student> filteredStudents = students.FindAll(student => student.Name.ToLower().Contains(searchKeyword));
            DisplayStudents(filteredStudents);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected)
                {
                    int index = row.Index;
                    students[index].IsPresent = !students[index].IsPresent;
                   /// dataGridView1.Rows[index].Cells["IsPresent"].Value = students[index].IsPresent;
                }
            }

            DisplayStudents(students);
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public bool IsPresent { get; set; }
    }
}
