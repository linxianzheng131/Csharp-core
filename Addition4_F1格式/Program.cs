using System;

class Program
{
    static void Main()
    {
        float num = 6.0f / 8; // 结果是 0.75
        // 使用 F1 格式化：保留1位小数，自动四舍五入
        Console.WriteLine(num.ToString("F1"));   // 输出：0.8
        Console.WriteLine($"{num:F1}");         // 输出：0.8（字符串插值写法）
        Console.WriteLine(string.Format("{0:F1}", num)); // 输出：0.8

        //C#中没有printf  也就没有%...的形式输出
    }
}