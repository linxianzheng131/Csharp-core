using System;

namespace Lesson17_多态_vob
{
    #region 知识回顾
    // 封装—用编程语言来形容对象
    // 特征—成员变量
    // 行为—成员方法
    // 初始化调用—构造函数
    // 释放时调用—析构函数
    // 保护成员变量—成员属性
    // 像数组一样使用—索引器
    // 类名点出使用—静态成员
    // 自定义对象可计算—运算符重载
    // 静态类和静态构造函数
    // 拓展方法

    // 继承—复用封装对象的代码；儿子继承父亲，复用现成代码
    // 继承中的构造函数
    // 里氏替换原则
    // 万物之父
    // 装箱拆箱
    // 密封类
    #endregion

    #region 知识点一 多态的概念
    // 多态按字面的意思就是“多种状态”
    // 让继承同一父类的子类们 在执行相同方法时有不同的表现（状态）
    // 主要目的
    // 同一父类的对象 执行相同行为（方法）有不同的表现
    // 解决的问题
    // 让同一个对象有唯一行为的特征
    #endregion

    #region 知识点二 解决的问题（非多态的“隐藏方法”示例）
    class Father
    {
        public void SpeakName()
        {
            Console.WriteLine("Father的方法");
        }
    }

    class Son : Father
    {
        // new 关键字：隐藏父类方法（不是标准多态，是编译时静态绑定）
        public new void SpeakName()
        {
            Console.WriteLine("Son的方法");
        }
    }
    #endregion

    #region 知识点三 多态的实现
    // 我们目前已经学过的多态
    // 编译时多态—函数重载，开始就写好的

    // 我们将学习的：
    // 运行时多态( vob、抽象函数、接口 )
    // 我们今天学习 vob
    // v：virtual（虚函数）
    // o：override（重写）
    // b：base（父类）

    /// <summary>
    /// 游戏对象基类（演示多态的核心类）
    /// </summary>
    class GameObject
    {
        public string name;

        /// <summary>
        /// 构造函数：初始化对象名称
        /// </summary>
        /// <param name="name">对象名称</param>
        public GameObject(string name)
        {
            this.name = name;
        }

        // 虚函数 可以被子类重写
        public virtual void Atk()
        {
            Console.WriteLine("游戏对象进行攻击");
        }
    }

    /// <summary>
    /// 玩家类：继承自GameObject
    /// </summary>
    class Player : GameObject
    {
        /// <summary>
        /// 构造函数：调用父类构造函数初始化名称
        /// </summary>
        /// <param name="name">玩家名称</param>
        public Player(string name) : base(name)
        {
        }

        // 重写虚函数
        public override void Atk()
        {
            // base的作用
            // 代表父类 可以通过base来保留父类的行为
            base.Atk();
            Console.WriteLine("玩家对象进行攻击");
        }
    }

    /// <summary>
    /// 怪物类：继承自GameObject
    /// </summary>
    class Monster : GameObject
    {
        /// <summary>
        /// 构造函数：调用父类构造函数初始化名称
        /// </summary>
        /// <param name="name">怪物名称</param>
        public Monster(string name) : base(name)
        {
        }

        // 重写虚函数
        public override void Atk()
        {
            base.Atk(); // 保留父类逻辑
            Console.WriteLine("怪物对象进行攻击");
        }
    }
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("多态vob");

            #region 解决的问题（对比：非多态的隐藏方法）
            // 父类引用指向子类对象，但调用的是父类方法（因为没有virtual/override）
            Father f = new Son();
            f.SpeakName(); // 输出：Father的方法（静态绑定，未实现多态）

            // 强制转换为子类类型，才能调用子类重写（隐藏）的方法
            (f as Son).SpeakName(); // 输出：Son的方法
            #endregion

            #region 多态的使用（运行时多态：virtual + override 实现）
            // 父类引用指向子类对象，调用重写的虚函数
            GameObject p = new Player("唐老狮");
            p.Atk();
            // 输出：
            // 游戏对象进行攻击
            // 玩家对象进行攻击

            // 强制转换为子类类型，调用子类重写方法（结果一致）
            (p as Player).Atk();
            // 输出：
            // 游戏对象进行攻击
            // 玩家对象进行攻击

            // 怪物类的多态调用
            GameObject m = new Monster("小怪物");
            m.Atk();
            // 输出：
            // 游戏对象进行攻击
            // 怪物对象进行攻击

            // 强制转换为子类类型，调用子类重写方法
            (m as Monster).Atk();
            // 输出：
            // 游戏对象进行攻击
            // 怪物对象进行攻击
            #endregion
        }
    }

    #region 总结
    // 多态：让同一类型的对象，执行相同行为时有不同的表现
    // 解决的问题：让同一对象有唯一的行为特征
    // vob：
    // v：virtual 虚函数
    // o：override 重写
    // b：base 父类
    // v和o一定是结合使用的 来实现多态
    // b是否使用根据实际需求 保留父类行为
    #endregion
}