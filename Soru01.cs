using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiziAlgoritmasi // namespace ArrayAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            // Getting array elements from the user
            // Kullanıcıdan dizi elemanlarını alma
            Console.Write("Dizi eleman sayısını girin: "); // ("Enter the number of elements in the array: ")
           
            int n = int.Parse(Console.ReadLine());
            int[] dizi = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Dizinin {i + 1}. elemanını girin: "); // Enter the {i+1}th element of the array
                dizi[i] = int.Parse(Console.ReadLine()); // array[i] = int.Parse(Console.ReadLine())
            }

            // Sorting the array
            // Diziyi sıralama
            Array.Sort(dizi); // (array)
            
            Console.WriteLine("Sıralı dizi: " + string.Join(", ", dizi)); // ("Sorted array: ")

            //Taking a number from the user and checking it using binary search
            //Kullanıcıdan bir sayı alıp ikili arama ile kontrol etme
            Console.Write("Aranacak sayıyı girin: "); // ("Enter the number to search: ")
           
            int aranan = int.Parse(Console.ReadLine()); // int searched
           
            bool bulundu = Array.BinarySearch(dizi, aranan) >= 0; // bool found

            if (bulundu) 
                Console.WriteLine($"{aranan} sayısı dizide bulundu. "); // ($"{searched} number was found in the array. ")
            else
                Console.WriteLine($"{aranan} sayısı dizide bulunamadı. "); // ($"{searched} number was not found in the array. ")
        }
    }
}

