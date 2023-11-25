using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace ZoruSor.Lib.Soru
{
    public class DogruCevap
    {
        public CiktiResim Resim { get; set; }
        public string Metin { get; set; }
        public string Aciklama { get; set; }
    }
    public class Soru
    {
       
        public Soru()
        {
            ReferansResimList = new List<CiktiResim>();
            DogruCevapList = new List<CiktiResim>();
            CeldiriciList = new List<CiktiResim>();
            ReferansStrList = new List<string>();
            DogruCevapStrList = new List<string>();
            CeldiriciStrList = new List<string>();
            DogruCevapObjList = new List<DogruCevap>();
        }
        public List<CiktiResim> ReferansResimList { get; set; }
        public List<CiktiResim> DogruCevapList { get; set; }
        public List<CiktiResim> CeldiriciList { get; set; }
        public List<string> ReferansStrList { get; set; }
        public List<string> DogruCevapStrList { get; set; }
        public List<string> CeldiriciStrList { get; set; }
        public List<DogruCevap> DogruCevapObjList { get; set; }
    }
}
