using System;

// =============================================
// 主题：继承 与 内部类 核心区别（C# 演示）
// 结论：二者不是替代关系，各有各的专属能力
//=============================================

#region 一、先搞两个类：父类 + 外部类（用来对比）
/// <summary>
/// 父类：用于演示【继承】
/// </summary>
public class Parent
{
    // 私有字段：子类【不能访问】
    private string privateField = "父类私有字段";

    // 受保护字段：子类【能访问】
    protected string protectedField = "父类受保护字段";

    public void ParentMethod()
    {
        Console.WriteLine("父类方法");
    }
}

/// <summary>
/// 外部类：用于演示【内部类】
/// </summary>
public class Outer
{
    // 私有字段：内部类【可以直接访问】
    private string privateField = "外部类私有字段";

    public void OuterMethod()
    {
        Console.WriteLine("外部类方法");
    }

    #region 内部类（专属给外部类服务）
    /// <summary>
    /// 内部类：天生依附外部类
    /// 权限：可以直接访问外部类所有 private 成员
    /// </summary>
    public class Inner
    {
        public void TestInnerAccess(Outer outer)
        {
            // ✅ 内部类可以直接访问外部类 private！
            Console.WriteLine(outer.privateField);

            // ✅ 外部类方法随便调
            outer.OuterMethod();
        }
    }
    #endregion
}
#endregion

#region 二、子类：演示【继承】能做什么、不能做什么
/// <summary>
/// 子类：继承 Parent
/// 关系：is-a（是一个）
/// 作用：复用、扩展、多态
/// </summary>
public class Child : Parent
{
    public void TestInheritAccess()
    {
        // ✅ 可以访问 protected
        Console.WriteLine(protectedField);

        // ❌ 报错！子类 不能访问 父类 private！
        // Console.WriteLine(privateField);

        // ✅ 可以调用父类方法
        ParentMethod();
    }
}
#endregion

#region 三、主程序：运行看效果
class Program
{
    static void Main()
    {
        Console.WriteLine("===== 1. 继承演示 =====");
        Child child = new Child();
        child.TestInheritAccess();

        Console.WriteLine("\n===== 2. 内部类演示 =====");
        Outer outer = new Outer();
        Outer.Inner inner = new Outer.Inner();
        inner.TestInnerAccess(outer);

        Console.WriteLine("\n===== 核心结论（注释已写在代码里）=====");
    }
}
#endregion

/*
=============================================
【终极总结（注释版）】

一、继承能做，内部类做不到：
1. 多态          Parent p = new Child();
2. 方法重写      override（也体现了多态性）
3. 独立存在      可以直接 new Child()
4. 跨类代码复用

二、内部类能做，继承做不到：
1. 直接访问外部类 private 成员
2. 强封装、隐藏实现（可以设 private 内部类）
3. 不破坏“is-a”关系，只是给外部类做辅助

三、一句话定位
继承：我是你的扩展，我独立
内部类：我是你的一部分，我专属
=============================================
*/