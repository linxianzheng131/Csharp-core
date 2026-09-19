using System;
using System.Data;

#region 一、口头描述：什么是装箱和拆箱
/// <summary>
/// 【口头描述】
/// 1. 装箱（Boxing）：
///    - 将【值类型】（如 int、float、struct 等）转换为【引用类型】（如 object、接口类型）的过程。
///    - 本质：在堆上分配内存，将栈上的值类型数据拷贝到堆上的对象中，再返回这个堆对象的引用。
///    - 例子：int i = 123; object obj = i;  // 把 int 装进 object
///
/// 2. 拆箱（Unboxing）：
///    - 将【引用类型】（已装箱的值类型对象）转换回【值类型】的过程。
///    - 本质：先检查引用类型是否是该值类型的装箱实例，再将堆上的数据拷贝回栈上的值类型变量。
///    - 例子：object obj = 123; int i = (int)obj;  // 把 object 里的 int 拆出来
///
/// 3. 核心特点：
///    - 装箱/拆箱都会发生【内存拷贝】，性能开销较大，应尽量避免。
///    - 拆箱需要【强制类型转换】，且类型必须匹配，否则会抛出异常。
/// </summary>
#endregion

#region 二、代码描述：装箱和拆箱的示例
class Program
{
    static void Main(string[] args)
    {
        // --------------------------
        // 1. 装箱示例
        // --------------------------
        int intValue = 996;          // 栈上的值类型变量
        object boxedValue = intValue;// 装箱：int → object
        Console.WriteLine($"装箱后：boxedValue = {boxedValue}，类型：{boxedValue.GetType().Name}");

        // --------------------------
        // 2. 拆箱示例
        // --------------------------
        int unboxedValue = (int)boxedValue; // 拆箱：object → int（必须强转）
        Console.WriteLine($"拆箱后：unboxedValue = {unboxedValue}，类型：{unboxedValue.GetType().Name}");

        // --------------------------
        // 3. 错误拆箱示例（类型不匹配会报错）
        // --------------------------
        // long wrongUnbox = (long)boxedValue; // 编译通过，但运行时抛出 InvalidCastException
        //拆箱一定要拆成原来的类型不能直接隐式转换 下面这样先拆出来在隐式转换就可以
        long l = (int)boxedValue;
        Console.WriteLine($"拆箱后：l = {l}，类型：{l.GetType().Name}");
    }
}
#endregion