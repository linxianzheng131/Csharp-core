using System;

// ========================== 【继承核心特性演示】 ==========================
namespace InheritanceDemo
{
    //1. 父类：作为公共模板，提供【复用性】
    public class Animal
    {
        // 公有字段：提供给子类复用
        public string Name { get; set; }

        // 构造函数：初始化复用代码
        public Animal(string name)
        {
            this.Name = name;
            Console.WriteLine($"[{Name}] 出生了！这是Animal类的构造逻辑被复用。");
        }

        // 虚方法：为【多态】做铺垫，允许子类重写
        public virtual void MakeSound()
        {
            Console.WriteLine($"{Name} 发出了通用的动物叫声。");
        }

        // 普通方法：展示【代码复用】
        public void Eat()
        {
            Console.WriteLine($"{Name} 正在吃饭。（这是Animal类提供的通用吃饭功能）");
        }
    }

    // ==============================================

    // 2. 子类：继承自Animal
    // 关系：is-a（狗是一个动物）
    public class Dog : Animal
    {
        // 子类构造函数：通过 base 关键字调用父类构造
        // 体现：【子类复用父类初始化逻辑】
        public Dog(string name) : base(name)
        {
            Console.WriteLine($"[{Name}] 这是Dog类的专属构造逻辑。");
        }

        // 3. 【重写 Override】：实现【多态性】
        // 父类定义了标准，子类提供具体实现
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} 汪汪汪！（这是Dog重写的专属叫声，体现多态）");
        }

        // 子类专属方法：展示【可扩展性】
        public void WagTail()
        {
            Console.WriteLine($"{Name} 正在摇尾巴。（这是Dog类扩展的新功能）");
        }
    }

    // 再来一个子类：多态的完美体现
    public class Cat : Animal
    {
        public Cat(string name) : base(name) { }

        // 同样重写了MakeSound，但实现不同
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} 喵喵喵！（不同子类的多态表现）");
        }
    }

    // ==============================================

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== 特性一：复用性 (Reusability) ===");
            // Dog 和 Cat 都直接复用了 Animal 的 Name 属性和 Eat 方法
            // 不需要重新写一遍 Name 和 Eat
            Dog myDog = new Dog("大黄");
            myDog.Eat(); // 直接调用父类方法，无需重复编写

            Cat myCat = new Cat("小白");
            myCat.Eat(); // 同样复用父类方法

            Console.WriteLine("\n=== 特性二：独立性 (Independence) ===");
            // 子类对象可以完全独立使用，不仅有父类能力，还有自己的能力
            myDog.WagTail(); // 只有Dog有，Animal没有，体现了子类的独立扩展

            Console.WriteLine("\n=== 特性三：多态性 (Polymorphism) ===");
            // 核心语法：父类引用指向子类对象
            // 同一调用 MakeSound()，在不同对象上表现出不同行为
            Animal animal1 = new Dog("旺财");
            Animal animal2 = new Cat("富贵");

            // 运行时会自动识别实际对象类型，调用对应的重写方法
            animal1.MakeSound(); // 输出汪汪汪
            animal2.MakeSound(); // 输出喵喵喵

            Console.WriteLine("\n=== 特性四：可扩展性 (Extensibility) ===");
            // 可以随时创建新子类（如 Bird），无需修改 Animal 原有代码
            // 符合开闭原则：对扩展开放，对修改关闭
            Bird myBird = new Bird("鹦鹉");
            myBird.MakeSound(); // 扩展新功能，不影响旧代码
        }
    }

    // 新子类：完美的扩展性演示
    public class Bird : Animal
    {
        public Bird(string name) : base(name) { }

        public override void MakeSound()
        {
            Console.WriteLine($"{Name} 叽叽叽！（新扩展的鸟类叫声）");
        }
    }
    //多态
    /*
     Dog myDog = new Dog("大黄"); 
     我就是一只狗，狗的所有功能我都能用。

     Animal animal1 = new Dog("旺财"); 
     我被当成动物看待，但真身还是狗。
     只能用动物有的功能，不能直接用狗独有的功能。
     */
}

