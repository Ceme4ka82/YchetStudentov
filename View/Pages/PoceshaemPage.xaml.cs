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
    /// Логика взаимодействия для PoceshaemPage.xaml
    /// </summary>
    public partial class PoceshaemPage : Page
    {
        StudYchetEntities entities = new StudYchetEntities();
        public PoceshaemPage()
        {
            InitializeComponent();
            ShowTable();
        }

        public void ShowTable()
        {
            PrepodView.ItemsSource = entities.Poseshaemost.ToList();
        }

        private void DPDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ToMain_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new View.Pages.MainMenupage());
        }

        private void NewPrepod_Click(object sender, RoutedEventArgs e)
        {
            var win = new View.NewWin.DobavPropusk(new Poseshaemost());
            frame.Navigate(win);
        }

        private void DelPrepod_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PrepodView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
