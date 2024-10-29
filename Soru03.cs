using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soru3
{
    class Program
    {
        static void Main()
        {
            List<int> sayilar = new List<int>();
            int sayi;

            //Kullanıcıdan sayı alma işlemi
            do
            {
                Console.Write("Bir sayı girin(0 ile tam sayı alma işlemini bitirin.): ");
                sayi = int.Parse(Console.ReadLine());
                if (sayi != 0)
                    sayilar.Add(sayi);
            } while (sayi != 0); //Kullanıcı 0 girene kadar devam eder
            //Dizideki ardışık sayı gruplarını bulma
            if (sayilar.Count > 1)
            {
                sayilar.Sort(); // Diziyi sıralıyoruz
                List<string> gruplar = new List<string>();
                int baslangic = sayilar[0];
                int onceki = sayilar[0];
                bool ardisikGrupVar = false;

                for (int i = 1; i < sayilar.Count; i++)
                {
                    // Ardışık ise işaretle
                    if (sayilar[i] == onceki + 1)
                    {
                        ardisikGrupVar = true;
                    }
                    else
                    {
                        //Eğer ardışık bir grup varsa grubu ekle
                        if (ardisikGrupVar)
                        {
                            if (baslangic == onceki)
                                gruplar.Add(baslangic.ToString());
                            else

                                gruplar.Add(baslangic + "-" + onceki);
                        }
                        // Yeni grup başlangıcını ayarla
                            baslangic = sayilar[i];

                           ardisikGrupVar = false;
                     }
                    
                    onceki = sayilar[i];

                }
                //Son grubu ekle
                if (ardisikGrupVar)
                {
                    if (baslangic == onceki)
                        gruplar.Add(baslangic.ToString());
                    else
                        gruplar.Add(baslangic + "-" + onceki);

                }
               
                //Grupları ekrana yazdır

                Console.WriteLine("Ardışık Sayı Grupları: ");
                foreach (var grup in gruplar)
                {
                    Console.WriteLine(grup);
                }
            }
            else
            {
                Console.WriteLine("Geçerli bir sayı girilmedi. ");
            }
            //Programın kapanmaması için bekleme
            Console.WriteLine("Çıkmak için bir tuşa basın...");
            Console.ReadKey();

        }
    }
}
