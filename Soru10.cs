using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int[] numbers = { 3, 8, 2, 5 }; // Örnek sayı dizisi
        List<string> expressions = new List<string>();

        // Rekürsif fonksiyonla tüm kombinasyonları oluştur
        GenerateExpressions(numbers, 1, numbers[0].ToString(), expressions);

        Console.WriteLine("Sıfırdan büyük sonuçlar:");
        foreach (var expr in expressions)
        {
            double result = EvaluateExpression(expr);
            if (result > 0)
            {
                Console.WriteLine($"{expr} = {result}");
            }
        }

        // Programın kapanmasını önlemek için bekleme
        Console.WriteLine("Çıkmak için bir tuşa basın...");
        Console.ReadKey();
    }

    // Operatör kombinasyonlarını oluşturan fonksiyon
    static void GenerateExpressions(int[] numbers, int index, string currentExpr, List<string> expressions)
    {
        if (index == numbers.Length)
        {
            expressions.Add(currentExpr);
            return;
        }

        // Her operatör için ayrı çağrılar yapılır
        GenerateExpressions(numbers, index + 1, currentExpr + "+" + numbers[index], expressions);
        GenerateExpressions(numbers, index + 1, currentExpr + "-" + numbers[index], expressions);
        GenerateExpressions(numbers, index + 1, currentExpr + "*" + numbers[index], expressions);
        GenerateExpressions(numbers, index + 1, currentExpr + "/" + numbers[index], expressions);
    }

    // İfadeyi değerlendiren fonksiyon
    static double EvaluateExpression(string expression)
    {
        System.Data.DataTable table = new System.Data.DataTable();
        try
        {
            return Convert.ToDouble(table.Compute(expression, string.Empty));
        }
        catch
        {
            return double.MinValue; // Hatalı bir ifade olması durumunda minimum değeri döndür
        }
    }
}