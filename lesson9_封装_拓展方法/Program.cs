using System;

namespace Lesson9_封装_拓展方法
{
    #region 知识回顾
    /// <summary>
    /// 类的基本构成
    /// </summary>
    class 类名
    {
        // 特征—成员变量
        // 行为—成员方法
        // 初始化调用—构造函数
        // 释放时调用—析构函数
        // 成员属性
        // 索引器
        // 静态成员
    }

    // 静态类和静态构造函数
    #endregion

    #region 知识点一 拓展方法基本概念
    /// <summary>
    /// 拓展方法基本概念
    /// 
    /// 概念：
    /// 为现有非静态变量类型添加新方法
    /// 
    /// 作用：
    /// 1. 提升程序拓展性
    /// 2. 不需要再对象中重新写方法
    /// 3. 不需要继承来添加方法
    /// 4. 为别人封装的类型写额外的方法
    /// 
    /// 特点：
    /// 1. 一定是写在静态类中
    /// 2. 一定是个静态函数
    /// 3. 第一个参数为拓展目标
    /// 4. 第一个参数用this修饰
    /// 
    /// 注意：
    /// - 可以有返回值和n个参数，根据需求而定
    /// - 拓展方法本质上是静态方法的语法糖，编译后会被转换为静态方法调用
    /// </summary>
    #endregion

    #region 知识点二 基本语法
    /// <summary>
    /// 基本语法
    /// 
    /// 访问修饰符 static 返回值 函数名(this 拓展类名 参数名, 参数类型 参数名, ...)
    /// {
    ///     // 方法逻辑
    /// }
    /// 
    /// 说明：
    /// - this：必须修饰在第一个参数前，表示这是一个拓展方法
    /// - 拓展类名：要为哪个类型添加方法，就写哪个类型
    /// - 参数名：代表调用该方法的实例对象
    /// </summary>
    #endregion

    #region 知识点三 实例（基础类型拓展）
    /// <summary>
    /// 拓展方法工具类
    /// 所有拓展方法都必须定义在静态类中
    /// </summary>
    public static class ExtensionTools
    {
        /// <summary>
        /// 为int拓展了一个成员方法
        /// value 代表使用该方法的实例化对象
        /// </summary>
        /// <param name="value">调用该方法的int对象</param>
        public static void SpeakValue(this int value)
        {
            Console.WriteLine("【拓展方法】唐老狮为int拓展的方法，值为：" + value);
        }

        /// <summary>
        /// 为string拓展的方法
        /// </summary>
        /// <param name="str">调用该方法的string对象</param>
        /// <param name="str2">传递的参数1</param>
        /// <param name="str3">传递的参数2</param>
        public static void SpeakStringInfo(this string str, string str2, string str3)
        {
            Console.WriteLine("【拓展方法】唐老狮为string拓展的方法");
            Console.WriteLine("调用方法的对象：" + str);
            Console.WriteLine("传的参数：" + str2 + " | " + str3);
        }
    }
    #endregion

    #region 知识点五 为自定义的类型拓展方法
    /// <summary>
    /// 自定义测试类
    /// </summary>
    public class Test
    {
        public int i = 10;        
        public void Fun1()
        {
            Console.WriteLine("【实例方法】Test类自带的 Fun1：123");
        }

        /// <summary>
        /// 成员方法Fun2（重点：与后续拓展方法同名同参）
        /// </summary>
        public void Fun2()
        {
            Console.WriteLine("【实例方法】Test类自带的 Fun2：456");
        }
    }
    #endregion

    #region 知识点六 冲突优先级（核心补充）
    /// <summary>
    /// 专门用于测试冲突的拓展方法类
    /// </summary>
    public static class ConflictExtension
    {
        /// <summary>
        /// 拓展方法 Fun2
        /// 特征：与 Test 类内部的实例方法 Fun2 完全同名、同参数列表
        /// </summary>
        /// <param name="t">调用该方法的Test对象</param>
        public static void Fun2(this Test t)
        {
            Console.WriteLine("【拓展方法】为 Test 类拓展的 Fun2：我是备胎方法");
        }

        /// <summary>
        /// 拓展方法 Fun2（重载版）
        /// 特征：方法名相同，但参数不同，不会冲突
        /// </summary>
        /// <param name="t">调用该方法的Test对象</param>
        /// <param name="msg">自定义消息</param>
        public static void Fun2(this Test t, string msg)
        {
            Console.WriteLine("【拓展方法】为 Test 类拓展的重载 Fun2，消息：" + msg);
        }
    }

    /// <summary>
    /// 优先级总结：
    /// 1. 实例方法（类内部定义的）优先级最高。
    /// 2. 当拓展方法与实例方法签名完全一致时，编译器会优先调用实例方法，拓展方法会被“屏蔽”。
    /// 3. 只有当类中没有同名同参的实例方法时，拓展方法才会生效。
    /// 4. 方法重载规则依然适用（参数不同则视为不同方法，无冲突）。
    /// </summary>
    #endregion

    /// <summary>
    /// 主程序入口
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {            
            #region 知识点四 基础使用
            Console.WriteLine("【1. 基础类型拓展调用】");
            int num = 10;
            num.SpeakValue(); // 调用 int 的拓展方法

            string str = "000";
            str.SpeakStringInfo("唐老狮", "111"); // 调用 string 的拓展方法
            Console.WriteLine();
            #endregion

            #region 知识点七 冲突测试（核心演示）
            Console.WriteLine("【2. 冲突优先级测试】");
            Test t = new Test();

            // 情况1：调用唯一的方法（无冲突）
            t.Fun1();

            // 情况2：调用 同名同参 方法（有冲突）
            // 结果：优先调用 Test 类内部的 实例方法，拓展方法被忽略
            t.Fun2();

            // 情况3：调用 同名不同参 方法（无冲突）
            // 结果：调用拓展方法的重载版本
            t.Fun2("我不会冲突，因为参数不同");

            Console.WriteLine();
            Console.WriteLine("★ 结论：实例方法永远优先于拓展方法！");
            #endregion

            // 防止控制台一闪而过
            Console.WriteLine();
            Console.WriteLine("按任意键退出...");
            Console.ReadKey();
        }
    }
}
