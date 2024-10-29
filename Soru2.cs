using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soru2
{
    class Program
    {
        static void Main()
        {
            List<int> sayilar = new List<int>();
            int sayi;

            //Kullanıcıdan pozitif tam sayı alma işlemi
            do

            {
                Console.Write("Bir pozitif tam sayı girin(0 yazarak tam sayı alma işlemini bitir): ");
                sayi = int.Parse(Console.ReadLine());

                if (sayi > 0)
                {
                    sayilar.Add(sayi);
                }
                else if (sayi != 0)
                {
                    Console.WriteLine("Lütfen geçerli bir tam sayı girin. ");
                }

            } while (sayi != 0);   // Kullanıcı 0 girene kadar devam eder

            //Kullanıcı 0 girdikten sonra ortalama ve medyanı hesaplama

            if (sayilar.Count > 0)
            {
           
            //Ortalama hesaplama
                double ortalama = sayilar.Average();
                Console.WriteLine("\nOrtalama: " + ortalama);

            //Medyan hesaplama
                sayilar.Sort();
                double medyan;
                int ortaIndex = sayilar.Count / 2;
                if (sayilar.Count % 2 == 0) //Çift sayı varsa ortadaki iki sayının ortalaması
                {
                    medyan = (sayilar[ortaIndex - 1] + sayilar[ortaIndex]) / 2.0;
                }
                else //Tek sayı varsa,ortadaki sayı medyan
                {
                    medyan = sayilar[ortaIndex];
                }
                Console.WriteLine("Medyan: " + medyan);
            }
            else
            {
                Console.WriteLine("Geçerli bir sayı girilmedi. ");
            }
            // Sonuçları görmek için programın kapanmasını engelleme
            Console.WriteLine("Çıkmak için bir tuşa basın... ");
            Console.ReadKey();
        }

    }
}
