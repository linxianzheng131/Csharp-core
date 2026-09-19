using System;

#region 1. string 截取 替换 函数名（注释说明）
/*
 截取：
 Substring(int startIndex)
 Substring(int startIndex, int length)

 替换：
 Replace(char oldChar, char newChar)
 Replace(string oldStr, string newStr)
*/
#endregion

#region 2. 字符串转换：1|2|3|4|5|6|7 → 2|3|4|5|6|7|8
public static class Demo2
{
    public static void Run()
    {
        string str = "1|2|3|4|5|6|7";
        string[] parts = str.Split('|');

        // 去掉第一个元素"1"，然后拼接"8"
        string result = string.Join("|", parts, 1, parts.Length - 1) + "|8";

        Console.WriteLine("Demo2 结果：" + result);
    }
}
#endregion

#region 3. string/String、int/Int32、short/Int16、long/Int64 的区别
/*
 都是别名关系，完全相同：

 string  → System.String
 int     → System.Int32
 short   → System.Int16
 long    → System.Int64

 写法不同：C# 关键字 vs BCL 类名
 */
#endregion

#region 4. 分析代码堆分配次数
/*
代码：
string str = null;
str = "123";
string str2 = str;
str2 = "321";
str2 += "123";

分配情况：
//null不指向堆内存  自然就不会分配堆内存
1. "123" → 堆1
2. "321" → 堆2
//= 是改引用
//string是不变的引用类型 不是值类型
//所以是复制地址 自然不会分配堆内存
3. "321123" → 堆3

一共 3 次堆分配。
*/
#endregion

#region 5. 原地反转字符数组（不使用额外空间）
public static class Demo5
{
    public static void Reverse(char[] arr)
    {
        if (arr == null || arr.Length <= 1)
            return;

        int left = 0;
        int right = arr.Length - 1;

        while (left < right)
        {
            char temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;
            //声明的是值类型 不会额外使用空间（值类型在栈内存上 用完就没了）
            //reverse会分配内存 除非使用StringBuilder
            left++;
            right--;
        }
    }

    public static void Run()
    {
        char[] chars = { 'h', 'e', 'l', 'l', 'o' };
        Reverse(chars);
        //这个reverse是自定义的
        Console.WriteLine("Demo5 反转结果：" + new string(chars));
    }
}
#endregion

#region 主函数
class Program
{
    static void Main(string[] args)
    {
        Demo2.Run();
        Demo5.Run();

        Console.WriteLine("\n执行完成，按任意键退出");
        Console.ReadKey();
    }
}
#endregion