using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YchetStudentov.Model.Classes
{
    public class AuthUser
    {
        int id;
        string fam;
        string imya;
        string otch;

        public int ID { get { return id; } set { id = value; } }
        public string Fam { get { return fam; } set { fam = value; } }
        public string Imya { get { return imya; } set { imya = value; } }
        public string Otch { get { return otch; } set { otch = value; } }

        public AuthUser(int id, string fam, string imya, string otch)
        {
            this.ID = id;
            this.Fam = fam;
            this.Imya = imya;
            this.Otch = otch;
        }
    }
}
