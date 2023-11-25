using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace BilisselBeceriler.Utility
{   
    public static class Extensions
    {
        public static string ToTitleCase(this string inputString, bool forceLower)
        {
            CultureInfo ci = new CultureInfo("tr-TR");
            inputString = inputString.Trim();
            if (inputString == "")
            {
                return "";
            }
            if (forceLower)
            {
                inputString = inputString.ToLower(ci);
            }

            string[] inputStringAsArray = inputString.Split(' ');
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < inputStringAsArray.Length; i++)
            {
                if (inputStringAsArray[i].Length > 0)
                {
                    sb.AppendFormat("{0}{1} ",
                       inputStringAsArray[i].Substring(0, 1).ToUpper(ci),
                       inputStringAsArray[i].Substring(1));
                }
            }
            return sb.ToString(0, sb.Length - 1);
        }
    }
}
