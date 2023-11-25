using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ZoruSor.Lib.Soru
{
    /// <summary>
    /// 'Builder' abstract Class
    /// </summary>
    public abstract class SoruBuilder
    {
        public SoruBuilder()
        {
            _soru = new Soru();

            DonusumList = new List<CiktiResim>();
        }
        protected Soru _soru;
        //Get Soru instance
        public Soru Soru { get { return _soru; } }
        public int ZorlukDerece { get; set; }
        public int SabitParcaAdet { get; set; }
        public int CeldiriciAdet { get; set; }
        public int ResimBoyut { get; set; }
        protected List<CiktiResim> DonusumList { get; set; }

        public Havuz.Havuz Havuz { get; set; }

        //Soyut build Metotlari
        public abstract void ReferansResimUret();
        public abstract void DogruCevapUret();
        public abstract void CeldiriciUret();
    }
}
