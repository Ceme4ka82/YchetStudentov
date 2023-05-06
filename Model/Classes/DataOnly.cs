using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YchetStudentov.Model.DataBase
{
   public partial class Poseshaemost
    {
        public string DataOnly 
        {
            get
            {
                string datao = "";
                try
                {
                    datao = Data_.ToLongDateString();
                }
                catch (Exception ex) { }
                return datao;
            }
        }
    }
}
