using System;
using System.Text;

#region 题目1：string与StringBuilder的核心区别（带代码示例+注释）
/*
 * 一、string与StringBuilder的核心区别
 * 1. 【不可变性 vs 可变性】
 *    - string：不可变字符串（Immutable），每次修改（拼接、替换等）都会创建新的字符串对象，分配新内存
 *    - StringBuilder：可变字符串（Mutable），在内存中维护一个字符缓冲区，修改时直接操作缓冲区，不创建新对象
 * 
 * 2. 【内存分配机制】
 *    - string：每次修改都会在堆上分配新内存，原对象等待GC回收，频繁修改会产生大量内存碎片
 *    - StringBuilder：预分配缓冲区（默认容量16，不足时自动扩容），修改时复用缓冲区，内存开销极小
 * 
 * 3. 【适用场景】
 *    - string：适合少量、一次性的字符串操作，如常量定义、少量拼接
 *    - StringBuilder：适合大量、循环的字符串操作，如循环拼接、日志生成、字符串高频修改
 * 
 * 4. 【线程安全】
 *    - string：不可变，天然线程安全（多线程读取不会出问题）
 *    - StringBuilder：可变，非线程安全，多线程操作需手动加锁
 * 
 * 5. 【性能对比】
 *    - 少量操作：两者性能几乎无差异
 *    - 大量循环操作：StringBuilder性能远超string（可提升数百倍）
 */

/// <summary>
/// 演示string与StringBuilder的区别+性能对比
/// </summary>
public static class StringVsStringBuilderDemo
{
    /// <summary>
    /// 演示string的不可变性：每次修改创建新对象，内存浪费
    /// </summary>
    public static void StringImmutableDemo()
    {
        Console.WriteLine("===== string不可变性演示 =====");
        string str = "Hello";
        Console.WriteLine($"初始字符串：{str}，哈希值：{str.GetHashCode()}");

        // 看似修改字符串，实际创建新对象，原对象不变
        str += " World";
        Console.WriteLine($"拼接后字符串：{str}，哈希值：{str.GetHashCode()}");
        // 哈希值不同，证明是两个完全不同的对象，原"Hello"对象等待GC回收
    }

    /// <summary>
    /// 演示StringBuilder的可变性：修改复用缓冲区，无新对象创建
    /// </summary>
    public static void StringBuilderMutableDemo()
    {
        Console.WriteLine("\n===== StringBuilder可变性演示 =====");
        StringBuilder sb = new StringBuilder("Hello");
        Console.WriteLine($"初始字符串：{sb}，哈希值：{sb.GetHashCode()}");

        // 直接修改缓冲区，不创建新对象，哈希值不变
        sb.Append(" World");
        Console.WriteLine($"拼接后字符串：{sb}，哈希值：{sb.GetHashCode()}");
        // 哈希值相同，证明是同一个对象，仅修改了缓冲区内容
    }

    /// <summary>
    /// 性能对比：循环拼接10000次，对比string与StringBuilder的耗时
    /// </summary>
    public static void PerformanceComparison()
    {
        Console.WriteLine("\n===== 性能对比（循环拼接10000次） =====");
        int loopCount = 10000;

        // 1. string循环拼接：每次创建新对象，性能极差
        var sw1 = System.Diagnostics.Stopwatch.StartNew();
        string strResult = "";
        for (int i = 0; i < loopCount; i++)
        {
            strResult += i.ToString();
        }
        sw1.Stop();
        Console.WriteLine($"string拼接耗时：{sw1.ElapsedMilliseconds}ms");

        // 2. StringBuilder循环拼接：复用缓冲区，性能极高
        var sw2 = System.Diagnostics.Stopwatch.StartNew();
        StringBuilder sbResult = new StringBuilder();
        for (int i = 0; i < loopCount; i++)
        {
            sbResult.Append(i);
        }
        sw2.Stop();
        Console.WriteLine($"StringBuilder拼接耗时：{sw2.ElapsedMilliseconds}ms");
        // 结果：StringBuilder耗时通常仅为string的1%甚至更低
    }
}
#endregion

#region 题目2：字符串操作的内存优化方案（带代码示例+注释）
/*
 * 二、字符串操作的内存优化核心方案
 * 1. 【优先使用StringBuilder】：大量循环拼接、高频修改场景，彻底避免string的内存碎片
 * 2. 【预分配StringBuilder容量】：提前指定容量，避免频繁扩容，减少内存分配
 * 3. 【避免不必要的字符串分配】：
 *    - 用string.IsNullOrEmpty/IsNullOrWhiteSpace替代空字符串比较
 *    - 用string.AsSpan()避免字符串切片时的内存分配（C# 7.2+）
 *    - 用string.Create()避免中间字符串分配（C# 10+）
 * 4. 【字符串池优化】：
 *    - 字符串留用（Intern）：将字符串存入 intern pool，复用相同字符串，减少内存占用
 *    - 避免动态生成大量重复字符串，优先使用常量
 * 5. 【避免装箱拆箱】：用StringBuilder.Append(int)等重载，避免值类型转字符串时的装箱
 * 6. 【使用Span<char>处理字符串】：栈上分配，无堆内存开销，适合高频字符串处理
 */

/// <summary>
/// 演示字符串操作的内存优化方案
/// </summary>
public static class StringMemoryOptimizationDemo
{
    /// <summary>
    /// 优化1：预分配StringBuilder容量，避免频繁扩容
    /// </summary>
    public static void PreAllocateCapacityDemo()
    {
        Console.WriteLine("===== 预分配StringBuilder容量优化 =====");
        int loopCount = 10000;
        // 预估总长度：每个数字平均2位，预分配20000容量，避免扩容
        StringBuilder sb = new StringBuilder(20000);
        for (int i = 0; i < loopCount; i++)
        {
            sb.Append(i);
        }
        Console.WriteLine("预分配容量完成，无频繁扩容，内存开销极小");
    }

    /// <summary>
    /// 优化2：字符串留用（Intern），复用相同字符串，减少内存占用
    /// </summary>
    public static void StringInternDemo()
    {
        Console.WriteLine("\n===== 字符串留用优化 =====");
        // 动态生成两个相同的字符串
        string str1 = new string('a', 1000);
        string str2 = new string('a', 1000);
        Console.WriteLine($"留用前：str1和str2是否为同一对象：{object.ReferenceEquals(str1, str2)}"); // false，两个不同对象

        // 将str1存入intern pool
        string internedStr = string.Intern(str1);
        // 从intern pool获取str2，复用同一对象
        string str3 = string.IsInterned(str2) ?? string.Intern(str2);
        Console.WriteLine($"留用后：internedStr和str3是否为同一对象：{object.ReferenceEquals(internedStr, str3)}"); // true，复用同一对象
        // 效果：原本占用2份内存，现在仅占用1份，节省50%内存
    }

    /// <summary>
    /// 优化3：使用Span<char>避免堆内存分配（C# 7.2+）
    /// </summary>
    public static void SpanStringDemo()
    {
        Console.WriteLine("\n===== Span<char>内存优化 =====");
        string str = "Hello World";
        // 用Span<char>切片，无堆内存分配，直接操作原字符串
        ReadOnlySpan<char> span = str.AsSpan(0, 5);
        Console.WriteLine($"Span切片结果：{span.ToString()}");
        // 对比：str.Substring(0,5)会创建新字符串，分配堆内存，Span无此开销
    }

    /// <summary>
    /// 优化4：避免不必要的字符串分配，用string.Create()
    /// </summary>
    public static void StringCreateDemo()
    {
        Console.WriteLine("\n===== string.Create()优化 =====");
        // 传统方式：拼接产生中间字符串，分配多次内存
        string str1 = "Hello" + " " + "World";
        // string.Create()：直接在目标内存中构建字符串，无中间分配
        string str2 = string.Create(11, (object?)null, (span, state) =>
        {
            "Hello".AsSpan().CopyTo(span);
            span[5] = ' ';
            "World".AsSpan().CopyTo(span.Slice(6));
        });
        Console.WriteLine($"string.Create()构建结果：{str2}");
        // 效果：减少中间字符串分配，降低内存开销
    }
}
#endregion

/// <summary>
/// 程序主入口：测试所有功能
/// </summary>
internal class Program
{
    static void Main(string[] args)
    {
        #region 题目1测试：string与StringBuilder区别
        StringVsStringBuilderDemo.StringImmutableDemo();
        StringVsStringBuilderDemo.StringBuilderMutableDemo();
        StringVsStringBuilderDemo.PerformanceComparison();
        #endregion

        #region 题目2测试：内存优化方案
        Console.WriteLine("\n===== 内存优化方案演示 =====");
        StringMemoryOptimizationDemo.PreAllocateCapacityDemo();
        StringMemoryOptimizationDemo.StringInternDemo();
        StringMemoryOptimizationDemo.SpanStringDemo();
        StringMemoryOptimizationDemo.StringCreateDemo();
        #endregion

        // 暂停控制台，方便查看结果
        Console.WriteLine("\n按任意键退出...");
        Console.ReadKey();
    }
}