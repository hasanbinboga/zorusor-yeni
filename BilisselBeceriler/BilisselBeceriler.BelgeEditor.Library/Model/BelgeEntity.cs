using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Documents;
namespace BilisselBeceriler.BelgeEditor.Library.Model
{
    public class BelgeEntity : BaseEntity
    {
        public FixedDocument BelgeContainer { get; set; }
        public int Cinsiyet { get; set; }
    }
}
