using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace YchetStudentov.Model.DataBase
{
    public partial class Students
    {
        public string DataOnly
        {
            get
            {
                string datao = "";
                try
                {
                    datao = Birth_date.ToLongDateString();
                }
                catch (Exception ex) { }
                return datao;
            }
        }
    }
}
