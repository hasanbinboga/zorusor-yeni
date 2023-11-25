using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BilisselBeceriler.Altyapi
{
    public interface IMainWindow
    {
        void MesajYaz(MesajTip Tip, string Mesaj, string ToolTip = null);
        void MesajGoster(string Mesaj);
        
    }
}
