using System;
using System.Collections.Generic;

// ==============================================
// 【核心总览：七大设计原则是什么？】
// 目的：写出的代码易维护、易扩展、低耦合、高内聚
// 口诀：单一、开闭、里氏、接口、依赖、组合、迪米特
// 对应图中知识点：七大原则（面向对象设计核心）
// ==============================================

#region 原则1：单一职责原则 (Single Responsibility Principle, SRP)
// 核心定义：一个类/方法只负责一个功能模块，只有一个改变它的理由
// 场景：避免"上帝类"，比如一个类既管登录又管订单查询，违反SRP
// ==============================================
/// <summary>
/// 【违反SRP示例】一个类做太多事
/// 同时负责用户信息管理 + 订单查询功能
/// </summary>
public class UserServiceBad
{
    public void GetUserInfo(int userId)
    {
        Console.WriteLine("获取用户信息：" + userId);
    }

    // 不该有的职责：订单查询
    public void GetOrderList(int userId)
    {
        Console.WriteLine("获取用户订单列表：" + userId);
    }
}

/// <summary>
/// 【遵守SRP示例】拆分职责
/// 1. 用户管理类：只负责用户相关
/// </summary>
public class UserService
{
    public void GetUserInfo(int userId)
    {
        Console.WriteLine("✅ 遵守SRP：获取用户信息：" + userId);
    }
}

/// <summary>
/// 2. 订单管理类：只负责订单相关
/// </summary>
public class OrderService
{
    public void GetOrderList(int userId)
    {
        Console.WriteLine("✅ 遵守SRP：获取用户订单列表：" + userId);
    }
}
#endregion

#region 原则2：开闭原则 (Open Closed Principle, OCP)
// 核心定义：对扩展开放，对修改关闭
// 场景：新增功能时，扩展新类/新方法，不修改原有源代码
// ==============================================
/// <summary>
/// 【违反OCP示例】使用if-else判断类型，新增类型必须修改方法
/// </summary>
public class PaymentServiceBad
{
    public void Pay(string type)
    {
        if (type == "Alipay")
            Console.WriteLine("使用支付宝支付");
        else if (type == "WeChat")
            Console.WriteLine("使用微信支付");
        // 新增支付方式：必须修改此方法 → 违反OCP
    }
}

/// <summary>
/// 【遵守OCP示例】抽象层 + 多态
/// 新增支付方式只需新建类，不修改原有代码
/// </summary>
public abstract class Payment
{
    public abstract void Pay();
}

public class AlipayPayment : Payment
{
    public override void Pay()
    {
        Console.WriteLine("✅ 遵守OCP：使用支付宝支付");
    }
}

public class WeChatPayment : Payment
{
    public override void Pay()
    {
        Console.WriteLine("✅ 遵守OCP：使用微信支付");
    }
}

// 新增支付方式：只需新建类，无需修改Payment和调用处
public class ApplePayPayment : Payment
{
    public override void Pay()
    {
        Console.WriteLine("✅ 遵守OCP：使用Apple Pay支付");
    }
}
#endregion

#region 原则3：里氏替换原则 (Liskov Substitution Principle, LSP)
// 核心定义：子类可以完全替换父类，程序行为不变
// 含义：继承必须合理，子类不能破坏父类的契约
// ==============================================
/// <summary>
/// 【违反LSP示例】正方形继承长方形，替换后行为异常
/// </summary>
public class Rectangle
{
    public virtual int Width { get; set; }
    public virtual int Height { get; set; }

    public int GetArea()
    {
        return Width * Height;
    }
}

public class Square : Rectangle
{
    // 重写后破坏了父类契约：设置宽同时设置高
    public override int Width
    {
        set { base.Width = value; base.Height = value; }
    }
    public override int Height
    {
        set { base.Height = value; base.Width = value; }
    }
}

/// <summary>
/// 【遵守LSP示例】抽象形状，让矩形和正方形各自实现
/// </summary>
public abstract class Shape
{
    public abstract int GetArea();
}

public class RectangleEx : Shape
{
    public int Width { get; set; }
    public int Height { get; set; }

    public override int GetArea()
    {
        return Width * Height;
    }
}

public class SquareEx : Shape
{
    public int Side { get; set; }

    public override int GetArea()
    {
        return Side * Side;
    }
}
#endregion

#region 原则4：接口隔离原则 (Interface Segregation Principle, ISP)
// 核心定义：客户端不应该依赖不需要的接口；接口要细化，不要大而全
// ==============================================
/// <summary>
/// 【违反ISP示例】一个大接口包含所有方法，实现类被迫实现不需要的方法
/// </summary>
public interface IWorkerBad
{
    void Work();
    void Eat();
    void Sleep();
    // 新增功能：所有实现类都要改，且不需要的方法也要实现
}

public class HumanWorker : IWorkerBad
{
    public void Work() { Console.WriteLine("人类工作"); }
    public void Eat() { Console.WriteLine("人类吃饭"); }
    public void Sleep() { Console.WriteLine("人类睡觉"); }
}

// 机器人不需要吃饭睡觉，但必须实现 → 违反ISP
public class RobotWorker : IWorkerBad
{
    public void Work() { Console.WriteLine("机器人工作"); }
    public void Eat() { throw new Exception("机器人不需要吃饭"); } // 被迫实现
    public void Sleep() { throw new Exception("机器人不需要睡觉"); } // 被迫实现
}

/// <summary>
/// 【遵守ISP示例】拆分多个小接口
/// </summary>
public interface IWorkable
{
    void Work();
}

public interface IEatable
{
    void Eat();
}

public interface ISleepable
{
    void Sleep();
}

public class Human : IWorkable, IEatable, ISleepable
{
    public void Work() { Console.WriteLine("✅ 遵守ISP：人类工作"); }
    public void Eat() { Console.WriteLine("✅ 遵守ISP：人类吃饭"); }
    public void Sleep() { Console.WriteLine("✅ 遵守ISP：人类睡觉"); }
}

public class Robot : IWorkable
{
    public void Work() { Console.WriteLine("✅ 遵守ISP：机器人工作，无需实现不需要的接口"); }
}
#endregion

#region 原则5：依赖倒置原则 (Dependency Inversion Principle, DIP)
// 核心定义：高层模块依赖抽象，不依赖具体实现；细节依赖抽象
// 含义：面向接口编程，降低耦合
// ==============================================
/// <summary>
/// 【违反DIP示例】高层直接依赖具体实现
/// </summary>
public class BadNotification
{
    // 依赖具体的微信实现，无法切换到其他推送
    public void SendWeChatMsg(string msg)
    {
        Console.WriteLine("发送微信消息：" + msg);
    }
}

/// <summary>
/// 【遵守DIP示例】抽象层 + 构造函数注入依赖
/// </summary>
// 抽象接口
public interface IMessageSender
{
    void Send(string msg);
}

// 具体实现1
public class WeChatSender : IMessageSender
{
    public void Send(string msg)
    {
        Console.WriteLine("✅ 遵守DIP：发送微信消息：" + msg);
    }
}

// 具体实现2
public class SmsSender : IMessageSender
{
    public void Send(string msg)
    {
        Console.WriteLine("✅ 遵守DIP：发送短信消息：" + msg);
    }
}

// 高层模块：依赖抽象接口，不依赖具体实现
public class NotificationService
{
    private readonly IMessageSender _sender;

    // 依赖注入：通过构造函数传入具体实现
    public NotificationService(IMessageSender sender)
    {
        _sender = sender;
    }

    public void SendMsg(string msg)
    {
        _sender.Send(msg);
    }
}
#endregion

#region 原则6：迪米特法则 (Law of Demeter, LoD) / 最少知识原则
// 核心定义：一个对象应该对其他对象有最少的了解，只和直接朋友通信
// 朋友关系：成员变量、方法参数、this对象
// ==============================================
/// <summary>
/// 学生类
/// </summary>
public class Student
{
    public string Name { get; set; }
    public int Score { get; set; }
}

/// <summary>
/// 班级类
/// </summary>
public class ClassRoom
{
    public List<Student> Students { get; set; } = new List<Student>();
}

/// <summary>
/// 【违反LoD示例】老师直接深入学生内部获取分数，耦合度过高
/// </summary>
public class TeacherBad
{
    public void CheckScores(ClassRoom room)
    {
        // 遍历学生并直接访问分数，形成链式调用
        foreach (var s in room.Students)
        {
            Console.WriteLine($"{s.Name}的分数是{s.Score}");
        }
    }
}

/// <summary>
/// 【遵守LoD示例】封装内部逻辑，只暴露必要方法
/// </summary>
public class ClassRoomEx
{
    private List<Student> _students = new List<Student>();

    // 提供公开方法，隐藏内部集合细节
    public void PrintScores()
    {
        foreach (var s in _students)
        {
            Console.WriteLine($"✅ 遵守LoD：{s.Name}的分数是{s.Score}");
        }
    }

    public void AddStudent(Student s)
    {
        _students.Add(s);
    }
}

public class Teacher
{
    // 依赖班级对象，不依赖班级内部的学生集合
    public void PrintClassScores(ClassRoomEx room)
    {
        room.PrintScores(); // 只调用朋友的方法，不关心内部实现
    }
}
#endregion

#region 原则7：合成复用原则 (Composite Reuse Principle, CRP)
// 核心定义：尽量使用组合/聚合/关联，尽量不使用继承
// 含义：组合优于继承，降低类间耦合
// ==============================================
/// <summary>
/// 【违反CRP示例】过度使用继承，导致耦合高、灵活性差
/// </summary>
public class AnimalBad
{
    public virtual void Eat() { Console.WriteLine("动物吃东西"); }
}

public class DogBad : AnimalBad
{
    // 继承Animal，只能做Animal的事，无法灵活组合其他行为
}

/// <summary>
/// 【遵守CRP示例】组合行为接口，灵活组装功能
/// </summary>
// 行为接口
public interface IEater
{
    void Eat();
}

public interface IMover
{
    void Move();
}

// 具体行为实现
public class SimpleEater : IEater
{
    public void Eat()
    {
        Console.WriteLine("✅ 遵守CRP：吃东西");
    }
}

public class SimpleMover : IMover
{
    public void Move()
    {
        Console.WriteLine("✅ 遵守CRP：移动");
    }
}

// 动物类：组合行为，而非继承
public class Animal
{
    private readonly IEater _eater;
    private readonly IMover _mover;

    // 构造函数注入行为
    public Animal(IEater eater, IMover mover)
    {
        _eater = eater;
        _mover = mover;
    }

    public void DoAction()
    {
        _eater.Eat();
        _mover.Move();
    }
}
#endregion

#region 主程序：验证七大原则代码运行
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("===== 七大设计原则学习验证程序 =====");

        // 1. 单一职责
        var userSvc = new UserService();
        userSvc.GetUserInfo(1);
        var orderSvc = new OrderService();
        orderSvc.GetOrderList(1);

        // 2. 开闭原则
        Payment pay = new AlipayPayment();
        pay.Pay();
        pay = new WeChatPayment();
        pay.Pay();

        // 3. 里氏替换
        Shape rect = new RectangleEx { Width = 2, Height = 3 };
        Console.WriteLine($"矩形面积：{rect.GetArea()}");
        Shape square = new SquareEx { Side = 4 };
        Console.WriteLine($"正方形面积：{square.GetArea()}");

        // 4. 接口隔离
        IWorkable robot = new Robot();
        robot.Work();
        Human human = new Human();
        human.Eat();

        // 5. 依赖倒置
        NotificationService notice = new NotificationService(new SmsSender());
        notice.SendMsg("Hello, DIP!");

        // 6. 迪米特法则
        ClassRoomEx classRoom = new ClassRoomEx();
        classRoom.AddStudent(new Student { Name = "张三", Score = 90 });
        Teacher teacher = new Teacher();
        teacher.PrintClassScores(classRoom);

        // 7. 合成复用
        Animal animal = new Animal(new SimpleEater(), new SimpleMover());
        animal.DoAction();

        Console.WriteLine("\n===== 程序运行结束，按任意键退出 =====");
        Console.ReadKey();
    }
}
#endregion