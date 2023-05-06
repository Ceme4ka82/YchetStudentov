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
using System.Windows.Shapes;

namespace YchetStudentov.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для Proverka.xaml
    /// </summary>
    public partial class Proverka : Window
    {
        ViewModel.VMAuth vmuser = new ViewModel.VMAuth();
        public Proverka()
        {
            InitializeComponent();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
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
        }
    }
}
