using MyGame1;
using System;

namespace MyGame2
{
    
    // 在不同的命名空间中 是可以有同名类的
    class GameContent()
    {
        public void print()
        {
            GameObject1 gameObject1 = new GameObject1();
            gameObject1.Speak();
        }
        
    }
    class GameObject
    {
        // 类的成员
        MyGame1.IN.GameObj go1 = new MyGame1.IN.GameObj();
        //无法使用MyGame 除非使用全名
        /*
        using 父命名空间;  只能让你直接访问父命名空间下的类
        不能自动识别子命名空间  IN 

        编译器看到  IN.GameObject  时，会去全局命名空间找  IN 
        而不是去  IN  里找，所以不能用

        或者使用using MyGame1.IN；
         */
    }

}
namespace MyGame1
{
    namespace IN
    {
        public class GameObj
        {
            // 类的成员
            
        }
    }
    public class GameObject1
    {
        // 类的成员skill
        public void Speak()
        {
            Console.WriteLine("***********************************");
        }
    }
}
namespace MyGame
{
    //111可以声明与Lesson21_面向对象相关_命名空间 内部命名空间一样 但是
    public class GameObject3
    {

    }
}
namespace Lesson21_面向对象相关_命名空间
{    
    using MyGame;
    //222这里无法使用Myname 
    //因为MyGame和内部命名空间重名 会认为这句话没用 因为内部本来就这个命名空间
    //使用点也点不出来
    //除非using globle::MyGame;表明是外面的
    using MyGame1;
    using MyGame2;
    //using可以在命名空间使用
    //表明这个 MyGame2 命名空间只能在这个 Lesson21_面向对象相关_命名空间 命名空间使用
    public class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("命名空间");

            // 测试不同命名空间的同名类
            MyGame1.GameObject1 go1 = new MyGame1.GameObject1();
            GameObject go2 = new GameObject();
            //GameObject3 gameObject3 = new GameObject3();
            //333所以这一句代码报错 找不到GameObject3

            // 测试嵌套命名空间
            MyGame.UI.Image uiImg = new MyGame.UI.Image();
            MyGame.Game.Image gameImg = new MyGame.Game.Image();
            
        }
    }

    #region 知识点一 命名空间基本概念
    // 概念
    // 命名空间是用来组织和重用代码的
    // 作用
    // 就像是一个工具包，类就像是一件一件的工具，都是声明在命名空间中的
    #endregion

    #region 知识点二 命名空间的使用
    // 基本语法
    // namespace 命名空间名
    // {
    //   类
    //   类
    // }

    namespace MyGame
    {
        class Player1 : GameObject
        {
            // 类的成员
        }
    }

    // 同一个命名空间可以拆分到多个文件中，编译器会自动合并
    namespace MyGame
    {
        class Player2 : GameObject
        {
            // 类的成员
        }
    }
    #endregion

    #region 知识点三 不同命名空间中相互使用 需要引用命名空间或指明出处
    // 方式1：使用 using 关键字引用命名空间
    // using MyGame;
    // 方式2：使用 命名空间.类名 的完整路径指明出处
    // MyGame.GameObject obj = new MyGame.GameObject();
    #endregion

    #region 知识点四 不同命名空间中允许有同名类
    
    #endregion

    #region 知识点五 命名空间可以包裹命名空间
    namespace MyGame
    {
        namespace UI
        {
            class Image
            {
                // UI 模块中的图片类
            }
        }

        namespace Game
        {
            class Image
            {
                // 游戏核心模块中的图片类
            }
        }
    }
    #endregion

    #region 知识点六 关于修饰类的访问修饰符
    // public —— 公开的类，所有程序集都可以访问
    // internal —— 只能在该程序集中使用（注意：命名空间中的类默认为 internal，不是 public！）
    // abstract —— 抽象类，不能被实例化，只能被继承
    // sealed —— 密封类，不能被继承
    // partial —— 分部类，可以将一个类拆分成多个部分写在不同文件中
    #endregion

    
}

/// 总结
/// 1. 命名空间是个工具包，用来管理类的
/// 2. 不同命名空间中，可以有同名类
/// 3. 不同命名空间中相互使用，需要 using 引用命名空间，或者 指明出处（完整类名）
/// 4. 命名空间可以包裹命名空间（嵌套命名空间）
/// 补充：
/// - 同一个命名空间可以拆分到多个文件中，编译器会自动合并
/// - 命名空间中的类默认访问修饰符是 internal，不是 public
/// - 嵌套命名空间的访问需要使用完整路径（如 MyGame.UI.Image）
/// - using static 可以直接引用静态类的静态成员，无需写类名
