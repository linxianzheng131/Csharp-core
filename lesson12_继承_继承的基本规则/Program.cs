using System;

namespace Lesson12_继承_继承的基本规则
{
    #region 知识点一 基本概念
    //一个类A继承一个类B
    //类A将会继承类B的所有成员
    //类A将拥有B类的所有特征和行为

    //被继承的类
    //称为 父类、基类、超类

    //继承的类
    //称为子类、派生类

    //子类可以有自己的特征和行为

    //特点
    //1.单根性 子类只能有一个父类
    //2.传递性 子类可以间接继承父类的父类
    #endregion

    #region 知识点二 基本语法
    //class 类名 : 被继承的类名
    //{

    //}
    #endregion

    #region 知识点三 实例
    // 父类：教师
    class Teacher
    {
        //姓名
        public string name;
        //职工号
        protected int number;

        //介绍名字
        public void SpeakName()
        {
            // 这里故意写死10，是为了演示protected成员在子类中可访问
            number = 10;
            Console.WriteLine(name);
        }
    }

    // 子类：授课教师，继承自Teacher
    class TeachingTeacher : Teacher
    {
        // 这里用new关键字，是为了显式隐藏从父类继承的name成员
        // 极不建议这样使用，容易造成混淆
        public new string name;
        //科目
        public string subject;

        //介绍科目
        public void SpeakSubject()
        {
            Console.WriteLine(subject + "老师");
        }
    }

    // 子类：语文教师，继承自TeachingTeacher
    class ChineseTeacher : TeachingTeacher
    {
        // 语文老师的专属技能
        public void Skill()
        {
            Console.WriteLine("一行白鹭上青天");
        }
    }
    #endregion

    #region 知识点四 访问修饰符的影响
    //public - 公共 内外部访问
    //private - 私有 内部访问
    //protected - 保护 内部和子类访问

    //之后讲命名空间的时候讲
    //internal - 内部的 只有在同一个程序集的文件中，内部类型或者是成员才可以访问
    #endregion

    #region 知识点五 子类和父类的同名成员
    //概念
    //C#中允许子类存在和父类同名的成员
    //但是 极不建议使用
    //一般不用因为继承就是为了复用父类的代码
    //重写就不需要这个了
    //不过需要时也可以用

    //成员方法就一般常用  可以实现方法重写
    //体现多态性
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("继承的基本规则");

            // 创建TeachingTeacher对象
            TeachingTeacher tt = new TeachingTeacher();
            tt.name = "唐老狮";
            // 父类的protected成员number，在子类TeachingTeacher内部可以访问，但在Main方法中不能直接访问
            // tt.number = 1; // 这里会报错，因为number是protected，只能在Teacher或其子类内部访问
            tt.SpeakName(); // 调用父类方法，输出tt.name的值

            tt.subject = "Unity";
            tt.SpeakSubject(); // 调用自身方法，输出"Unity老师"

            // 创建ChineseTeacher对象
            ChineseTeacher ct = new ChineseTeacher();
            ct.name = "唐老师";
            // ct.number = 2; // 同样，这里也不能直接访问
            ct.subject = "语文";
            ct.SpeakName();    // 调用父类Teacher的方法，输出ct.name
            ct.SpeakSubject(); // 调用父类TeachingTeacher的方法，输出"语文老师"
            ct.Skill();        // 调用自身方法，输出"一行白鹭上青天"
        }
        //总结
        //继承基本语法
        // class 类名:父类名
        // 1.单根性：只能继承一个父类
        // 2.传递性：子类可以继承父类的父类。。。的所有内容
        // 3.访问修饰符 对于成员的影响

        // 4.极其不建议使用 在子类中申明和父类同名的成员 (以后学习了多态再来解决这个问题)
    }
}