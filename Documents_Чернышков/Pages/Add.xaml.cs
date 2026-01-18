using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Documents_Чернышков.Classes;
using Microsoft.Win32;
using System.IO;

namespace Documents_Чернышков.Pages
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        public Document Document;
        public string s_src = "";
        public Add()
        {
            InitializeComponent();
            if (Document != null)
            {
                this.Document = Document;

                if (File.Exists(Document.src))
                {
                    s_src = Document.src;
                    src.Source = new BitmapImage(new Uri(s_src));
                }

                tb_name.Text = this.Document.name;
                tb_user.Text = this.Document.user;
                tb_id.Text = this.Document.id_document;
                tb_date.Text = this.Document.date.ToString("dd.MM.yyyy");
                tb_status.SelectedIndex = this.Document.status;
                tb_vector.Text = this.Document.vector;
                bthAdd.Content = "Изменить";

            }
        }

       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPages(MainWindow.pages.main);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog =  new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "PNG (*.png)|*.png|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != "")
            {
                src.Source = new BitmapImage(new Uri(openFileDialog.FileName));

                s_src = openFileDialog.FileName;    
            }
        }

        private void AddDocument(object sender, RoutedEventArgs e)
        {
            if (s_src.Length == 0)
            {
                MessageBox.Show("Выберете изображение");
                return;
            }
            if (tb_name.Text.Length == 0)
            {
                MessageBox.Show("Укажите наименование");
                return;
            }
            if(tb_user.Text.Length == 0)
            {
                MessageBox.Show("Укажите ответственного");
                return;
            }
            if (tb_id.Text.Length == 0)
            {
                MessageBox.Show("Укажите код документа");
                return;
            }
            if (tb_date.Text.Length == 0)
            {
                MessageBox.Show("Укажите дату поступления");
                return;
            }
            if (tb_status.Text.Length == 0)
            {
                MessageBox.Show("Укажите статс");
                return ;
            }
            if (tb_vector.Text.Length == 0)
            {
                MessageBox.Show("Укажите направления");
                return;
            }

            if (Document == null)
            {
                DocumentContext newDocument = new DocumentContext();
                newDocument.src = s_src;
                newDocument.name = tb_name.Text;
                newDocument.user = tb_user.Text;
                newDocument.id_document = tb_id.Text;

                DateTime newDate = new DateTime();
                DateTime.TryParse(tb_date.Text, out newDate);
                newDocument.date = newDate;
                newDocument.status = tb_status.SelectedIndex;
                newDocument.vector = tb_vector.Text;    
                newDocument.Save();
                MessageBox.Show("Документ добавлен.");
            }
            else
            {
                DocumentContext newDocument = new DocumentContext();
                newDocument.src = s_src;
                newDocument.id = Document.id;
                newDocument.name= tb_name.Text;
                newDocument.user= tb_user.Text;
                newDocument.id_document = tb_id.Text;

                DateTime newDate = new DateTime();
                DateTime.TryParse(tb_date.Text, out newDate);
                newDocument.date = newDate;
                newDocument.status= tb_status.SelectedIndex;
                newDocument.vector= tb_vector.Text;
                newDocument.Save(true);
                MessageBox.Show("Документ изменен.");
            }
            MainWindow.init.AllDocuments = new DocumentContext().AllDocuments();
            MainWindow.init.OpenPages(MainWindow.pages.main);
        }
    }
}
