namespace Lesson20_多态_密封方法
{
    #region 知识点一 密封方法基本概念
    // 用密封关键字 sealed 修饰的重写函数
    // 作用：让虚方法或者抽象方法之后不能再被重写
    // 特点：必须和 override 一起出现
    #endregion

    #region 知识点二 实例
    /// <summary>
    /// 抽象基类：动物
    /// </summary>
    abstract class Animal
    {
        // 公共字段：名字
        public string name;

        /// <summary>
        /// 抽象方法：吃（必须由子类实现）
        /// </summary>
        public abstract void Eat();

        /// <summary>
        /// 虚方法：叫（可由子类重写）
        /// </summary>
        public virtual void Speak()
        {
            Console.WriteLine("叫");
        }
    }

    /// <summary>
    /// 派生类：人类，继承自动物类
    /// </summary>
    class Person : Animal
    {
        /// <summary>
        /// 重写抽象方法 Eat
        /// </summary>
        public override void Eat()
        {
            // 可在此处实现人类吃饭的具体逻辑
            Console.WriteLine("人在吃饭");
        }

        /// <summary>
        /// 重写虚方法 Speak
        /// </summary>
        public override void Speak()
        {
            // 可在此处实现人类说话的具体逻辑
            Console.WriteLine("人在说话");
        }
    }

    /// <summary>
    /// 派生类：白人，继承自人类
    /// </summary>
    class WhitePerson : Person
    {
        /// <summary>
        /// 密封重写方法 Eat：阻止更下层子类继续重写此方法
        /// </summary>
        public sealed override void Eat()
        {
            // 调用父类 Person 的 Eat 方法
            base.Eat();
            // 可在此处补充白人吃饭的特殊逻辑
            Console.WriteLine("白人用刀叉吃饭");
        }

        /// <summary>
        /// 密封重写方法 Speak：阻止更下层子类继续重写此方法
        /// </summary>
        public sealed override void Speak()
        {
            // 调用父类 Person 的 Speak 方法
            base.Speak();
            // 可在此处补充白人说话的特殊逻辑
            Console.WriteLine("白人说英语");
        }
    }

    // 尝试定义更下层子类（会报错，因为 Eat 和 Speak 已被密封）
    // class BlackPerson : WhitePerson
    // {
    //     // 错误：无法重写继承的成员 'WhitePerson.Eat()'，因为它是密封的
    //     // public override void Eat() { }
    //
    //     // 错误：无法重写继承的成员 'WhitePerson.Speak()'，因为它是密封的
    //     // public override void Speak() { }
    // }

    /// <summary>
    /// 程序入口类
    /// </summary>
    class Program
    {
        /// <summary>
        /// 程序入口方法
        /// </summary>
        /// <param name="args">命令行参数</param>
        static void Main(string[] args)
        {
            Console.WriteLine("密封方法");

            // 测试密封方法
            WhitePerson wp = new WhitePerson();
            wp.Eat();
            wp.Speak();
        }
    }
    #endregion

    // 总结
    // 密封方法 可以让虚方法和抽象方法不能再被子类重写
    // 特点：一定是和 override 一起出现
    // 补充：
    // 1. sealed 关键字只能修饰已经被重写过的方法（即必须搭配 override 使用）
    // 2. 密封类会自动密封所有继承的虚方法，无需单独标记 sealed
    // 3. 密封方法的核心目的是**终止方法重写链**，保证特定版本的方法逻辑不再被修改
}