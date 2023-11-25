using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BilisselBeceriler.BelgeEditor.Library.Enums;

namespace BilisselBeceriler.BelgeEditor.Library.Types
{
    public class XPSOlusturArgs
    {
        public List<string> dosyalar { get; set; }
        public string XPSDosyaAdi { get; set; }
        public BelgeTur belgeTur { get; set; }
        public string Klasor { get; set; }
    }
}
