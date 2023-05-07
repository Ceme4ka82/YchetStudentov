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
    /// Логика взаимодействия для StudentPage.xaml
    /// </summary>
    public partial class StudentPage : Page
    {
        StudYchetEntities entities = new StudYchetEntities();
        public StudentPage()
        {
            InitializeComponent();
            StudView.ItemsSource = entities.Students.ToList();
        }

        public void ShowTable()
        {
            string txtbiz = TxtName.Text;
            List<Students> stud = entities.Students.ToList();

            stud = stud.Where(x => x.Fam.ToLower().Contains(txtbiz.ToLower())).ToList();

            StudView.ItemsSource = stud.OrderBy(x => x.ID).ToList();
        }

        private void TxtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShowTable();
        }

        private void ToMain_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new View.Pages.MainMenupage());
        }

        private void SaveWord_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveExel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NewStud_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DelStud_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var del = StudView.SelectedItem as Students;
                if (del == null)
                {
                    MessageBox.Show("Строка не выбрана", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                MessageBoxResult result = MessageBox.Show("Вы уверены что хотите удалить запись", "Сообщение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    entities.Students.Remove(del);
                    entities.SaveChanges();
                    StudView.ItemsSource = entities.Students.ToList();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка удаления", ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void StudView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
