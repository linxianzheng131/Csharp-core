using System;

namespace Lesson26_面向对象相关_抽象类和接口的区别
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("抽象类和接口的区别");
            Console.WriteLine();

            #region 知识回顾
            // 抽象类和抽象方法
            // abstract修饰的类和方法
            // 抽象类 不能实例化
            // 抽象方法只能在抽象类中申明 是个纯虚方法 必须在子类中实现

            // 接口
            // interface 自定义类型
            // 是行为的抽象
            // 不包含成员变量
            // 仅包含方法、属性、索引器、事件，成员都不能实现，建议不写访问修饰符，默认public
            #endregion

            #region 知识点一 相同点
            // 1. 都可以被继承
            // 2. 都不能直接实例化
            // 3. 都可以包含方法申明
            // 4. 子类必须实现未实现的方法
            // 5. 都遵循里氏替换原则（父类/接口引用可以指向子类/实现类对象）
            #endregion
           
            #region 知识点二 区别
            // 1. 抽象类中可以有构造函数；接口中不能
            // 2. 抽象类只能被单一继承；接口可以被继承多个（多实现）
            // 3. 抽象类中可以有成员变量；接口中不能
            // 4. 抽象类中可以申明成员方法，虚方法，抽象方法，静态方法；接口中只能申明没有实现的抽象方法（C# 8.0+支持默认实现，此处为传统语法）
            // 5. 抽象类方法可以使用访问修饰符；接口中建议不写，默认public（不可修改访问权限）
            // 补充：6. 抽象类可以有静态成员、字段、常量；接口不能有实例字段、静态字段（C# 8.0+支持静态成员）
            // 补充：7. 抽象类是对对象的抽象；接口是对行为的抽象
            #endregion

            #region 如何选择抽象类和接口
            // 表示对象的用抽象类，表示行为拓展的用接口
            // 不同对象拥有的共同行为，我们往往可以使用接口来实现
            // 举个例子：
            // 动物是一类对象，我们自然会选择抽象类；而飞翔是一个行为，我们自然会选择接口。
            // 补充：8. 遵循"is-a"关系用抽象类，遵循"can-do"关系用接口
            #endregion

            #region 补充：可运行示例代码
            Console.WriteLine("=== 抽象类 vs 接口 示例演示 ===");

            // 1. 抽象类示例：动物（is-a 关系）
            Animal dog = new Dog("旺财");
            dog.Eat();
            dog.Sleep();

            // 2. 接口示例：飞翔（can-do 行为）
            IFly bird = new Bird("鹦鹉");
            bird.Fly();

            // 3. 类同时继承抽象类+实现多个接口
            Bat bat = new Bat("蝙蝠");
            bat.Eat(); // 继承自动物抽象类
            bat.Fly(); // 实现IFly接口
            bat.Hunt(); // 实现IHunt接口

            // 里氏替换原则演示
            Animal animal = bat; // 抽象类引用指向子类
            IFly fly = bat; // 接口引用指向实现类
            #endregion

            Console.ReadKey();
        }
    }

    #region 抽象类示例：动物（is-a 关系）
    /// <summary>
    /// 抽象类：动物，对对象的抽象
    /// </summary>
    public abstract class Animal
    {
        // 抽象类可以有成员变量
        public string Name;

        // 抽象类可以有构造函数
        public Animal(string name)
        {
            Name = name;
        }

        // 抽象方法：必须在子类实现
        public abstract void Eat();

        // 普通成员方法：可以有实现
        public void Sleep()
        {
            Console.WriteLine($"{Name}在睡觉");
        }

        // 虚方法：子类可以重写，也可以不重写
        public virtual void Move()
        {
            Console.WriteLine($"{Name}在移动");
        }
    }

    /// <summary>
    /// 子类：狗，继承动物抽象类
    /// </summary>
    public class Dog : Animal
    {
        public Dog(string name) : base(name) { }

        // 必须实现抽象方法
        public override void Eat()
        {
            Console.WriteLine($"{Name}在吃骨头");
        }

        // 重写虚方法
        public override void Move()
        {
            Console.WriteLine($"{Name}在跑");
        }
    }
    #endregion

    #region 接口示例：行为抽象（can-do 关系）
    /// <summary>
    /// 接口：飞翔，对行为的抽象
    /// </summary>
    public interface IFly
    {
        // 接口成员默认public，不能写访问修饰符
        void Fly();
    }

    /// <summary>
    /// 接口：捕猎，额外行为
    /// </summary>
    public interface IHunt
    {
        void Hunt();
    }

    /// <summary>
    /// 类：鸟，实现IFly接口
    /// </summary>
    public class Bird : IFly
    {
        public string Name;

        public Bird(string name)
        {
            Name = name;
        }

        public void Fly()
        {
            Console.WriteLine($"{Name}在天空飞翔");
        }
    }

    /// <summary>
    /// 类：蝙蝠，同时继承抽象类+实现多个接口
    /// </summary>
    public class Bat : Animal, IFly, IHunt
    {
        public Bat(string name) : base(name) { }

        // 实现抽象类的抽象方法
        public override void Eat()
        {
            Console.WriteLine($"{Name}在吃昆虫");
        }

        // 实现IFly接口
        public void Fly()
        {
            Console.WriteLine($"{Name}在夜间飞行");
        }

        // 实现IHunt接口
        public void Hunt()
        {
            Console.WriteLine($"{Name}在捕猎");
        }
    }
    #endregion
}