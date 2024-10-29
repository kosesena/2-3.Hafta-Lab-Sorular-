using System;

class Program
{
    static void Main()
    {
        Console.Write("Matris boyutunu girin (N): ");
        int N = int.Parse(Console.ReadLine());

        int[,] energyMatrix = new int[N, N];
        Console.WriteLine("Enerji matrisini satır satır girin (her satırdaki değerleri boşlukla ayırın):");

        for (int i = 0; i < N; i++)
        {
            string[] row = Console.ReadLine().Split(' ');

            // Satırda eksik veya fazla değer olup olmadığını kontrol edin
            if (row.Length != N)
            {
                Console.WriteLine("Hata: Lütfen her satırda tam olarak " + N + " adet enerji değeri girin.");
                i--; // Kullanıcıdan tekrar aynı satırı girmesini isteyin
                continue;
            }

            for (int j = 0; j < N; j++)
            {
                // Geçerli bir tam sayı olup olmadığını kontrol edin
                if (!int.TryParse(row[j], out energyMatrix[i, j]))
                {
                    Console.WriteLine("Hata: Lütfen yalnızca geçerli tam sayılar girin.");
                    i--; // Kullanıcıdan tekrar aynı satırı girmesini isteyin
                    break;
                }
            }
        }

        int minEnergy = FindMinEnergyPath(energyMatrix, N);
        Console.WriteLine("En az harcanan enerji miktarı: " + minEnergy);

        // Programın kapanmasını önlemek için bekletme
        Console.WriteLine("Çıkmak için bir tuşa basın...");
        Console.ReadKey();
    }

    static int FindMinEnergyPath(int[,] energyMatrix, int N)
    {
        int[,] dp = new int[N, N];
        dp[0, 0] = energyMatrix[0, 0]; // Başlangıç noktasının maliyeti

        // İlk satırı doldur
        for (int j = 1; j < N; j++)
        {
            dp[0, j] = dp[0, j - 1] + energyMatrix[0, j];
        }

        // İlk sütunu doldur
        for (int i = 1; i < N; i++)
        {
            dp[i, 0] = dp[i - 1, 0] + energyMatrix[i, 0];
        }

        // Diğer hücreleri doldur
        for (int i = 1; i < N; i++)
        {
            for (int j = 1; j < N; j++)
            {
                // Her hücreye sağ, aşağı, veya sağ-alt diyagonalden gelebiliriz
                int minEnergy = Math.Min(dp[i - 1, j], dp[i, j - 1]);
                minEnergy = Math.Min(minEnergy, dp[i - 1, j - 1]);
                dp[i, j] = minEnergy + energyMatrix[i, j];
            }
        }

        // Hedef hücreye ulaşmak için gereken minimum enerji
        return dp[N - 1, N - 1];
    }
}