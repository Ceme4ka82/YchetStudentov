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
using Word = Microsoft.Office.Interop.Word;

namespace YchetStudentov.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для PrepodovateliPage.xaml
    /// </summary>
    public partial class PrepodovateliPage : Page
    {
        StudYchetEntities entities = new StudYchetEntities();
        public PrepodovateliPage()
        {
            InitializeComponent();
            PrepodView.ItemsSource = entities.Prepodovatel.ToList();
        }

        public void ShowTable()
        {
            string txtbiz = TxtName.Text;
            List<Prepodovatel> Prep = entities.Prepodovatel.ToList();

            Prep = Prep.Where(x => x.Fam.ToLower().Contains(txtbiz.ToLower())).ToList();

            PrepodView.ItemsSource = Prep.OrderBy(x => x.ID).ToList();
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
            var allsotr = entities.Prepodovatel.ToList();

            var application = new Word.Application();

            Word.Document document = application.Documents.Add();

            Word.Paragraph tablparagraf = document.Paragraphs.Add();
            Word.Range tablrange = tablparagraf.Range;
            Word.Table table = document.Tables.Add(tablrange, allsotr.Count() + 1, 5);
            table.Borders.InsideLineStyle = table.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            table.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            Word.Range cellRange;

            cellRange = table.Cell(1, 1).Range;
            cellRange.Text = "Код";
            cellRange = table.Cell(1, 2).Range;
            cellRange.Text = "ФИО";
            cellRange = table.Cell(1, 3).Range;
            cellRange.Text = "Логин";
            cellRange = table.Cell(1, 4).Range;
            cellRange.Text = "Пароль";
            cellRange = table.Cell(1, 5).Range;

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
                cellRange.Text = currenPr.Loginn.ToString();

                cellRange = table.Cell(i + 2, 4).Range;
                cellRange.Text = currenPr.Pas.ToString();

            }
            application.Visible = true;

            document.SaveAs2(@Environment.CurrentDirectory + DateTime.Now.ToString("dd-MM-yyyy_hh-mm-ss") + "Список сотрудников.docx");
            document.SaveAs2(@Environment.CurrentDirectory + DateTime.Now.ToString("dd-MM-yyyy_hh-mm-ss") + "Список сотрудников.pdf", Word.WdExportFormat.wdExportFormatPDF);
        }

        private void SaveExel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NewPrepod_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newprep = new Prepodovatel();
                entities.Prepodovatel.Add(newprep);
                var win = new View.NewWin.NewPrepod(entities, newprep);
                win.ShowDialog();
                PrepodView.ItemsSource = entities.Prepodovatel.ToList();
            }
            catch
            {
                MessageBox.Show("Ошибка добавления", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DelPrepod_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var del = PrepodView.SelectedItem as Prepodovatel;
                if (del == null)
                {
                    MessageBox.Show("Строка не выбрана", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                MessageBoxResult result = MessageBox.Show("Вы уверены что хотите удалить запись", "Сообщение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    entities.Prepodovatel.Remove(del);
                    entities.SaveChanges();
                    PrepodView.ItemsSource = entities.Prepodovatel.ToList();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка удаления", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void PrepodView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var red = PrepodView.SelectedItem as Prepodovatel;
                var win = new View.NewWin.NewPrepod(entities, red);
                win.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Ошибка редактирования", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
