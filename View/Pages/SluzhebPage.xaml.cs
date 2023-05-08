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
using YchetStudentov.Model.DataBase;

namespace YchetStudentov.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для SluzhebPage.xaml
    /// </summary>
    public partial class SluzhebPage : Page
    {
        StudYchetEntities entities = new StudYchetEntities();
        public SluzhebPage()
        {
            InitializeComponent();
        }

        private void btnPredmet_Click(object sender, RoutedEventArgs e)
        {
            pageFrame.Navigate(new View.Pages.PredmetPage(entities));
        }

        private void btnOtmetka_Click(object sender, RoutedEventArgs e)
        {
            pageFrame.Navigate(new View.Pages.OtmetkaPage(entities));
        }

        private void btnGrup_Click(object sender, RoutedEventArgs e)
        {
            pageFrame.Navigate(new View.Pages.GruppaPage(entities));
        }

        private void ToMain_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new View.Pages.MainMenupage());
        }
    }
}
