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
using YchetStudentov.Model.DataBase;

namespace YchetStudentov.View.NewWin
{
    /// <summary>
    /// Логика взаимодействия для NewPrepod.xaml
    /// </summary>
    public partial class NewPrepod : Window
    {
        StudYchetEntities entities = new StudYchetEntities();
        public NewPrepod(StudYchetEntities entities, Prepodovatel polzovatel)
        {
            InitializeComponent();
            this.entities = entities;
            this.DataContext = polzovatel;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                entities.SaveChanges();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка добавления/Редактирования", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
