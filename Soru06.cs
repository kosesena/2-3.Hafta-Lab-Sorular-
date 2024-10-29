using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> validDates = new List<string>();

        for (int year = 2000; year <= 3000; year++)
        {
            if (!IsValidYear(year)) continue;

            for (int month = 1; month <= 12; month++)
            {
                if (!IsValidMonth(month)) continue;

                for (int day = 1; day <= DaysInMonth(month, year); day++)
                {
                    if (!IsPrime(day)) continue;

                    // Eğer tüm koşullar sağlanıyorsa tarihi listeye ekle
                    validDates.Add($"{day:D2}/{month:D2}/{year}");
                }
            }
        }

        // Geçerli tarihleri ekrana yazdır
        Console.WriteLine("Geçerli tarihler:");
        foreach (var date in validDates)
        {
            Console.WriteLine(date);
        }

        Console.WriteLine($"Toplam geçerli tarih sayısı: {validDates.Count}");

        // Program kapanmadan önce bekleme
        Console.WriteLine("Çıkmak için bir tuşa basın...");
        Console.ReadKey();
    }

    // Günün asal olup olmadığını kontrol eden fonksiyon
    static bool IsPrime(int number)
    {
        if (number <= 1) return false;
        if (number == 2) return true;

        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
                return false;
        }
        return true;
    }

    // Ayın basamaklarının toplamının çift olup olmadığını kontrol eden fonksiyon
    static bool IsValidMonth(int month)
    {
        int sum = 0;
        while (month > 0)
        {
            sum += month % 10;
            month /= 10;
        }
        return sum % 2 == 0;
    }

    // Yılın basamaklarının toplamının 0, 4 veya 8 olup olmadığını kontrol eden fonksiyon
    static bool IsValidYear(int year)
    {
        int sum = 0;
        while (year > 0)
        {
            sum += year % 10;
            year /= 10;
        }
        return sum == 0 || sum == 4 || sum == 8;
    }

    // Belirli bir ay için gün sayısını döndüren fonksiyon (eski sürümler için switch yapısıyla)
    static int DaysInMonth(int month, int year)
    {
        switch (month)
        {
            case 4:
            case 6:
            case 9:
            case 11:
                return 30;
            case 2:
                return DateTime.IsLeapYear(year) ? 29 : 28;
            default:
                return 31;
        }
    }
}
