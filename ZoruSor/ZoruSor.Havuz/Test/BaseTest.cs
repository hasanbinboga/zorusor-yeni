using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ZoruSor.Lib.Test.Analoji;
using ZoruSor.Lib.TestSoru;

namespace ZoruSor.Lib.Test
{
    
    [XmlInclude(typeof(AnalojiIkili1Test1))]
    public class BaseTest : List<BaseSoru>
    { 
        
    }
}
