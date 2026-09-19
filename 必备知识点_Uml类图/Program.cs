using System;
using System.Collections.Generic;

// ==============================================
// 【总览：UML类图是什么？】
// UML类图是面向对象系统的可视化建模工具，用来描述：
// 1. 类的结构（属性、方法）
// 2. 类之间的关系（继承、关联、依赖、聚合、组合等）
// 3. 代码的蓝图，直接对应C#的类、接口、继承等语法
// 下面用C#代码还原UML类图的所有核心元素，一一对应讲解
// ==============================================

#region 知识点1：UML类的基本结构（类名 + 属性 + 方法）
// UML类图中，一个类分为3层：
// 第1层：类名（Class Name）
// 第2层：属性（Attributes） → 对应C#的字段/属性
// 第3层：方法（Methods） → 对应C#的成员方法
// 访问修饰符对应：+ public  - private  # protected  ~ internal
// ==============================================
/// <summary>
/// UML类图对应：Student类
/// UML表示：
/// +-------------------------+
/// |         Student         |  ← 类名
/// +-------------------------+
/// | - _studentId : string   |  ← 私有属性（- 代表private）
/// | - _name : string        |
/// | + StudentId : string    |  ← 公开属性（+ 代表public）
/// | + Name : string         |
/// +-------------------------+
/// | + Study() : void        |  ← 公开方法
/// | + GetInfo() : string    |
/// +-------------------------+
/// </summary>
public class Student
{
    // UML属性：- _studentId : string （- 代表private私有）
    private string _studentId;
    private string _name;

    // UML属性：+ StudentId : string （+ 代表public公开）
    public string StudentId
    {
        get { return _studentId; }
        set { _studentId = value; }
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    // 构造函数：UML中也会标注，用于初始化对象
    public Student(string studentId, string name)
    {
        _studentId = studentId;
        _name = name;
    }

    // UML方法：+ Study() : void
    public void Study()
    {
        Console.WriteLine($"学生 {_name}（学号：{_studentId}）正在学习");
    }

    // UML方法：+ GetInfo() : string
    public string GetInfo()
    {
        return $"学号：{_studentId}，姓名：{_name}";
    }
}
#endregion

#region 知识点2：UML类图的关系1 —— 继承/泛化（Inheritance/Generalization）
// UML表示：空心三角箭头 → 指向父类
// 对应C#语法：class 子类 : 父类
// 含义：子类继承父类的属性和方法，是"is-a"的关系
// ==============================================
/// <summary>
/// 父类：Person（人）
/// UML类图：
/// +-------------------------+
/// |          Person         |
/// +-------------------------+
/// | - _name : string        |
/// | - _age : int            |
/// +-------------------------+
/// | + SayHello() : void     |
/// +-------------------------+
/// </summary>
public class Person
{
    private string _name;
    private int _age;

    public string Name { get { return _name; } set { _name = value; } }
    public int Age { get { return _age; } set { _age = value; } }

    public Person(string name, int age)
    {
        _name = name;
        _age = age;
    }

    public virtual void SayHello()
    {
        Console.WriteLine($"大家好，我是{_name}，今年{_age}岁");
    }
}

/// <summary>
/// 子类：Student（学生），继承自Person
/// UML关系：Student ──▷ Person （空心三角箭头指向父类）
/// 对应C#：public class Student : Person
/// </summary>
public class StudentEx : Person
{
    private string _studentId;

    public string StudentId { get { return _studentId; } set { _studentId = value; } }

    public StudentEx(string name, int age, string studentId) : base(name, age)
    {
        _studentId = studentId;
    }

    // 重写父类方法：UML中标记为{override}
    public override void SayHello()
    {
        Console.WriteLine($"大家好，我是学生{Name}，学号{_studentId}，今年{Age}岁");
    }

    public void Study()
    {
        Console.WriteLine($"学生{Name}正在学习");
    }
}

/// <summary>
/// 子类：Teacher（教师），继承自Person
/// UML关系：Teacher ──▷ Person
/// </summary>
public class Teacher : Person
{
    private string _course;

    public string Course { get { return _course; } set { _course = value; } }

    public Teacher(string name, int age, string course) : base(name, age)
    {
        _course = course;
    }

    public override void SayHello()
    {
        Console.WriteLine($"大家好，我是{Course}老师{Name}，今年{Age}岁");
    }

    public void Teach()
    {
        Console.WriteLine($"老师{Name}正在讲授{Course}课程");
    }
}
#endregion

#region 知识点3：UML类图的关系2 —— 实现（Realization/Implementation）
// UML表示：空心三角虚线箭头 → 指向接口
// 对应C#语法：class 类 : 接口
// 含义：类实现接口的所有方法，是"can-do"的关系
// ==============================================
/// <summary>
/// 接口：ISchoolMember（校园成员）
/// UML类图：接口名用<<interface>>标注
/// +-------------------------+
/// |    <<interface>>        |
/// |     ISchoolMember       |
/// +-------------------------+
/// | + AttendSchool() : void |
/// +-------------------------+
/// </summary>
public interface ISchoolMember
{
    // 接口方法：UML中默认public，C#中也默认public
    void AttendSchool();
}

/// <summary>
/// StudentEx实现ISchoolMember接口
/// UML关系：StudentEx ──▷▷ ISchoolMember （虚线空心三角）
/// 对应C#：public class StudentEx : Person, ISchoolMember
/// </summary>
public class StudentExWithInterface : Person, ISchoolMember
{
    private string _studentId;
    public string StudentId { get { return _studentId; } set { _studentId = value; } }

    public StudentExWithInterface(string name, int age, string studentId) : base(name, age)
    {
        _studentId = studentId;
    }

    // 实现接口方法
    public void AttendSchool()
    {
        Console.WriteLine($"学生{Name}到校上课");
    }
}
#endregion

#region 知识点4：UML类图的关系3 —— 关联（Association）
// UML表示：实线箭头/无箭头，标注多重度（1, *, 1..* 等）
// 对应C#语法：一个类持有另一个类的引用
// 含义：两个类之间有固定的"has-a"连接关系
// 多重度说明：
// 1  →  1个
// *  →  0或多个
// 1..* → 1或多个
// 0..1 → 0或1个
// ==============================================
/// <summary>
/// 班级类：ClassRoom
/// UML关联关系：ClassRoom 1 -- * Student （1个班级有多个学生）
/// 对应C#：ClassRoom中持有List<Student>的引用
/// </summary>
public class ClassRoom
{
    private string _classId;
    // 关联：一个班级包含多个学生（* 代表多个）
    private List<StudentEx> _students = new List<StudentEx>();

    public string ClassId { get { return _classId; } }
    public List<StudentEx> Students { get { return _students; } }

    public ClassRoom(string classId)
    {
        _classId = classId;
    }

    // 添加学生到班级（关联关系的操作）
    public void AddStudent(StudentEx student)
    {
        _students.Add(student);
        Console.WriteLine($"学生{student.Name}加入班级{_classId}");
    }

    // 班级点名
    public void CallRoll()
    {
        Console.WriteLine($"班级{_classId}开始点名：");
        foreach (var student in _students)
        {
            Console.WriteLine($"- {student.Name}（学号：{student.StudentId}）");
        }
    }
}
#endregion

#region 知识点5：UML类图的关系4 —— 聚合（Aggregation）& 组合（Composition）
// 【聚合 Aggregation】
// UML表示：空心菱形 + 实线 → 指向整体
// 含义：整体和部分可以独立存在，是"has-a"的弱关系（如：班级和学生，学生可以离开班级）
// ==============================================
/// <summary>
/// 聚合示例：班级（整体）聚合学生（部分）
/// UML：ClassRoom ◇-- Student （空心菱形在整体端）
/// 特点：学生可以脱离班级独立存在，删除班级，学生依然存在
/// </summary>

// ==============================================
// 【组合 Composition】
// UML表示：实心菱形 + 实线 → 指向整体
// 含义：整体和部分生命周期绑定，是"contains-a"的强关系（如：订单和订单项，订单删除，订单项也删除）
// 对应C#：整体类在内部创建部分类的实例，部分类不能脱离整体存在
// ==============================================
/// <summary>
/// 订单类：Order（整体）
/// 订单项类：OrderItem（部分）
/// UML关系：Order ◆-- OrderItem （实心菱形在整体端）
/// 特点：订单项依赖订单存在，订单删除，订单项也被删除
/// </summary>
public class Order
{
    private string _orderId;
    // 组合：订单包含订单项，订单项由订单内部创建
    private List<OrderItem> _items = new List<OrderItem>();

    public string OrderId { get { return _orderId; } }
    public List<OrderItem> Items { get { return _items; } }

    public Order(string orderId)
    {
        _orderId = orderId;
    }

    // 添加订单项：在订单内部创建OrderItem实例
    public void AddItem(string productName, decimal price)
    {
        var item = new OrderItem(this, productName, price);
        _items.Add(item);
        Console.WriteLine($"订单{_orderId}添加商品：{productName}，价格：{price}元");
    }

    // 计算订单总金额
    public decimal GetTotalAmount()
    {
        decimal total = 0;
        foreach (var item in _items)
        {
            total += item.Price;
        }
        return total;
    }
}

/// <summary>
/// 订单项类：OrderItem（部分）
/// 依赖Order存在，不能独立创建
/// </summary>
public class OrderItem
{
    private Order _order; // 持有所属订单的引用
    private string _productName;
    private decimal _price;

    public string ProductName { get { return _productName; } }
    public decimal Price { get { return _price; } }
    public Order Order { get { return _order; } }

    // 构造函数强制依赖Order，无法独立创建
    public OrderItem(Order order, string productName, decimal price)
    {
        _order = order;
        _productName = productName;
        _price = price;
    }
}
#endregion

#region 知识点6：UML类图的关系5 —— 依赖（Dependency）
// UML表示：虚线箭头 → 指向被依赖的类
// 对应C#语法：一个类的方法中使用了另一个类的对象（临时使用，不是长期持有）
// 含义：一个类依赖另一个类的功能，是"use-a"的弱关系
// ==============================================
/// <summary>
/// 工具类：SchoolNotice（学校通知）
/// 被依赖的类
/// </summary>
public static class SchoolNotice
{
    public static void SendNotice(string content)
    {
        Console.WriteLine($"学校通知：{content}");
    }
}

/// <summary>
/// 班主任类：HeadTeacher
/// 依赖SchoolNotice工具类，发送通知
/// UML关系：HeadTeacher -.-> SchoolNotice （虚线箭头指向被依赖类）
/// 对应C#：HeadTeacher的方法中临时使用SchoolNotice
/// </summary>
public class HeadTeacher : Person
{
    public HeadTeacher(string name, int age) : base(name, age) { }

    // 方法中依赖SchoolNotice类
    public void SendStudentNotice()
    {
        // 临时使用SchoolNotice，不是长期持有引用 → 依赖关系
        SchoolNotice.SendNotice($"请{Name}老师通知学生明天交作业");
    }
}
#endregion

#region 知识点7：UML类图的其他核心元素（抽象类、静态成员、枚举）
// ==============================================
// 1. 抽象类（Abstract Class）
// UML表示：类名斜体，或标注{abstract}
// 对应C#：abstract class 类名
// 特点：不能实例化，只能被继承，包含抽象方法
// ==============================================
/// <summary>
/// 抽象类：Animal
/// UML：类名斜体，方法标注{abstract}
/// </summary>
public abstract class Animal
{
    // 抽象方法：没有实现，子类必须重写
    public abstract void MakeSound();

    // 普通方法：有默认实现
    public void Sleep()
    {
        Console.WriteLine("动物在睡觉");
    }
}

public class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("汪汪汪");
    }
}

// ==============================================
// 2. 静态成员（Static Member）
// UML表示：成员名下划线标注
// 对应C#：static 修饰的字段/方法
// ==============================================
/// <summary>
/// UML静态成员示例：
/// +-------------------------+
/// |      SchoolConfig       |
/// +-------------------------+
/// | + _schoolName : string  | （下划线代表static）
/// | + GetSchoolName() : string
/// +-------------------------+
/// </summary>
public static class SchoolConfig
{
    // 静态字段：UML用下划线标注
    private static string _schoolName = "XX中学";
    public static string SchoolName { get { return _schoolName; } }

    // 静态方法
    public static string GetSchoolInfo()
    {
        return $"学校名称：{_schoolName}";
    }
}

// ==============================================
// 3. 枚举（Enumeration）
// UML表示：<<enumeration>> 标注
// 对应C#：enum 枚举名
// ==============================================
/// <summary>
/// UML枚举：
/// +-------------------------+
/// |    <<enumeration>>      |
/// |      StudentStatus      |
/// +-------------------------+
/// | 正常                     |
/// | 休学                     |
/// | 毕业                     |
/// +-------------------------+
/// </summary>
public enum StudentStatus
{
    正常,
    休学,
    毕业
}
#endregion

#region 主程序：运行所有UML对应代码，验证逻辑
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("===== UML类图知识点验证程序 =====");
        Console.WriteLine("\n【1. 类的基本结构（Student类）】");
        Student stu = new Student("2024001", "张三");
        stu.Study();
        Console.WriteLine(stu.GetInfo());

        Console.WriteLine("\n【2. 继承关系（Person → StudentEx/Teacher）】");
        Person stu2 = new StudentEx("李四", 16, "2024002");
        Person tea = new Teacher("王老师", 35, "C#编程");
        stu2.SayHello();
        tea.SayHello();
        ((Teacher)tea).Teach();

        Console.WriteLine("\n【3. 接口实现（ISchoolMember）】");
        ISchoolMember member = new StudentExWithInterface("赵六", 17, "2024003");
        member.AttendSchool();

        Console.WriteLine("\n【4. 关联关系（ClassRoom 1 -- * Student）】");
        ClassRoom room = new ClassRoom("高一(1)班");
        room.AddStudent((StudentEx)stu2);
        room.AddStudent(new StudentEx("孙七", 16, "2024004"));
        room.CallRoll();

        Console.WriteLine("\n【5. 组合关系（Order ◆-- OrderItem）】");
        Order order = new Order("ORD2024001");
        order.AddItem("C#编程教程", 99.9m);
        order.AddItem("计算机基础", 59.9m);
        Console.WriteLine($"订单总金额：{order.GetTotalAmount()}元");

        Console.WriteLine("\n【6. 依赖关系（HeadTeacher依赖SchoolNotice）】");
        HeadTeacher headTeacher = new HeadTeacher("张主任", 40);
        headTeacher.SendStudentNotice();

        Console.WriteLine("\n【7. 抽象类、静态类、枚举】");
        Animal dog = new Dog();
        dog.MakeSound();
        dog.Sleep();
        Console.WriteLine(SchoolConfig.GetSchoolInfo());
        StudentStatus status = StudentStatus.正常;
        Console.WriteLine($"学生状态：{status}");

        Console.WriteLine("\n===== 程序运行结束，按任意键退出 =====");
        Console.ReadKey();
    }
}
#endregion