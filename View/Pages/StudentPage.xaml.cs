using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using YchetStudentov.Model.DataBase;
using Word = Microsoft.Office.Interop.Word;

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
            var allsotr = entities.Students.ToList();

            var application = new Word.Application();

            Word.Document document = application.Documents.Add();

            Word.Paragraph tablparagraf = document.Paragraphs.Add();
            Word.Range tablrange = tablparagraf.Range;
            Word.Table table = document.Tables.Add(tablrange, allsotr.Count() + 1, 6);
            table.Borders.InsideLineStyle = table.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            table.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            Word.Range cellRange;

            cellRange = table.Cell(1, 1).Range;
            cellRange.Text = "Код";
            cellRange = table.Cell(1, 2).Range;
            cellRange.Text = "ФИО";
            cellRange = table.Cell(1, 3).Range;
            cellRange.Text = "Группа";
            cellRange = table.Cell(1, 4).Range;
            cellRange.Text = "Студентческий билет. Серия";
            cellRange = table.Cell(1, 5).Range;
            cellRange.Text = "Студентческий билет. Номер";
            cellRange = table.Cell(1, 6).Range;
            cellRange.Text = "Дата рождения";

            table.Rows[1].Range.Bold = 1;
            table.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            for (int i = 0; i < allsotr.Count(); i++)
            {
                var currenPr = allsotr[i];

                cellRange = table.Cell(i + 2, 1).Range;
                cellRange.Text = currenPr.ID.ToString();

                cellRange = table.Cell(i + 2, 2).Range;
                cellRange.Text = currenPr.Fam + " " + currenPr.Imya + " " + currenPr.Otch;

                cellRange = table.Cell(i + 2, 3).Range;
                cellRange.Text = currenPr.Gruppa.Naim;

                cellRange = table.Cell(i + 2, 4).Range;
                cellRange.Text = currenPr.Seria_Stud_Bil;

                cellRange = table.Cell(i + 2, 5).Range;
                cellRange.Text = currenPr.Nomer_Stud_Bil;

                cellRange = table.Cell(i + 2, 6).Range;
                cellRange.Text = currenPr.DataOnly;
            }
            application.Visible = true;

            document.SaveAs2(@Environment.CurrentDirectory + DateTime.Now.ToString("dd-MM-yyyy_hh-mm-ss") + "Список студентов.docx");
        }

        private void NewStud_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newstud = new Students();
                entities.Students.Add(newstud);
                var win = new View.NewWin.KartaStudenta(entities, newstud);
                win.ShowDialog();
                StudView.ItemsSource = entities.Students.ToList();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show("При добавлении/Изменении данных на сервере произошла ошибка." +
                         "\nДанные не были добавлены/Изменены." +
                         "\n Исключение: " + ex.InnerException.InnerException.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка удаления", ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void StudView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var red = StudView.SelectedItem as Students;
                var win = new View.NewWin.KartaStudenta(entities, red);
                win.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Ошибка редактирования", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
