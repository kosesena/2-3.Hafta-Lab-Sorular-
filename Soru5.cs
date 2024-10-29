using System;
using System.Collections.Generic;

class Program
{
    // Polinomu analiz eden fonksiyon
    static Dictionary<int, int> ParsePolynomial(string input)
    {
        var terms = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var polynomial = new Dictionary<int, int>();

        foreach (var term in terms)
        {
            int coefficient = 0;
            int power = 0;

            if (term.Contains("x^"))
            {
                var parts = term.Split(new[] { "x^" }, StringSplitOptions.None);
                coefficient = (parts[0] == "" || parts[0] == "+") ? 1 : (parts[0] == "-" ? -1 : int.Parse(parts[0]));
                power = int.Parse(parts[1]);
            }
            else if (term.Contains("x"))
            {
                var parts = term.Split('x');
                coefficient = (parts[0] == "" || parts[0] == "+") ? 1 : (parts[0] == "-" ? -1 : int.Parse(parts[0]));
                power = 1;
            }
            else
            {
                if (!int.TryParse(term, out coefficient))
                {
                    coefficient = 0;
                }
                power = 0;
            }

            if (polynomial.ContainsKey(power))
                polynomial[power] += coefficient;
            else
                polynomial[power] = coefficient;
        }

        return polynomial;
    }

    // İki polinomu toplama fonksiyonu
    static Dictionary<int, int> AddPolynomials(Dictionary<int, int> poly1, Dictionary<int, int> poly2)
    {
        var result = new Dictionary<int, int>(poly1);

        foreach (var term in poly2)
        {
            if (result.ContainsKey(term.Key))
                result[term.Key] += term.Value;
            else
                result[term.Key] = term.Value;
        }

        return result;
    }

    // İki polinomu çıkarma fonksiyonu
    static Dictionary<int, int> SubtractPolynomials(Dictionary<int, int> poly1, Dictionary<int, int> poly2)
    {
        var result = new Dictionary<int, int>(poly1);

        foreach (var term in poly2)
        {
            if (result.ContainsKey(term.Key))
                result[term.Key] -= term.Value;
            else
                result[term.Key] = -term.Value;
        }

        return result;
    }

    // Polinomu string olarak formatlama fonksiyonu
    static string FormatPolynomial(Dictionary<int, int> poly)
    {
        var result = new List<string>();

        foreach (var term in poly)
        {
            if (term.Value == 0) continue;

            string coeff = term.Value > 0 && result.Count > 0 ? "+" + term.Value : term.Value.ToString();
            string power = term.Key == 0 ? "" : (term.Key == 1 ? "x" : "x^" + term.Key);
            result.Add(coeff + power);
        }

        return string.Join(" ", result);
    }

    static void Main()
    {
        Console.Write("İlk polinomu girin (örneğin, 2x^2 + 3x - 5): ");
        string input1 = Console.ReadLine();

        Console.Write("İkinci polinomu girin (örneğin, x^2 - 4): ");
        string input2 = Console.ReadLine();

        var poly1 = ParsePolynomial(input1);
        var poly2 = ParsePolynomial(input2);

        var sum = AddPolynomials(poly1, poly2);
        var difference = SubtractPolynomials(poly1, poly2);

        Console.WriteLine("Toplam: " + FormatPolynomial(sum));
        Console.WriteLine("Fark: " + FormatPolynomial(difference));

        // Çıkmak için uyarı ekleme
        Console.WriteLine("Çıkmak için bir tuşa basın...");
        Console.ReadKey();
    }
}