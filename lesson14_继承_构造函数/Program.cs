namespace lesson14_继承_构造函数
{
    #region 知识回顾：构造函数基础
    // 构造函数
    // 实例化对象时调用的函数
    // 主要用来初始化成员变量
    // 每个类 都会有一个默认的无参构造函数

    // 语法
    // 访问修饰符 类名()
    // {
    // }
    // 不写返回值
    // 函数名和类名相同
    // 访问修饰符根据需求而定,一般为public
    // 构造函数可以重载
    // 可以用this语法重用代码

    // 注意
    // 有参构造会顶掉默认的无参构造
    // 如想保留无参构造需重载出来
    class Test
    {
        public int testI;
        public string testStr;

        // 无参构造函数
        public Test()
        {

        }

        // 单参数有参构造函数
        public Test(int i)
        {
            this.testI = i;
        }

        // 双参数有参构造函数，通过this(i)重用单参数构造的逻辑
        public Test(int i, string str) : this(i)
        {
            this.testStr = str;
        }
    }
    #endregion

    #region 知识点一 继承中的构造函数 基本概念
    // 特点
    // 当声明一个子类对象时
    // 先执行父类的构造函数
    // 再执行子类的构造函数

    // 注意:
    // 1. 父类的无参构造 很重要
    // 2. 子类可以通过base关键字 代表父类 调用父类构造
    #endregion

    #region 知识点二 继承中构造函数的执行顺序
    // 父类的父类的构造 -> ... -> 父类构造 -> ... -> 子类构造
    // 多层继承时，构造函数从最顶层的祖先类开始，依次向下执行
    class GameObject
    {
        public GameObject()
        {
            Console.WriteLine("GameObject的构造函数");
        }
    }

    class Player : GameObject
    {
        public Player()
        {
            Console.WriteLine("Player的构造函数");
        }
    }

    class MainPlayer : Player
    {
        public MainPlayer()
        {
            Console.WriteLine("MainPlayer的构造函数");
        }
    }
    #endregion

    #region 知识点三 父类的无参构造函数重要
    // 子类实例化时 默认自动调用的 是父类的无参构造 所以如果父类无参构造被顶掉 会报错

    // 情况1：父类保留无参构造，子类可正常编译
    class Father
    {
        // 保留无参构造，子类默认调用不会报错
        public Father()
        {

        }

        public Father(int i)
        {
            Console.WriteLine("Father构造");
        }
    }

    // 情况2：父类仅写有参构造，顶掉默认无参构造，子类会直接编译报错（红线标注）
    // class Father
    // {
    //     public Father(int i)
    //     {
    //         Console.WriteLine("Father构造");
    //     }
    // }

    // 父类无参被顶掉后，空子类会直接报错，因为默认尝试调用父类无参构造
    // class Son : Father
    // {
    // }
    #endregion

    #region 知识点四 通过base调用指定父类构造
    class Son : Father
    {
        // 通过base(i) 显式调用父类的单参数构造函数
        // 解决父类无参构造被顶掉后，子类无法默认调用的问题
        public Son(int i) : base(i)
        {
            Console.WriteLine("Son的一个参数的构造");
        }

        // 通过this(i) 调用本类的单参数构造函数，实现代码复用
        // 执行顺序：base(i) -> 本类单参构造 -> 本类双参构造
        public Son(int i, string str) : this(i)
        {
            Console.WriteLine("Son的两个参数的构造");
        }
    }
    #endregion

    #region 总结
    // 总结
    // 继承中的构造函数
    // 特点
    // 执行顺序 是先执行父类的构造函数 再执行子类的 从老祖宗开始 依次一代一代向下执行

    // 父类中的无参构造函数 很重要
    // 如果被顶掉 子类中就无法默认调用无参构造了
    // 解决方法:
    // 1. 始终保持申明一个无参构造
    // 2. 通过base关键字 调用指定父类的构造

    // 注意:
    // 区分this和base的区别
    // this：代表当前类对象，用于调用本类的构造函数、成员变量/方法
    // base：代表父类对象，用于调用父类的构造函数、成员变量/方法
    #endregion
}