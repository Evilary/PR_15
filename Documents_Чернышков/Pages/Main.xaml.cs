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

namespace Documents_Чернышков.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public Main()
        {
            InitializeComponent();
            CreatedUI();
        }
        public void Exit(object sender, EventArgs e)
        {
            MainWindow.init.Close();
        }
        public void CreatedUI()
        {
            Parent.Children.Clear();    
            foreach (DocumentContext document in MainWindow.init.AllDocuments)
                Parent.Children.Add(new Elements.Item(document));
        }
    }
}
