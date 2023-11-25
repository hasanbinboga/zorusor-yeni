using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BilisselBeceriler.Entities.Security
{
    public interface IKullaniciYetki
    {
        int Id { get; set; }
        string Ad { get; set; }
    }
}
