#region 题目1：定义载具类并实现需求
using System;
using System.Collections.Generic;

// 定义乘客类，用于存储乘客信息（姓名等）
#region 乘客类定义
public class Passenger
{
    // 乘客姓名属性
    public string Name { get; set; }

    // 构造函数：初始化乘客姓名
    public Passenger(string name)
    {
        Name = name;
    }

    // 重写ToString方法，方便打印乘客信息
    public override string ToString()
    {
        return Name;
    }
}
#endregion

// 定义司机类，用于存储司机信息（姓名等）
#region 司机类定义
public class Driver
{
    // 司机姓名属性
    public string Name { get; set; }

    // 构造函数：初始化司机姓名
    public Driver(string name)
    {
        Name = name;
    }

    // 重写ToString方法，方便打印司机信息
    public override string ToString()
    {
        return Name;
    }
}
#endregion

// 核心：载具类（Vehicle），包含题目要求的所有属性和方法
#region 载具类(Vehicle)核心定义
public class Vehicle
{
    // ====================== 题目要求的属性 ======================
    // 当前速度
    private double _currentSpeed;
    // 最大速度（载具的限速）
    private double _maxSpeed;
    // 可乘人数（载具的最大载客量，含司机）
    private int _maxPassengerCount;
    // 司机对象
    private Driver _driver;
    // 乘客列表（存储所有上车的乘客）
    private List<Passenger> _passengers;

    // ====================== 属性的封装（公开访问器） ======================
    // 当前速度：只能在0到最大速度之间设置
    public double CurrentSpeed
    {
        get { return _currentSpeed; }
        set
        {
            if (value < 0)
                _currentSpeed = 0;
            else if (value > _maxSpeed)
                _currentSpeed = _maxSpeed;
            else
                _currentSpeed = value;
        }
    }

    // 最大速度：构造后不可修改（载具出厂限速固定）
    public double MaxSpeed => _maxSpeed;

    // 可乘人数：构造后不可修改（载具座位数固定）
    public int MaxPassengerCount => _maxPassengerCount;

    // 司机：可设置/获取
    public Driver Driver
    {
        get { return _driver; }
        set { _driver = value; }
    }

    // 当前乘客数量（只读，方便外部查看）
    public int CurrentPassengerCount => _passengers.Count;

    // ====================== 构造函数：初始化载具 ======================
    /// <summary>
    /// 载具类构造函数
    /// </summary>
    /// <param name="maxSpeed">载具最大速度</param>
    /// <param name="maxPassengerCount">载具最大可乘人数（含司机）</param>
    public Vehicle(double maxSpeed, int maxPassengerCount)
    {
        // 初始化最大速度（不能为负）
        _maxSpeed = maxSpeed > 0 ? maxSpeed : 120;
        // 初始化最大载客量（至少1个司机位）
        _maxPassengerCount = maxPassengerCount > 0 ? maxPassengerCount : 1;
        // 初始速度为0（静止）
        _currentSpeed = 0;
        // 初始化乘客列表
        _passengers = new List<Passenger>();
        // 初始司机为空
        _driver = null;
    }

    // ====================== 题目要求的方法 ======================

    #region 上车方法(GetOn)
    /// <summary>
    /// 乘客上车方法
    /// </summary>
    /// <param name="passenger">要上车的乘客对象</param>
    /// <returns>是否上车成功（true=成功，false=满员/无效乘客）</returns>
    public bool GetOn(Passenger passenger)
    {
        // 校验：乘客对象不为空，且当前乘客数+司机数 < 最大可乘人数
        if (passenger == null)
        {
            Console.WriteLine("上车失败：乘客信息无效！");
            return false;
        }

        // 计算当前总人数（司机+乘客）
        int currentTotal = (_driver != null ? 1 : 0) + _passengers.Count;
        if (currentTotal >= _maxPassengerCount)
        {
            Console.WriteLine($"上车失败：载具已满员！当前总人数{currentTotal}，最大可乘{_maxPassengerCount}人");
            return false;
        }

        // 校验：乘客未重复上车
        if (_passengers.Contains(passenger))
        {
            Console.WriteLine($"上车失败：{passenger.Name}已经在车上了！");
            return false;
        }

        // 执行上车：添加到乘客列表
        _passengers.Add(passenger);
        Console.WriteLine($"{passenger.Name}上车成功！当前乘客数：{_passengers.Count}");
        return true;
    }
    #endregion

    #region 下车方法(GetOff)
    /// <summary>
    /// 乘客下车方法
    /// </summary>
    /// <param name="passenger">要下车的乘客对象</param>
    /// <returns>是否下车成功（true=成功，false=乘客不在车上/无效）</returns>
    public bool GetOff(Passenger passenger)
    {
        // 校验：乘客对象不为空，且在乘客列表中
        if (passenger == null)
        {
            Console.WriteLine("下车失败：乘客信息无效！");
            return false;
        }

        if (!_passengers.Contains(passenger))
        {
            Console.WriteLine($"下车失败：{passenger.Name}不在车上！");
            return false;
        }

        // 执行下车：从列表移除
        _passengers.Remove(passenger);
        Console.WriteLine($"{passenger.Name}下车成功！当前乘客数：{_passengers.Count}");
        return true;
    }
    #endregion

    #region 行驶方法(Drive)
    /// <summary>
    /// 载具行驶方法：设置行驶速度
    /// </summary>
    /// <param name="targetSpeed">目标行驶速度</param>
    public void Drive(double targetSpeed)
    {
        // 校验：必须有司机才能行驶
        if (_driver == null)
        {
            Console.WriteLine("行驶失败：没有司机，无法启动载具！");
            _currentSpeed = 0;
            return;
        }

        // 设置速度（通过CurrentSpeed属性自动限制在0~MaxSpeed之间）
        CurrentSpeed = targetSpeed;

        if (_currentSpeed > 0)
            Console.WriteLine($"载具开始行驶！当前速度：{_currentSpeed} km/h（最大限速{_maxSpeed} km/h）");
        else
            Console.WriteLine("载具已停车！当前速度：0 km/h");
    }
    #endregion

    #region 车祸方法(Accident)
    /// <summary>
    /// 车祸方法：模拟载具发生事故
    /// </summary>
    public void Accident()
    {
        // 车祸发生后：速度归零，所有乘客和司机下车
        _currentSpeed = 0;
        _passengers.Clear();
        _driver = null;

        Console.WriteLine("⚠️  载具发生车祸！速度归零，所有人员已撤离！");
    }
    #endregion

    #region 辅助方法：打印载具当前状态
    /// <summary>
    /// 打印载具当前状态（方便调试和查看）
    /// </summary>
    public void PrintStatus()
    {
        Console.WriteLine("\n========== 载具当前状态 ==========");
        Console.WriteLine($"最大速度：{_maxSpeed} km/h");
        Console.WriteLine($"当前速度：{_currentSpeed} km/h");
        Console.WriteLine($"最大可乘人数：{_maxPassengerCount} 人");
        Console.WriteLine($"司机：{(_driver != null ? _driver.Name : "无")}");
        Console.WriteLine($"当前乘客数：{_passengers.Count} 人");
        Console.WriteLine("乘客列表：");
        if (_passengers.Count == 0)
            Console.WriteLine("  无乘客");
        else
        {
            for (int i = 0; i < _passengers.Count; i++)
            {
                Console.WriteLine($"  {i + 1}. {_passengers[i].Name}");
            }
        }
        Console.WriteLine("==================================\n");
    }
    #endregion
}
#endregion

// ====================== 主程序：测试载具类 ======================
#region 主程序测试代码
class Program
{
    static void Main(string[] args)
    {
        // 1. 用载具类声明一个对象（实例化一辆汽车：最大速度180km/h，可乘5人）
        Vehicle myCar = new Vehicle(180, 5);
        Console.WriteLine("=== 初始化载具（5座轿车，最大180km/h） ===");
        myCar.PrintStatus();

        // 2. 设置司机
        myCar.Driver = new Driver("张师傅");
        Console.WriteLine("=== 设置司机后 ===");
        myCar.PrintStatus();

        // 3. 将若干人装载上车（模拟乘客上车）
        Passenger p1 = new Passenger("小明");
        Passenger p2 = new Passenger("小红");
        Passenger p3 = new Passenger("小刚");
        Passenger p4 = new Passenger("小美");
        Passenger p5 = new Passenger("小强"); // 第5人：司机+4乘客=5人，满员

        myCar.GetOn(p1);
        myCar.GetOn(p2);
        myCar.GetOn(p3);
        myCar.GetOn(p4);
        myCar.GetOn(p5); // 测试满员情况

        Console.WriteLine("=== 乘客上车完成后 ===");
        myCar.PrintStatus();

        // 4. 测试行驶方法
        myCar.Drive(120); // 正常行驶
        myCar.Drive(200); // 测试超速（自动限制为180）
        myCar.Drive(0);   // 停车

        // 5. 测试下车方法
        myCar.GetOff(p2);
        myCar.GetOff(p5); // 测试不在车上的乘客下车

        Console.WriteLine("=== 乘客下车后 ===");
        myCar.PrintStatus();

        // 6. 测试车祸方法
        myCar.Drive(80); // 先行驶
        myCar.Accident(); // 发生车祸
        myCar.PrintStatus();

        Console.WriteLine("\n=== 测试完成，按任意键退出 ===");
        Console.ReadKey();
    }
}
#endregion
#endregion