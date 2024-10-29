using System;
using System.Collections.Generic;

class Program
{
    static int M = 5; // Labirentin satır sayısı
    static int N = 5; // Labirentin sütun sayısı
    static bool[,] visited;

    static void Main()
    {
        visited = new bool[M, N];

        // Her hücrenin geçerli olup olmadığını göstermek için
        Console.WriteLine("Labirent Geçerli Hücre Haritası:");
        for (int i = 0; i < M; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write(IsValidCell(i, j) ? "O " : "X ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("\nYol aranmaya başlandı...");
        bool result = DFS(0, 0);

        if (result)
            Console.WriteLine("Yol bulundu!");
        else
            Console.WriteLine("Şehir kayboldu!");

        // Programın kapanmasını önlemek için bekletme
        Console.WriteLine("Çıkmak için bir tuşa basın...");
        Console.ReadKey();
    }

    // Derinlik öncelikli arama (DFS) fonksiyonu
    static bool DFS(int x, int y)
    {
        // Geçerli hücre bilgisi
        Console.WriteLine($"Hücre ({x}, {y}) kontrol ediliyor...");

        // Hedefe ulaştık mı?
        if (x == M - 1 && y == N - 1)
        {
            Console.WriteLine("Hedefe ulaşıldı!");
            return true;
        }

        // Sınırların dışına çıkıyorsak veya bu hücreyi daha önce ziyaret ettiysek geri dön
        if (x < 0 || y < 0 || x >= M || y >= N || visited[x, y] || !IsValidCell(x, y))
        {
            Console.WriteLine($"Hücre ({x}, {y}) geçersiz veya daha önce ziyaret edilmiş.");
            return false;
        }

        // Bu hücreyi ziyaret ettik olarak işaretle
        visited[x, y] = true;

        // Yukarı, aşağı, sola, sağa git
        if (DFS(x + 1, y) || DFS(x - 1, y) || DFS(x, y + 1) || DFS(x, y - 1))
            return true;

        // Bu hücreden çıkarken ziyaret edilmiş işaretini kaldır
        visited[x, y] = false;
        return false;
    }

    // Hücrenin geçerli olup olmadığını kontrol eden fonksiyon
    static bool IsValidCell(int x, int y)
    {
        // Koşul 1: x ve y koordinatlarının her iki basamağı da asal sayı olmamalı
        if (IsPrimeDigit(x) && IsPrimeDigit(y))
            return false;

        // Koşul 2: x ve y toplamı, x ve y çarpımına tam bölünmeli
        if ((x + y) != 0 && (x * y) % (x + y) != 0)
            return false;

        return true;
    }

    // Bir sayının basamaklarının asal olup olmadığını kontrol eden fonksiyon
    static bool IsPrimeDigit(int num)
    {
        while (num > 0)
        {
            int digit = num % 10;
            if (digit == 2 || digit == 3 || digit == 5 || digit == 7)
                return true;
            num /= 10;
        }
        return false;
    }
}