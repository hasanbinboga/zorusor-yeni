using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BilisselBeceriler.BelgeEditor.Library.Model
{
    public class BireyselEntity : ImageEntity
    {
        public BireyselEntity()
        {
            Width = 88;
            Hidth = 100;
        }
        public string Tag { get; set; }
        public string ToolTip { get; set; }
    }
}
