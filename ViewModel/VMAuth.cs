using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using YchetStudentov.Model.DataBase;

namespace YchetStudentov.ViewModel
{
    public class VMAuth
    {
        StudYchetEntities entities =new StudYchetEntities();
        public void SetUser(string log, string pas)
        {
            try
            {
               // var getrep = entities.Polzovatel.Where(x=>x.Loginn == log||x.Pas==pas).SingleOrDefault();
                Prepodovatel getrep = (from c in entities.Prepodovatel
                                     where c.Loginn == log && c.Pas == pas
                                     select c).SingleOrDefault<Prepodovatel>();
                if (getrep != null)
                {
                    Model.Classes.Set.user = new Model.Classes.AuthUser(getrep.ID, getrep.Fam, getrep.Imya, getrep.Otch);
                }
                else
                {
                    MessageBox.Show("Ошибка авторизации", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch
            {
                Model.Classes.Set.user = null;
            }
        }
    }
}
