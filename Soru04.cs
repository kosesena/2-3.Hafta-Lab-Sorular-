using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Soru4
{
    class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("Bir Matematiksel ifade girin: ");
                string ifade = Console.ReadLine();
                //DataTable kullanarak ifadeyi hesapla
                DataTable dt = new DataTable();
                var sonuc = dt.Compute(ifade, "");

                Console.WriteLine($"\nİfadenin sonucu: {sonuc}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bir hata oluştu: " + ex.Message);
            }

            // Programın kapanmaması için bekleme
            Console.WriteLine("Çıkmak için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}
