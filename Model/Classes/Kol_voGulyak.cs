using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YchetStudentov.Model.DataBase;

namespace YchetStudentov.Model.DataBase
{
    public partial class Poseshaemost
    {
        public int Sum
        {
            get
            {
                int sum = 0;
                try
                {
                    sum = Sost_Poseshaem.Count();
                }
                catch (Exception ex) { }
                return sum;
            }
        }
    }
}
