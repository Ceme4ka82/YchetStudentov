using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YchetStudentov.Model.Classes;

namespace YchetStudentov.Model.DataBase
{
    public partial class Poseshaemost : NotifyClass
    {
        List<Sost_Poseshaem> sostn { get { return Sost_Poseshaem.Where(x => x.IDOtmetki_Pos == 1).ToList(); } }
        public int NaZanyatii
        { get
            { int nz = 0;
                try
                {
                    nz = sostn.Count;
                } catch { }
                return nz;
            }
        }

        List<Sost_Poseshaem> sosto { get { return Sost_Poseshaem.Where(x => x.IDOtmetki_Pos == 1).ToList(); } }
        public int Otsutsvoval
        {
            get
            {
                int ots = 0;
                try
                {
                    ots = sosto.Count;
                }
                catch { }
                return ots;
            }
        }

        List<Sost_Poseshaem> vsego { get { return Sost_Poseshaem.ToList(); } }
        public int BiloVsego
        {
            get
            {
                int ots = 0;
                try
                {
                    ots = vsego.Count;
                }
                catch { }
                return ots;
            }
        }
    }
}
