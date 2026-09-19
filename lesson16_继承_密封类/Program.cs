using System;

namespace lesson16_继承_密封类
{
    #region 知识点一 基本概念
    //密封类：是使用 sealed 密封关键字修饰的类
    //作用：让类无法再被继承
    #endregion

    #region 知识点二 实例
    // 定义父类 Father
    class Father
    {
        // 可添加父类成员（示例：字段、方法、属性等）
        // 例如：public void SayHello() { Console.WriteLine("我是父类 Father"); }
    }

    // 定义密封类 Son，继承自 Father
    // sealed 关键字修饰此类，禁止后续类继承它
    sealed class Son : Father
    {
        // 可添加密封类自身的成员
        // 例如：public void SonSayHi() { Console.WriteLine("我是密封类 Son"); }
    }

    // 尝试继承密封类 Son 会直接编译报错（下方注释模拟报错提示）
    // class T : Son  // 编译错误：密封类不能被继承！
    // {
    //
    // }
    #endregion

    #region 知识点三 作用
    //在面向对象程序的设计中，密封类的主要作用就是不允许最底层子类被继承
    //可以保证程序的规范性、安全性
    //目前对于大家来说 可能用处不大
    //随着大家的成长，以后制作复杂系统或者程序框架时 便能慢慢体会到密封的作用
    #endregion

    // 程序入口
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("密封类 基础示例");

            // 实例化密封类 Son
            Son sonInstance = new Son();
            // 调用密封类成员（若添加了上述方法则可执行）
            // sonInstance.SonSayHi();
            // sonInstance.SayHello(); // 继承自父类 Father 的成员

            Console.ReadLine(); // 暂停控制台，查看输出结果
        }
    }

    #region 总结
    // 关键字：sealed
    // 作用：让类无法再被继承
    // 意义：加强面向对象程序设计的 规范性、结构性、安全性
    #endregion
}