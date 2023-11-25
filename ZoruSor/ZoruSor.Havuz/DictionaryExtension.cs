using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoruSor.Lib
{
    public static class DictionaryExtensions
    {
        public static Dictionary<TKey, TValue> Shuffle<TKey, TValue>(
           this Dictionary<TKey, TValue> source)
        {
            
            return source.OrderBy(x => RandomHelper.RandomNumber(0,5514))
               .ToDictionary(item => item.Key, item => item.Value);
        }
    }

    public static class ListExtensions
    {
        public static List<T> Shuffle<T>(
           this List<T> source)
        {

            return source.OrderBy(x => RandomHelper.RandomNumber(0, 5514)).ToList();
        }
    }
}
