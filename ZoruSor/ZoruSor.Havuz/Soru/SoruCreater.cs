using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoruSor.Lib.Soru
{
    /// <summary>
    /// Director Sinif
    /// </summary>
    public class SoruCreater
    {
        
        public void Construct(SoruBuilder soruBuilder)
        {
            soruBuilder.ReferansResimUret();
            soruBuilder.DogruCevapUret();
            soruBuilder.CeldiriciUret();
        }
    }
}
