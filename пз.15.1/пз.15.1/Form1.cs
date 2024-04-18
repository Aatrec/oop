using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace пз._15._1
{
    public partial class Form1 : Form
    {
        private List<Book> books = new List<Book>(); // Список книг

        public Form1()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            // Налаштування DataGridView
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = books;

            //dataGridView1.Columns.Clear();
            //dataGridView1.Columns.Add("Title", "Title");
            //dataGridView1.Columns.Add("Author", "Author");
            //dataGridView1.Columns.Add("Genre", "Genre");
            //dataGridView1.Columns.Add("Year", "Year");
        }

        private void AddBookButton_Click(object sender, EventArgs e)
        {
            // Додати нову книгу до списку
            Book newBook = new Book();
            // Заповніть властивості книги з TextBox або інших елементів у формі
            books.Add(newBook);
            RefreshDataGridView();
        }

        private void RemoveBookButton_Click(object sender, EventArgs e)
        {
            // Видалити обрану книгу зі списку
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Book selectedBook = dataGridView1.SelectedRows[0].DataBoundItem as Book;
                books.Remove(selectedBook);
                RefreshDataGridView();
            }
        }

        private void RefreshDataGridView()
        {
            // Оновити вміст DataGridView
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = books;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Зберегти список книг у текстовий файл
            XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
            using (TextWriter writer = new StreamWriter("books.xml"))
            {
                serializer.Serialize(writer, books);
            }
            MessageBox.Show("Список книг збережено.");
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            // Завантажити список книг з текстового файлу
            if (File.Exists("books.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
                using (TextReader reader = new StreamReader("books.xml"))
                {
                    books = (List<Book>)serializer.Deserialize(reader);
                }
                RefreshDataGridView();
                MessageBox.Show("Список книг завантажено.");
            }
            else
            {
                MessageBox.Show("Файл зі списком книг не знайдено.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Додати нову книгу до списку
            Book newBook = new Book();
            newBook.Title = Title.Text;
            newBook.Author = Author.Text;
            newBook.Genre = Genre.Text;
            newBook.Year = int.Parse(Year.Text);
            
            // Заповніть властивості книги з TextBox або інших елементів у формі
            books.Add(newBook);
            RefreshDataGridView();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Видалити обрану книгу зі списку
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Book selectedBook = dataGridView1.SelectedRows[0].DataBoundItem as Book;
                books.Remove(selectedBook);
                RefreshDataGridView();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Зберегти список книг у текстовий файл
            XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
            using (TextWriter writer = new StreamWriter("books.xml"))
            {
                serializer.Serialize(writer, books);
            }
            MessageBox.Show("Список книг збережено.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Завантажити список книг з текстового файлу
            if (File.Exists("books.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
                using (TextReader reader = new StreamReader("books.xml"))
                {
                    books = (List<Book>)serializer.Deserialize(reader);
                }
                RefreshDataGridView();
                MessageBox.Show("Список книг завантажено.");
            }
            else
            {
                MessageBox.Show("Файл зі списком книг не знайдено.");
            }
        }

        private void Title_TextChanged(object sender, EventArgs e)
        {

        }

        private void Year_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public class Book
    {
        // Властивості книги
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        // Додайте інші властивості, які вам потрібні
    }
}
