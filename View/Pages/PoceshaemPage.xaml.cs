using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
            PrepodView.ItemsSource = entities.Poseshaemost.ToList();
        }

        public void ShowTable()
        {
            var selectionDate = entities.Poseshaemost.Where(x => x.Data_ == DPDate.SelectedDate).ToList();
            PrepodView.ItemsSource = selectionDate;
        }

        private void DPDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowTable();
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
            try
            {
                var del = PrepodView.SelectedItem as Poseshaemost;
                if (del == null)
                {
                    MessageBox.Show("Строка не выбрана", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                MessageBoxResult result = MessageBox.Show("Вы уверены что хотите удалить запись", "Сообщение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    entities.Sost_Poseshaem.RemoveRange(del.Sost_Poseshaem);
                    entities.Poseshaemost.Remove(del);
                    entities.SaveChanges();
                    PrepodView.ItemsSource = entities.Poseshaemost.ToList();
                }
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show("При удалении данных на сервере произошла ошибка." +
                         "\nДанные не были удалены." +
                         "\n Исключение: " + ex.InnerException.InnerException.Message);
            }
        }

        private void PrepodView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
