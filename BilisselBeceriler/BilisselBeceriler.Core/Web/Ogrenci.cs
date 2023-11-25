using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace BilisselBeceriler.Entities.Web
{
    public class Ogrenci
    {
        public virtual int Id { get; set; }
        public virtual string Adi { get; set; }
        public virtual string Soyadi { get; set; }
        public virtual string Vesikalik { get; set; }
        public virtual PaketTur PaketTur { get; set; }
        public virtual GenelAyarlar Cinsiyet { get; set; }
        public virtual DateTime DogumTarih { get; set; }        
        public virtual DateTime Baslangici { get; set; }
        [XmlIgnore]
        public virtual Sinif Sinif { get; set; }
        [XmlIgnore]
        public virtual IList<OgrenciFotograf> FotografListe { get; set; }
        [XmlIgnore]
        public virtual bool AktifMi { get; set; }
    }
}
