using System;

#region 题目1：鸭子叫声多态实现（真鸭子嘎嘎叫，木头鸭子吱吱叫，橡皮鸭子唧唧叫）
/// <summary>
/// 鸭子抽象基类：定义鸭子的通用行为（叫）
/// 体现面向对象的多态思想：不同鸭子有不同的叫声
/// </summary>
public abstract class Duck
{
    /// <summary>
    /// 抽象方法：叫，由子类具体实现不同的叫声
    /// </summary>
    public abstract void Quack();
}

/// <summary>
/// 真鸭子类：继承Duck基类，实现嘎嘎叫
/// </summary>
public class RealDuck : Duck
{
    /// <summary>
    /// 重写基类的Quack方法，实现真鸭子的嘎嘎叫
    /// </summary>
    public override void Quack()
    {
        Console.WriteLine("真的鸭子嘎嘎叫");
    }
}

/// <summary>
/// 木头鸭子类：继承Duck基类，实现吱吱叫
/// </summary>
public class WoodDuck : Duck
{
    /// <summary>
    /// 重写基类的Quack方法，实现木头鸭子的吱吱叫
    /// </summary>
    public override void Quack()
    {
        Console.WriteLine("木头鸭子吱吱叫");
    }
}

/// <summary>
/// 橡皮鸭子类：继承Duck基类，实现唧唧叫
/// </summary>
public class RubberDuck : Duck
{
    /// <summary>
    /// 重写基类的Quack方法，实现橡皮鸭子的唧唧叫
    /// </summary>
    public override void Quack()
    {
        Console.WriteLine("橡皮鸭子唧唧叫");
    }
}
#endregion

#region 题目2：员工打卡规则实现（所有员工9点打卡，经理11点打卡，程序员不打卡）
/// <summary>
/// 员工基类：定义员工的通用打卡行为（默认9点打卡）
/// 体现继承与多态：子类可以重写父类的默认行为
/// </summary>
public class Employee
{
    /// <summary>
    /// 打卡方法：默认所有员工9点打卡
    /// 用virtual标记，允许子类重写
    /// </summary>
    public virtual void PunchIn()
    {
        Console.WriteLine("所有员工9点打卡");
    }
}

/// <summary>
/// 经理类：继承Employee基类，重写打卡方法为11点打卡
/// </summary>
public class Manager : Employee
{
    /// <summary>
    /// 重写父类的PunchIn方法，实现经理11点打卡
    /// </summary>
    public override void PunchIn()
    {
        Console.WriteLine("经理十一点打卡");
    }
}

/// <summary>
/// 程序员类：继承Employee基类，重写打卡方法为不打卡
/// </summary>
public class Programmer : Employee
{
    /// <summary>
    /// 重写父类的PunchIn方法，实现程序员不打卡
    /// </summary>
    public override void PunchIn()
    {
        Console.WriteLine("程序员不打卡");
    }
}
#endregion

#region 题目3：图形类继承实现（图形基类+矩形/正方形/圆形子类，求面积和周长）
/// <summary>
/// 图形抽象基类：定义图形的通用行为（求面积、求周长）
/// 用抽象类强制子类必须实现面积和周长的计算
/// </summary>
public abstract class Shape
{
    /// <summary>
    /// 抽象方法：求图形面积，由子类具体实现
    /// </summary>
    /// <returns>图形的面积</returns>
    public abstract double GetArea();

    /// <summary>
    /// 抽象方法：求图形周长，由子类具体实现
    /// </summary>
    /// <returns>图形的周长</returns>
    public abstract double GetPerimeter();
}

/// <summary>
/// 矩形类：继承Shape基类，实现矩形的面积和周长计算
/// </summary>
public class Rectangle : Shape
{
    // 矩形的长和宽（私有字段，封装数据）
    private double _length;
    private double _width;

    /// <summary>
    /// 构造函数：初始化矩形的长和宽
    /// </summary>
    /// <param name="length">长</param>
    /// <param name="width">宽</param>
    public Rectangle(double length, double width)
    {
        // 校验输入合法性，避免负数
        if (length <= 0 || width <= 0)
            throw new ArgumentException("矩形的长和宽必须大于0");
        _length = length;
        _width = width;
    }

    /// <summary>
    /// 重写GetArea方法：计算矩形面积（长×宽）
    /// </summary>
    public override double GetArea()
    {
        return _length * _width;
    }

    /// <summary>
    /// 重写GetPerimeter方法：计算矩形周长（2×(长+宽)）
    /// </summary>
    public override double GetPerimeter()
    {
        return 2 * (_length + _width);
    }
}

/// <summary>
/// 正方形类：继承Shape基类，实现正方形的面积和周长计算
/// 也可以继承Rectangle类（正方形是特殊的矩形），这里直接继承Shape更直观
/// </summary>
public class Square : Shape
{
    // 正方形的边长（私有字段，封装数据）
    private double _side;

    /// <summary>
    /// 构造函数：初始化正方形的边长
    /// </summary>
    /// <param name="side">边长</param>
    public Square(double side)
    {
        if (side <= 0)
            throw new ArgumentException("正方形的边长必须大于0");
        _side = side;
    }

    /// <summary>
    /// 重写GetArea方法：计算正方形面积（边长×边长）
    /// </summary>
    public override double GetArea()
    {
        return _side * _side;
    }

    /// <summary>
    /// 重写GetPerimeter方法：计算正方形周长（4×边长）
    /// </summary>
    public override double GetPerimeter()
    {
        return 4 * _side;
    }
}

/// <summary>
/// 圆形类：继承Shape基类，实现圆形的面积和周长计算
/// </summary>
public class Circle : Shape
{
    // 圆形的半径（私有字段，封装数据）
    private double _radius;
    // 圆周率π，用常量保证精度
    private const double PI = 3.141592653589793;

    /// <summary>
    /// 构造函数：初始化圆形的半径
    /// </summary>
    /// <param name="radius">半径</param>
    public Circle(double radius)
    {
        if (radius <= 0)
            throw new ArgumentException("圆形的半径必须大于0");
        _radius = radius;
    }

    /// <summary>
    /// 重写GetArea方法：计算圆形面积（π×半径²）
    /// </summary>
    public override double GetArea()
    {
        return PI * _radius * _radius;
    }

    /// <summary>
    /// 重写GetPerimeter方法：计算圆形周长（2×π×半径）
    /// </summary>
    public override double GetPerimeter()
    {
        return 2 * PI * _radius;
    }
}
#endregion

/// <summary>
/// 程序主入口类：统一管理测试方法，解决静态方法调用问题
/// </summary>
public class Program
{
    #region 题目1测试方法
    /// <summary>
    /// 鸭子叫声测试方法：演示多态效果
    /// </summary>
    public static void TestDuckQuack()
    {
        // 用基类类型引用子类对象，体现多态
        Duck realDuck = new RealDuck();
        Duck woodDuck = new WoodDuck();
        Duck rubberDuck = new RubberDuck();

        // 调用同一个方法，不同子类执行不同逻辑
        realDuck.Quack();
        woodDuck.Quack();
        rubberDuck.Quack();
    }
    #endregion

    #region 题目2测试方法
    /// <summary>
    /// 员工打卡测试方法：演示继承与多态
    /// </summary>
    public static void TestEmployeePunchIn()
    {
        // 用基类类型引用子类对象，体现多态
        Employee emp = new Employee();
        Employee manager = new Manager();
        Employee programmer = new Programmer();

        // 调用同一个方法，不同角色执行不同逻辑
        emp.PunchIn();
        manager.PunchIn();
        programmer.PunchIn();
    }
    #endregion

    #region 题目3测试方法
    /// <summary>
    /// 图形计算测试方法：实例化不同图形，计算并输出面积和周长
    /// </summary>
    public static void TestShapeCalculate()
    {
        // 1. 实例化矩形（长5，宽3）
        Shape rectangle = new Rectangle(5, 3);
        Console.WriteLine($"矩形：面积 = {rectangle.GetArea():F2}，周长 = {rectangle.GetPerimeter():F2}");

        // 2. 实例化正方形（边长4）
        Shape square = new Square(4);
        Console.WriteLine($"正方形：面积 = {square.GetArea():F2}，周长 = {square.GetPerimeter():F2}");

        // 3. 实例化圆形（半径2）
        Shape circle = new Circle(2);
        Console.WriteLine($"圆形：面积 = {circle.GetArea():F2}，周长 = {circle.GetPerimeter():F2}");
    }
    #endregion

    /// <summary>
    /// 程序入口：调用所有测试方法
    /// </summary>
    public static void Main()
    {
        Console.WriteLine("===== 题目1：鸭子叫声测试 =====");
        TestDuckQuack();

        Console.WriteLine("\n===== 题目2：员工打卡测试 =====");
        TestEmployeePunchIn();

        Console.WriteLine("\n===== 题目3：图形计算测试 =====");
        TestShapeCalculate();

        // 暂停控制台，方便查看结果（可选）
        Console.WriteLine("\n按任意键退出...");
        Console.ReadKey();
    }
}