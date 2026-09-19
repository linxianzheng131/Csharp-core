using System;

namespace Lesson15_封装_万物之父和装箱拆箱
{
    #region 里氏替换知识点回顾
    // 概念：父类容器装子类对象
    // 作用：方便进行对象存储和管理
    // 使用：
    // is和as
    // is用于判断
    // as用于转换
    class Father
    {
        // 父类，作为所有子类的基类
    }

    class Son : Father
    {
        // 子类，继承自Father，可被父类容器存储
        public void Speak()
        {
            Console.WriteLine("Son 正在说话！");
        }
    }
    #endregion

    #region 知识点一 万物之父
    // 万物之父
    // 关键字：object
    // 概念：
    // object是所有类型的基类，它是一个类（引用类型）
    // 作用：
    // 1. 可以利用里氏替换原则，用object容器装所有对象
    // 2. 可以用来表示不确定类型，作为函数参数类型
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("万物之父和装箱拆箱");

            #region 知识点二 万物之父的使用
            // 里氏替换：父类引用指向子类对象
            Object f = new Son();
            if (f is Son)
            {
                // as 转换：安全转换，失败返回null而非抛异常
                (f as Son).Speak();
            }
            //引用类型也需要装箱拆箱吗？不需要，装箱拆箱只针对值类型
            // 但引用类型也可以用object存储，利用里氏替换原则进行类型判断和转换
            // 但值类型需要装箱拆箱：用object存储值类型会触发装箱，转换回值类型会触发拆箱
            // 但特殊的string类型虽然是引用类型，但也可以用object存储，并且转换时不需要装箱拆箱，直接转换即可
            // 数组类型也是引用类型，可以用object存储，并且转换时不需要装箱拆箱，直接转换即可
            // 总结：object作为万物之父，可以存储任意类型的对象，但值类型会触发装箱拆箱，引用类型则不需要
            

            // 引用类型：用object存储自定义类对象
            object o = new Son();
            if (o is Son)
            {
                // is 判断：先判断类型，再安全转换
                (o as Son).Speak();
            }

            // 值类型：用object存储值类型（触发装箱）
            object o2 = 1f;
            // 强转：从object拆箱回原值类型
            float f1 = (float)o2;

            // 特殊的string类型（引用类型，但特殊处理）
            object str = "123123";
            // as 转换字符串：安全转换引用类型
            string str2 = str as string;

            // 数组类型：用object存储数组（引用类型）
            object arr = new int[10];
            // as 转换数组：安全还原数组类型
            int[] ar = arr as int[];
            #endregion

            #region 知识点三 装箱拆箱
            // 发生条件
            // 用object存值类型（箱装）
            // 再把object转为值类型（拆箱）

            // 装箱
            // 把值类型用引用类型存储
            // 栈内存会迁移到堆内存中
            object v = 3; // 装箱：int -> object

            // 拆箱
            // 把引用类型存储的值类型取出来
            // 堆内存会迁移到栈内存中
            int intValue = (int)v; // 拆箱：object -> int

            // 测试可变参数函数：利用object存储任意类型参数
            TestFun(1, 2, 3, 4f, 34.5, "123123", new Son());

            // 总结：
            // 万物之父：object
            // 基于里氏替换原则的 可以用object容器装载一切类型的变量
            // 它是所有类型的基类

            // 装箱拆箱
            // 用object存值类型（装箱）
            // 把object里面存的值 转换出来(拆箱)
            // 好处
            // 不去定类型时可以用 方便参数存储和传递
            // 坏处
            // 存在内存的迁移 增加了性能消耗
            // 不是不用，尽量少用
            #endregion
        }

        #region 可变参数函数：利用object实现任意参数接收
        // 可变参数params：允许传入任意数量、任意类型的参数
        // 底层通过object[]数组存储所有参数，利用万物之父特性实现通用化
        static void TestFun(params object[] array)
        {
            // 可遍历array，处理任意类型的传入参数
            foreach (var item in array)
            {
                Console.WriteLine($"参数类型：{item?.GetType().Name}，值：{item}");
            }
        }
        #endregion
    }
}