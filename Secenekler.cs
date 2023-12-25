using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace telefon_uygulamasi
{
    class Secenekler : Yardimci
    {
        private string[] bilgiler;
        private List<Kisi> bulunanlar;
        private Kisi kisi;

        protected void KisiAra()
        {
        Tekrar:
            Console.WriteLine("(1) Isim ve Soyisim ile ara / (2) Numara ile ara");
            switch (Console.ReadLine())
            {
                case "1":
                    bilgiler = BilgiAl();
                    bulunanlar = base.Ara(bilgiler[0], bilgiler[1]);
                    break;
                case "2":
                    Console.WriteLine("Telefon No: ");
                    bulunanlar = base.Ara(Console.ReadLine());
                    break;
                default:
                    Yazdir(sabitler.Gecersiz);
                    goto Tekrar;
            }

            if (bulunanlar.BosMu())
            {
                Yazdir(sabitler.Bulunamadi);
                switch (EvetHayir())
                {
                    case true:
                        goto Tekrar;
                };
            }
            else
            {
                Console.WriteLine("Arama Sonuclariniz: ");
                Yazdir(sabitler.Cizgi);
                bulunanlar.ForEach(I => Console.WriteLine(I));
            }
        }

        protected void Ekle()
        {
            string[] bilgiler = base.BilgiAl();
            kisiler.Add(new Kisi(bilgiler[0], bilgiler[1], bilgiler[2]));
            Console.WriteLine("Kisi Eklendi");
        }

        protected void Sil()
        {
        Tekrar:
            Console.WriteLine("Silinecek kisinin isim ve soyismini arada bosluk olacak sekilde giriniz: ");
            bilgiler = BilgiAl();

            bulunanlar = Ara(bilgiler[0], bilgiler[1]);
            switch (bulunanlar.BosMu())
            {
                case true:
                    Yazdir(sabitler.Bulunamadi);
                    if (EvetHayir())
                    {
                        goto Tekrar;
                    }
                    break;
                case false:
                    kisi = bulunanlar[0];
                    Console.WriteLine($"{kisi.Isim} {kisi.Soyisim} rehberden silinsin mi?");
                    switch (EvetHayir())
                    {
                        case true:
                            kisiler.Remove(kisi);
                            Console.WriteLine("Kisi Silindi");
                            break;
                        case false:
                            Yazdir(sabitler.Iptal);
                            break;
                    }
                    break;
            }
        }

        protected void Guncelle()
        {
        Tekrar:
            bilgiler = BilgiAl();
            bulunanlar = Ara(bilgiler[0], bilgiler[1]);
            switch (bulunanlar.BosMu())
            {
                case true:
                    Yazdir(sabitler.Bulunamadi);
                    if (EvetHayir())
                    {
                        goto Tekrar;
                    }
                    break;
                case false:
                    kisi = bulunanlar[0];
                    Console.WriteLine("Guncellemek istediginiz bilgileri doldurunuz. Istemedşkleriniz bos birakiniz.");

                    bilgiler = base.BilgiAl();
                    kisi.Isim = !string.IsNullOrEmpty(bilgiler[0]) ? bilgiler[0] : kisi.Isim;
                    kisi.Soyisim = !string.IsNullOrEmpty(bilgiler[1]) ? bilgiler[1] : kisi.Soyisim;
                    kisi.TelefonNo = !string.IsNullOrEmpty(bilgiler[1]) ? bilgiler[2] : kisi.TelefonNo;

                    int i = kisiler.IndexOf(bulunanlar[0]);
                    kisiler[i] = kisi;
                    Console.WriteLine("Kisi Guncellendi.");
                    break;
            }
        }

        protected void Listele()
        {
        Tekrar:
            Console.WriteLine("(1) A-Z sirali listele.");
            Console.WriteLine("(2) Z-A Sirali listele.");
            switch (Console.ReadLine())
            {
                case "1":
                    kisiler.OrderBy(I => I.Isim + I.Soyisim + I.TelefonNo).ToList();
                    break;
                case "2":
                    kisiler.OrderByDescending(I => I.Isim + I.Soyisim + I.TelefonNo).ToList();
                    break;
                default:
                    Yazdir(sabitler.Gecersiz);
                    goto Tekrar;
            }
            Console.WriteLine("Telefon Rehberi");
            Yazdir(sabitler.Cizgi);
            kisiler.ForEach(I => Console.WriteLine(I));
            Console.WriteLine("Kisiler Listelendi");
        }

        protected override string[] BilgiAl()
        {
        Tekrar:
            Console.WriteLine("Isim - Soyisim: ");
            bilgiler = Console.ReadLine().DiziYap();
            if (bilgiler.Length != 2)
            {
                Yazdir(sabitler.Gecersiz);
                goto Tekrar;
            }
            return bilgiler;
        }

        protected override List<Kisi> Ara(string isim, string soyisim)
        {
            return kisiler.FindAll(I => I.Isim == isim && I.Soyisim == soyisim);
        }


    }
}