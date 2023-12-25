using System;
using System.Collections.Generic;

namespace telefon_uygulamasi
{
    static class extensionClass
    {
        internal static bool BosMu(this List<Kisi> param)
        {
            if (param == null || param.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal static string[] DiziYap(this string param)
        {
            return param.Split(' ');
        }
    }
}