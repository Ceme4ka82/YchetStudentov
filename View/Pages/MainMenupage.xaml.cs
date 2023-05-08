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

namespace YchetStudentov.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainMenupage.xaml
    /// </summary>
    public partial class MainMenupage : Page
    {
        public MainMenupage()
        {
            InitializeComponent();
        }

        private void btn_Dogovor_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new View.Pages.PrepodovateliPage());
        }

        private void Static_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new View.Pages.PoceshaemPage());
        }

        private void Stud_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new View.Pages.StudentPage());
        }

        private void btn_SluzhInfo_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new View.Pages.SluzhebPage());
        }
    }
}
