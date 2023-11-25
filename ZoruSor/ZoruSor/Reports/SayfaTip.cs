using System;
using System.Collections.Generic;
using ZoruSor.Lib.Test;

namespace ZoruSor.Reports
{
    [Serializable]
    public class SayfaTip//:IComparable
    {
        public string Ad { get; set; }
        public List<string> SoruTipList { get; set; }

        [NonSerialized]
        private SayfaTemplate _sayfaTemplate;

        public SayfaTemplate SayfaTemplate
        {
            get
            {
                return _sayfaTemplate;
            }
            set
            {
                _sayfaTemplate = value;
            }
        }

        [NonSerialized]
        private BaseTest _test;
        public BaseTest Test
        {
            get
            {
                return _test;
            }
            set
            {
                _test = value;
            }
        }

        public override string ToString()
        {
            return Ad;
        }

       
        //public int CompareTo(object obj)
        //{
        //    if (obj.GetType() != GetType())
        //        return -1;
        //    return 1;
        //}
    }
}
