using System;
using System.Collections.Generic;

namespace telefon_uygulamasi
{
    class Rehber
    {
        protected static List<Kisi> kisiler;
        static Rehber()
        {
            kisiler = new List<Kisi>()
            {
                new Kisi("Ali", "BIRINCI", "123456789"),
                new Kisi("Veli", "IKINCI", "234567891"),
                new Kisi("Ayse", "UCUNCU", "345678912"),
                new Kisi("Fatma","DORDUNCU", "456789123"),
                new Kisi("Zeynep", "BESINCI", "567891234"),
            };
        }
    }
}