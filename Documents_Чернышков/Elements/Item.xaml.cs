using System;
using System.Collections.Generic;
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

namespace Documents_Чернышков.Elements
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        DocumentContext Document;
        public Item(DocumentContext Document)
        {
            InitializeComponent();

            img.Source = new BitmapImage(new Uri(Document.src));

            1Name.Content = Document.name;
            1User.Content = $"Ответсвенный: { Document.user }";
            1Code.Content = $"Код документа: { Document.id_document }";
            1Date.Content = $"Дата поступления: {Document.date.ToString("dd.MM.yyyy") }";
            1Status.Content = Document.status == 0 ? $"Статус : входящий": $"Статус: исходящий";
            1Direct.Content = "Направление: " + Document.vector;

            this.Document = Document;

        }

        private void EditDocument(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new Pages.Add(Document));
        }
        private void DeleteDocument(object sender, RoutedEventArgs e)
        {
            Document.Delete();
            MainWindow.init.AllDocuments = new DocumentContext().AllDocuments;
            MainWindow.init.OpenPages(MainWindow.pages.main);
        }
    }
}
