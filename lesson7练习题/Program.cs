using System;

namespace StaticAndConstQuestions
{
    #region 题目1：请说出const和static的区别
    /*
     * 题目：请说出const和static的区别
     * 
     * 回答：
     * 1. 本质与初始化：
     *    - const：编译时常量，必须在声明时直接赋值，且值不可修改。
     *    - static：属于类的成员，可在声明或静态构造函数中初始化，运行时可修改（static readonly除外）。
     * 
     * 2. 修饰范围：
     *    - const：只能修饰字段（变量）。
     *    - static：可以修饰字段、方法、类、属性、构造函数等。
     * 
     * 3. 内存特性：
     *    - const：无独立内存空间，编译时直接替换为常量值。
     *    - static：类加载时分配内存，与程序生命周期一致。
     * 
     * 4. 访问方式：
     *    - const：通过类名访问（隐式静态）。
     *    - static：通过类名访问，也可通过实例访问（不推荐）。
     */
    #endregion

    #region 题目2：请用静态成员相关知识实现一个类对象，在整个应用程序的生命周期中，有且仅会有一个该对象的存在，不能在外部实例化，直接通过该类类名就能够得到唯一的对象
    /*
     * 题目：请用静态成员相关知识实现一个类对象，在整个应用程序的生命周期中，有且仅会有一个该对象的存在，不能在外部实例化，直接通过该类类名就能够得到唯一的对象
     * 
     * 回答：使用单例模式（饿汉式）实现，核心是静态成员+私有构造函数：
     */
    public class Singleton
    {
        // 静态成员存储唯一实例
        private static readonly Singleton _instance = new Singleton();

        // 私有构造函数，禁止外部实例化
        private Singleton() { }

        // 静态方法提供唯一实例
        public static Singleton GetInstance()
        {
            return _instance;
        }

        // 示例方法
        public void ShowMessage()
        {
            Console.WriteLine("这是唯一的单例对象");
        }
    }
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            // 测试单例
            Singleton instance = Singleton.GetInstance();
            instance.ShowMessage();
        }
    }
}
