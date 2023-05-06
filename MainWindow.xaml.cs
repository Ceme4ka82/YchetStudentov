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

namespace YchetStudentov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel.VMAuth vmuser = new ViewModel.VMAuth();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            if (Log.Text == null || Pas.Password == null)
            {
                MessageBox.Show("Заполните поля", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Model.Classes.Set.user = null;
            vmuser.SetUser(Log.Text, Pas.Password);
            if (Model.Classes.Set.user != null)
            {
                View.MainMenu menu = new View.MainMenu();
                menu.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка авторизации", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Mouse.OverrideCursor = null;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
