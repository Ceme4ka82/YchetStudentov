using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using YchetStudentov.Model.DataBase;

namespace YchetStudentov.View
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        Model.DataBase.StudYchetEntities entities = new Model.DataBase.StudYchetEntities();
        public MainMenu()
        {
            InitializeComponent();
            DataContext = Model.Classes.Set.user;
            frame.Navigate(new View.Pages.MainMenupage());
        }

        private void btn_Setting_Click(object sender, RoutedEventArgs e)
        {
            Prepodovatel getrep = (from c in entities.Prepodovatel
                                where c.ID == Model.Classes.Set.user.ID
                                select c).SingleOrDefault<Prepodovatel>();
            View.Pages.SettingsPolPage setting = new Pages.SettingsPolPage(entities, getrep);
            setting.Show();
            this.Close();
        }
    }
}
