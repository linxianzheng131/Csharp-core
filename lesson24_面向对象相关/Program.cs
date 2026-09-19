using System;
using System.Text; // 必须引用 StringBuilder 所在的命名空间

namespace lesson24_面向对象相关_StringBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== C# StringBuilder 常用操作演示 ===");
            Console.WriteLine();

            #region 知识回顾
            // string 是特殊的引用类型
            // 每次重新赋值或者拼接时，都会分配新的内存空间
            // 如果一个字符串需要频繁修改、拼接，会非常浪费内存空间
            // StringBuilder 就是为了解决这个问题诞生的
            #endregion

            #region 知识点 StringBuilder 基础介绍
            // C#提供的一个用于处理字符串的公共类
            // 主要解决的问题是：
            // 修改字符串而不创建新的对象，需要频繁修改和拼接的字符串可以使用它，可以大幅提升性能
            // 使用前，需要引用命名空间：using System.Text;
            #endregion

            #region 初始化 直接指明内容
            // 初始化 StringBuilder，直接传入初始字符串
            StringBuilder str = new StringBuilder("123123123");
            Console.WriteLine("=== 初始化 ===");
            Console.WriteLine($"初始内容：{str}");
            Console.WriteLine();
            #endregion

            #region 容量
            // StringBuilder 存在一个容量的问题，每次往里面增加时，会自动扩容
            Console.WriteLine("=== 容量相关 ===");
            // 获得当前容量（预分配的内存空间大小）
            Console.WriteLine($"当前容量 Capacity：{str.Capacity}");
            // 获得实际字符长度
            Console.WriteLine($"当前长度 Length：{str.Length}");
            Console.WriteLine();
            #endregion

            #region 增删查改替换
            // 增：Append / AppendFormat / Insert
            Console.WriteLine("=== 增操作 ===");
            // Append：在末尾追加内容
            str.Append("4444");
            Console.WriteLine($"Append 后内容：{str}");
            Console.WriteLine($"Append 后长度 Length：{str.Length}");
            Console.WriteLine($"Append 后容量 Capacity：{str.Capacity}");

            // AppendFormat：按格式追加内容（类似 string.Format）
            str.AppendFormat("{0}{1}", 100, 999);
            Console.WriteLine($"AppendFormat 后内容：{str}");
            Console.WriteLine($"AppendFormat 后长度 Length：{str.Length}");
            Console.WriteLine($"AppendFormat 后容量 Capacity：{str.Capacity}");

            // Insert：在指定索引位置插入内容
            str.Insert(0, "唐老狮");
            Console.WriteLine($"Insert(0, \"唐老狮\") 后内容：{str}");
            Console.WriteLine();

            // 删：Remove / Clear
            Console.WriteLine("=== 删操作 ===");
            // Remove：从指定索引开始，删除指定个数的字符
            str.Remove(0, 10);
            Console.WriteLine($"Remove(0,10) 后内容：{str}");

            // Clear：清空所有内容
            // str.Clear();
            // Console.WriteLine($"Clear 后内容：{str}");
            Console.WriteLine();

            // 查：按索引访问单个字符
            Console.WriteLine("=== 查操作 ===");
            Console.WriteLine($"索引1的字符：{str[1]}");
            Console.WriteLine();

            // 改：直接修改指定索引的字符
            Console.WriteLine("=== 改操作 ===");
            str[0] = 'A';
            Console.WriteLine($"修改索引0为'A'后：{str}");
            Console.WriteLine();

            // 替换：Replace
            Console.WriteLine("=== 替换操作 ===");
            str.Replace("1", "唐");
            Console.WriteLine($"Replace(\"1\", \"唐\") 后：{str}");
            Console.WriteLine();
            #endregion

            #region 重新赋值与相等判断
            Console.WriteLine("=== 重新赋值与相等判断 ===");
            // 清空后重新赋值
            str.Clear();
            str.Append("123123");
            Console.WriteLine($"Clear 后 Append 内容：{str}");

            // 判断 StringBuilder 是否和某一个字符串相等
            // 注意：Equals 比较的是 StringBuilder 对象的内容，而非引用
            if (str.Equals("12312"))
            {
                Console.WriteLine("相等");
            }
            else
            {
                Console.WriteLine("不相等");
            }
            // 补充：更推荐的写法：转成 string 再比较
            if (str.ToString() == "123123")
            {
                Console.WriteLine("转string后比较：相等");
            }
            #endregion

            Console.WriteLine("\n=== 演示结束 ===");
            Console.ReadKey();
        }
    }
}
