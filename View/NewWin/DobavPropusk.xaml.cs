using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using YchetStudentov.Model.DataBase;

namespace YchetStudentov.View.NewWin
{
    /// <summary>
    /// Логика взаимодействия для DobavPropusk.xaml
    /// </summary>
    public partial class DobavPropusk : Page
    {
        StudYchetEntities entities = new StudYchetEntities();
        Poseshaemost pos;
        public List<Otmetka_pos> OtmetkaList { get { return entities.Otmetka_pos.ToList(); } }
        public List<Students> DolList { get { return entities.Students.Where(x => x.IDGruppi == ((Gruppa)cmbGrupp.SelectedItem).ID).ToList(); ; } }
        public DobavPropusk(Poseshaemost p)
        {
            InitializeComponent();
            if (p.ID != 0)
            {
                pos = entities.Poseshaemost.Include(x => x.Sost_Poseshaem).First(y => y.ID == p.ID);

            }
            else
            {
                pos = p;
                entities.Poseshaemost.Add(pos);
            }
            DataContext = pos;



            DGProp.ItemsSource = entities.Sost_Poseshaem.Local.ToBindingList();
            var preptxt = entities.Prepodovatel.Where(x => x.ID == Model.Classes.Set.user.ID).ToList();
            CmbPrep.ItemsSource = preptxt;
            CmbPred.ItemsSource = entities.Predmet.ToList();
            cmbGrupp.ItemsSource = entities.Gruppa.ToList();
        }
        private void btnDobavitPropusk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var spcl = entities.Students.Where(x => x.Gruppa.ID == ((Gruppa)cmbGrupp.SelectedItem).ID).ToList();
                for (int i = 0; i < spcl.Count; i++)
                {
                    Sost_Poseshaem sp = new Sost_Poseshaem() { IDStud = spcl[i].ID };
                    pos.Sost_Poseshaem.Add(sp);
                    entities.Entry(sp).State = EntityState.Added;
                }

                btnSave.IsEnabled = true;
                btnYdalitPropusk.IsEnabled = true;
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show("При добавлении данных на сервере произошла ошибка." +
                         "\nДанные не были добавлены." +
                         "\n Исключение: " + ex.InnerException.InnerException.Message);
            }
        }

        private void btnYdalitPropusk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                entities.Sost_Poseshaem.Remove((Sost_Poseshaem)DGProp.SelectedItem);
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show("При удалении данных на сервере произошла ошибка." +
                         "\nДанные не были удалены." +
                         "\n Исключение: " + ex.InnerException.InnerException.Message);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CmbPred.SelectedItem == null && CmbPrep.Text == null)
                {
                    MessageBox.Show("Выберите сотрудника!");
                }
                else if (CmbPrep.Text != null)
                {
                    entities.SaveChanges();
                }
                MessageBox.Show("Сохранено");
                frame.Navigate(new View.Pages.MainMenupage());
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show("При сохранении данных на сервере произошла ошибка." +
                         "\nДанные не были сохранены." +
                         "\n Исключение: " + ex.InnerException.InnerException.Message);
            }
        }

        private void DGProp_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex();
        }

        private void cmbGrupp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnDobavitPropusk.IsEnabled = true;
        }

        private void ToMain_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new View.Pages.MainMenupage());
        }
    }
}
