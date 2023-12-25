using System;
using System.Collections.Generic;

namespace telefon_uygulamasi
{
    abstract class Yardimci : Rehber
    {

        protected void Yazdir(sabitler talep)
        {
            Console.WriteLine(ifadeler[(int)talep]);
        }

        string[] ifadeler = new string[]
        {
            "*****************",
            "Gecersiz veri girisi yaptiniz, lütfen sizden istenen talimatlara uyun",
            "Islem iptal edildi.",
            "Hehangi bir sonuc bulunamadi! Tekrar denemek istermisiniz?"
        };

        protected bool EvetHayir()
        {
        Tekrar:
            Console.WriteLine("(E) Evet / (H) Hayir");
            switch (Console.ReadLine().ToLower())
            {
                case "e":
                    return true;
                case "h":
                    Yazdir(sabitler.Iptal);
                    return false;
                default:
                    Yazdir(sabitler.Gecersiz);
                    goto Tekrar;
            }
        }
        protected string Giris()
        {
            Yazdir(sabitler.Cizgi);
            Console.WriteLine("Yapmak istediginiz slemi seciniz!");
            Yazdir(sabitler.Cizgi);
            Console.WriteLine("(1) Yeni Kisi Ekle");
            Console.WriteLine("(2) Vrolan Numarayi Sil");
            Console.Write("(3) Varolan Numarayi Güncelle");
            Console.WriteLine("(4) Rehberi Listele");
            Console.WriteLine("(5) Rehberde Arama Yap");
            Console.WriteLine("(6) Rehberden Cik");
            Yazdir(sabitler.Cizgi);
            string secim = Console.ReadLine();
            Yazdir(sabitler.Cizgi);
            return secim;
        }

        protected virtual List<Kisi> Ara(string isim, string soyisim)
        {
            return kisiler.FindAll(I => I.Isim == isim || I.Soyisim == soyisim);
        }

        protected List<Kisi> Ara(string numara)
        {
            return kisiler.FindAll(I => I.TelefonNo == numara);
        }

        protected virtual string[] BilgiAl()
        {
            string[] dizi = new string[3];
            Console.WriteLine("Isim: ");

            dizi[0] = Console.ReadLine();
            Console.WriteLine("Soyisim: ");

            dizi[1] = Console.ReadLine();
            Console.WriteLine("Numara: ");

            dizi[2] = Console.ReadLine();
            return dizi;
        }
    }
}