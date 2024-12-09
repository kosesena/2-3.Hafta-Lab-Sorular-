using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soru2 // namespace Question2
{
    class Program
    {
        static void Main()
        {
            List<int> sayilar = new List<int>();    // List<int> numbers = new List<int>()
            
            int sayi;                            // int number

           
            // Process of taking a positive integer from the user
            // Kullanıcıdan pozitif tam sayı alma işlemi
            do

            {
                Console.Write("Bir pozitif tam sayı girin(0 yazarak tam sayı alma işlemini bitir): "); // ("Enter a positive integer(Enter 0 to end the integer input process): ")
                sayi = int.Parse(Console.ReadLine());

                if (sayi > 0)
                {
                    sayilar.Add(sayi);
                }
                else if (sayi != 0)
                {
                    Console.WriteLine("Lütfen geçerli bir tam sayı girin. "); // ("Please enter a valid integer. ")
                }

            } while (sayi != 0);   // Kullanıcı 0 girene kadar devam eder - Continues until the user enters 0

            // Kullanıcı 0 girdikten sonra ortalama ve medyanı hesaplama - Calculate the average and median after the user enters 0

            if (sayilar.Count > 0)
            {
           
            // Ortalama hesaplama - Calculating the average
                double ortalama = sayilar.Average(); // double average
                Console.WriteLine("\nOrtalama: " + ortalama);

            // Medyan hesaplama - Calculating the median
                sayilar.Sort();
                double medyan; // double median
                int ortaIndex = sayilar.Count / 2;
               
                if (sayilar.Count % 2 == 0) //Çift sayı varsa ortadaki iki sayının ortalaması
                {
                    medyan = (sayilar[ortaIndex - 1] + sayilar[ortaIndex]) / 2.0;
                }
                else // Tek sayı varsa,ortadaki sayı medyan - If there is an odd number of elements,the middle number is the median
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
