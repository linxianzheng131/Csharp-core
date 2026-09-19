using System;

namespace Lesson8_封装_静态类和静态构造函数
{
    #region 知识回顾
    /// <summary>
    /// 类的基本组成回顾
    /// </summary>
    class Person
    {
        // 特征——成员变量
        // 行为——成员方法
        // 初始化调用——构造函数
        // 释放时调用——析构函数
        // 成员属性
        // 索引器
        // 静态成员
    }
    #endregion

    #region 知识点一 静态类
    /// <summary>
    /// 静态类示例：工具类
    /// </summary>
    static class Tools
    {
        // 静态成员变量
        public static int testIndex = 0;

        // 静态成员方法
        public static void TestFun()
        {
            // 工具类方法实现
        }

        // 静态成员属性
        public static int TestIndex
        {
            get;
            set;
        }
    }

    // 总结
    // 静态类
    // 用 static 修饰的类
    // 特点
    // 1. 只能包含静态成员
    // 2. 不能实例化
    // 作用
    // 1. 工具类
    // 2. 拓展方法
    #endregion

    #region 知识点二 静态构造函数
    // 概念
    // 在构造函数上加上 static 修饰
    // 特点
    // 1. 静态类和普通类都可以有
    // 2. 不能使用访问修饰符
    // 3. 不能有参数
    // 4. 只会自动调用一次
    // 作用
    // 在静态构造函数中初始化静态变量
    // 使用
    // 1. 静态类中的静态构造函数
    // 2. 普通类中的静态构造函数

    /// <summary>
    /// 静态类中的静态构造函数示例
    /// </summary>
    static class StaticClass
    {
        public static int testInt = 100;
        public static int testInt2 = 100;

        // 静态构造函数
        static StaticClass()
        {
            Console.WriteLine("静态构造函数");
            testInt = 200;
            testInt2 = 300;
        }
    }

    /// <summary>
    /// 普通类中的静态构造函数示例
    /// </summary>
    class Test
    {
        public static int testInt = 200;

        // 静态构造函数
        static Test()
        {
            Console.WriteLine("静态构造");
        }

        // 普通构造函数
        public Test()
        {
            Console.WriteLine("普通构造");
        }
    }
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("静态类和静态构造函数！");

            // 测试静态类及其构造函数
            Console.WriteLine(StaticClass.testInt);
            Console.WriteLine(StaticClass.testInt2);
            Console.WriteLine(StaticClass.testInt);

            // 测试普通类的静态构造函数（只会执行一次）
            Test t = new Test();
            Test t2 = new Test();
        }
    }
}