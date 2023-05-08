using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для GruppaPage.xaml
    /// </summary>
    public partial class GruppaPage : Page
    {
        StudYchetEntities entities = new StudYchetEntities();
        public GruppaPage(StudYchetEntities entities)
        {
            InitializeComponent();
            this.entities = entities;
            DGGr.ItemsSource = entities.Gruppa.ToList();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                entities.SaveChanges();
                DGGr.ItemsSource = entities.Gruppa.ToList();
            }
            catch
            {
                MessageBox.Show("Ошибка добавления/Редактирования", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            if (txtnas != null)
            {
                Gruppa sp = new Gruppa() { Naim =txtnas.Text};
            entities.Entry(sp).State = EntityState.Added;
                entities.SaveChanges();
                DGGr.ItemsSource = entities.Gruppa.ToList();
            }
            else { MessageBox.Show("Заполни текст бокс"); }
        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
            var del = DGGr.SelectedItem as Gruppa;
            entities.Gruppa.Remove(del);
            entities.SaveChanges();
            DGGr.ItemsSource = entities.Gruppa.ToList();
        }
    }
}
