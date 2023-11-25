using System.Collections.Generic;
using System.Linq;

namespace ZoruSor.Lib.ResimBuilder
{
    public class YerDegistirArgs
    {
        public YerDegistirArgs()
        {
            ReferansResim= new Dictionary<string, int>();
            YerDegisimList= new List<int[]>();
            ReferansYerList = new List<ParcaYer>();
            DegisimMetin = "";
        }
        public Havuz.Havuz Havuz { get; set; }
        public Dictionary<string,int> ReferansResim { get; set; }
        public string DegisimMetin { get; set; }
        public List<int[]> YerDegisimList { get; set; }
        public List<ParcaYer> ReferansYerList { get; set; }
        public int ResimBoyut { get; set; }


        public void YerDegistir(int parcaId1, int parcaId2)
        {
            YerDegisimList.Add(new []{parcaId1, parcaId2});
            var pr1 = ReferansYerList.FirstOrDefault(s => s.IlkKonum == parcaId1);
            var pr2 = ReferansYerList.FirstOrDefault(s => s.IlkKonum == parcaId2);

            if (pr1 != null && pr2 != null)
            {
                var tmp = pr1.SonKonum;
                pr1.SonKonum = pr2.SonKonum;
                pr2.SonKonum = tmp;
                ReferansYerList.RemoveAt(parcaId1);
                ReferansYerList.Insert(parcaId1, pr1);

                ReferansYerList.RemoveAt(parcaId2);
                ReferansYerList.Insert(parcaId2, pr2);

               DegisimMetin += string.Format("{0} ile {1}, ", parcaId1 + 1, parcaId2 + 1);
            }
        }

        public void YenidenSirala()
        {
            ReferansYerList = new List<ParcaYer>();
            DegisimMetin = "";
            
            for (int i = 0; i < ReferansResim.Count; i++)
            {
                ReferansYerList.Add(new ParcaYer { Ad = ReferansResim.ElementAt(i).Key, IlkKonum = i, SonKonum = i });
            }

            foreach (var degisim in YerDegisimList)
            {
                var pr1 = ReferansYerList.FirstOrDefault(s => s.IlkKonum == degisim[0]);
                var pr2 = ReferansYerList.FirstOrDefault(s => s.IlkKonum == degisim[1]);

                if (pr1 != null && pr2 != null)
                {
                    var tmp = pr1.SonKonum;
                    pr1.SonKonum = pr2.SonKonum;
                    pr2.SonKonum = tmp;
                    ReferansYerList.RemoveAt(degisim[0]);
                    ReferansYerList.Insert(degisim[0], pr1);

                    ReferansYerList.RemoveAt(degisim[1]);
                    ReferansYerList.Insert(degisim[1], pr2);

                    DegisimMetin += string.Format("{0} ile {1}, ", degisim[0] + 1, degisim[1] + 1);
                }
            }
        }

        public virtual bool Equals(YerDegistirArgs hedef)
        {

            bool sonuc=true;
            foreach (var parca in ReferansResim)
            {
                if (hedef.ReferansResim[parca.Key]!=parca.Value)
                {
                    sonuc = false;
                }
            }

            foreach (var yerDegisim in YerDegisimList)
            {
                if (hedef.YerDegisimList.Any(s=>s[0]==yerDegisim[0] && s[1]==yerDegisim[1]) == false)
                {
                    sonuc = false;
                }
            }
            foreach (var parcaYer in ReferansYerList)
            {
                if (hedef.ReferansYerList.Any(s=>s.Ad==parcaYer.Ad && 
                                              s.IlkKonum == parcaYer.IlkKonum && 
                                              s.SonKonum == parcaYer.SonKonum) == false)
                {
                    sonuc = false;
                }
            }
            return sonuc;
        }

    }
}
