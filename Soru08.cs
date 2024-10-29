using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.Write("Şifrelenecek mesajı girin: ");
        string message = Console.ReadLine();
        string encryptedMessage = EncryptMessage(message);
        Console.WriteLine("Şifreli mesaj: " + encryptedMessage);

        // Programın kapanmasını önlemek için bekleme
        Console.WriteLine("Çıkmak için bir tuşa basın...");
        Console.ReadKey();
    }

    // Mesajı şifreleyen fonksiyon
    static string EncryptMessage(string message)
    {
        StringBuilder encrypted = new StringBuilder();
        int[] fibonacci = GenerateFibonacciSequence(message.Length);

        for (int i = 0; i < message.Length; i++)
        {
            int asciiValue = (int)message[i];
            int position = i + 1;
            int fibValue = fibonacci[i];

            // Adım 1: Fibonacci Dönüşümü
            int transformedValue = asciiValue * fibValue;

            // Adım 2: Modüler Çözümleme
            if (IsPrime(position))
            {
                transformedValue %= 100; // Eğer pozisyon asal ise 100 ile mod
            }
            else
            {
                transformedValue %= 256; // Eğer pozisyon asal değilse 256 ile mod
            }

            // Adım 3: Şifreleme
            char encryptedChar = (char)transformedValue;
            encrypted.Append(encryptedChar);
        }

        return encrypted.ToString();
    }

    // Fibonacci serisini oluşturan fonksiyon
    static int[] GenerateFibonacciSequence(int length)
    {
        int[] fibonacci = new int[length];
        fibonacci[0] = 1;
        if (length > 1)
            fibonacci[1] = 1;

        for (int i = 2; i < length; i++)
        {
            fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
        }

        return fibonacci;
    }

    // Sayının asal olup olmadığını kontrol eden fonksiyon
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
}
