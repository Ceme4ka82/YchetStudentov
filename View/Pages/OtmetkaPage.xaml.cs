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
    /// Логика взаимодействия для OtmetkaPage.xaml
    /// </summary>
    public partial class OtmetkaPage : Page
    {
        StudYchetEntities entities = new StudYchetEntities();
        public OtmetkaPage(StudYchetEntities entities)
        {
            InitializeComponent();
            this.entities = entities;
            DGGr.ItemsSource = entities.Otmetka_pos.ToList();

        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                entities.SaveChanges();
                DGGr.ItemsSource = entities.Otmetka_pos.ToList();
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
                Otmetka_pos sp = new Otmetka_pos() { Naim = txtnas.Text };
                entities.Entry(sp).State = EntityState.Added;
                entities.SaveChanges();
                DGGr.ItemsSource = entities.Otmetka_pos.ToList();
            }
            else { MessageBox.Show("Заполни текст бокс"); }
        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
            var del = DGGr.SelectedItem as Otmetka_pos;
            entities.Otmetka_pos.Remove(del);
            entities.SaveChanges();
            DGGr.ItemsSource = entities.Otmetka_pos.ToList();
        }
    }
}
