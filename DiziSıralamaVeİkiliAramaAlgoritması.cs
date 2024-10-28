using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiziAlgoritmasi
{
    class Program
    {
        static void Main(string[] args)
        {
            //Kullanıcıdan dizi elemanlarını alma
            Console.Write("Dizi eleman sayısını girin: ");
            int n = int.Parse(Console.ReadLine());
            int[] dizi = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Dizinin {i + 1}. elemanını girin: ");
                dizi[i] = int.Parse(Console.ReadLine());
            }

            //Diziyi sıralama
            Array.Sort(dizi);
            Console.WriteLine("Sıralı dizi: " + string.Join(", ", dizi));

            //Kullanıcıdan bir sayı alıp ikili arama ile kontrol etme
            Console.Write("Aranacak sayıyı girin: ");
            int aranan = int.Parse(Console.ReadLine());
            bool bulundu = Array.BinarySearch(dizi, aranan) >= 0;

            if (bulundu)
                Console.WriteLine($"{aranan} sayısı dizide bulundu. ");
            else
                Console.WriteLine($"{aranan} sayısı dizide bulunamadı. ");
        }
    }
}

