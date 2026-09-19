using System;

namespace Lesson18_多态_抽象类和抽象方法
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("抽象类和抽象方法");
            

            #region 抽象类的使用限制与里氏替换
            // 抽象不能被实例化
            // Thing t = new Thing(); // 编译错误：抽象类无法直接实例化

            // 但是 可以遵循里氏替换原则 用父类容器装子类
            Thing t = new Water();
            //相当于先进行Water中的构造函数构造出对象然后再用 Thing写一个地址指向这个对象
            //Thing的所有内容必须指向有效 所以用基类装子类没问题（子类有的父类也有） 反之则报错
            #endregion
        }
    }

    #region 知识点一 抽象类
    // 概念
    // 被抽象关键字abstract修饰的类
    // 特点:
    // 1.不能被实例化的类
    // 2.可以包含抽象方法
    // 3.继承抽象类必须重写其抽象方法
    abstract class Thing
    {
        // 抽象类中 封装的所有知识点都可以在其中
        public string name;

        // 可以在抽象类中写抽象函数（需在子类中实现）
        // 示例：public abstract void DoSomething();
    }

    class Water : Thing
    {
        // 继承抽象类后，必须实现所有抽象方法（若有）
    }
    #endregion

    #region 知识点二 抽象函数
    // 又叫 纯虚方法
    // 用abstract关键字修饰的方法
    // 特点:
    // 1.只能在抽象类中申明
    // 2.没有方法体
    // 3.不能是私有的
    // 4.继承后必须实现 用override重写
    abstract class Fruits
    {
        public string name;

        // 抽象方法 是一定不能有函数体的
        public abstract void Bad();

        public virtual void Test()
        {
            
        }
    }

    abstract class BananaTest
    {
        //抽象类不一定要有抽象函数 也可以没有 但是如果有抽象函数 那么这个类必须是抽象类
        public void Bad()
        {
            
        }
    }

    class Apple : Fruits
    {
        // 重写抽象方法
        public override void Bad()
        {
            // 未实现具体逻辑时，默认抛出未实现异常
            throw new NotImplementedException();
        }
    }

    // 对比：虚方法（virtual）
    class TestClass
    {
        // 虚方法可以有方法体，子类可选择是否重写
        //访问修饰符要要和基类一致
        public virtual void Test()
        {
            // 可以选择是否写逻辑
            Console.WriteLine("基类Test方法");
        }
    }

    // 继承虚方法类，可选择性重写
    class Banana : TestClass
    {
        // 重写虚方法（可选）
        public override void Test()
        {
            // 可选：base.Test(); 调用基类逻辑
            Console.WriteLine("Banana重写的Test方法");
        }
    }

    // 多层继承：抽象方法与虚方法的重写链
    class SuperApple : Apple
    {
        // 重写从父类继承的抽象方法
        public override void Bad()
        {
            base.Bad(); // 调用父类基础逻辑
            Console.WriteLine("SuperApple重写的Bad方法");
        }

        // 重写虚方法（继承自TestClass）
        public override void Test()
        {
            base.Test(); // 调用基类Test逻辑
            Console.WriteLine("SuperApple重写的Test方法");
        }
    }
    #endregion

    #region 总结
    // 抽象类 被abstract修饰的类 不能被实例化 可以包含抽象方法
    // 抽象方法 没有方法体的纯虚方法 继承后必须去实现的方法
    // 注意:
    // 如何选择普通类还是抽象类
    // 不希望被实例化的对象，相对比较抽象的类可以使用抽象类
    // 父类中的行为不太需要被实现的，只希望子类去定义具体的规则的 可以选择 抽象类然后使用其中的抽象方法来定义规则
    // 作用:
    // 整体框架设计时  会使用
    #endregion

    #region 核心区别：虚方法 vs 抽象方法
    /*
     1. 虚方法（virtual）
       - 有方法体，可直接调用
       - 子类可选重写（override）
       - 适合：基类提供基础逻辑，子类按需扩展
    
     2. 抽象方法（abstract）
       - 无方法体，必须在抽象类中定义
       - 子类必须强制重写
       - 适合：定义统一规范，强制子类实现具体逻辑
    */
    #endregion
}
