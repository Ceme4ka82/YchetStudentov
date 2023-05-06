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
    /// Логика взаимодействия для SettingsPolPage.xaml
    /// </summary>
    public partial class SettingsPolPage : Window
    {
        StudYchetEntities entities = new StudYchetEntities();
        public SettingsPolPage(StudYchetEntities entities, Prepodovatel polzovatel)
        {
            InitializeComponent();
            this.entities = entities;
            DataContext = polzovatel;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                entities.SaveChanges();
                View.Windows.Proverka proverka = new View.Windows.Proverka();
                proverka.Show();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка Редактирования", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            View.MainMenu mainMenu = new View.MainMenu();
            mainMenu.Show();
            this.Close();
        }
    }
}
