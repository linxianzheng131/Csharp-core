using System;

#region 打工人继承案例
/// <summary>
/// 打工人基类
/// 包含工种、工作内容两个特征，以及工作方法
/// </summary>
public class Worker
{
    // 工种特征
    public string JobType { get; set; }
    // 工作内容特征
    public string WorkContent { get; set; }

    /// <summary>
    /// 基类构造函数：初始化工种和工作内容
    /// </summary>
    /// <param name="jobType">工种名称</param>
    /// <param name="workContent">工作内容</param>
    public Worker(string jobType, string workContent)
    {
        JobType = jobType;
        WorkContent = workContent;
    }

    /// <summary>
    /// 工作方法：输出工作信息
    /// </summary>
    public void Work()
    {
        Console.WriteLine($"我是{JobType}，我的工作内容是：{WorkContent}");
    }
}

/// <summary>
/// 程序员类：继承打工人基类
/// </summary>
public class Programmer : Worker
{
    /// <summary>
    /// 程序员构造函数
    /// 调用基类构造函数，传入固定的工种和工作内容
    /// </summary>
    public Programmer() : base("程序员", "写代码、改Bug、需求开发")
    {
    }
}

/// <summary>
/// 策划类：继承打工人基类
/// </summary>
public class Planner : Worker
{
    /// <summary>
    /// 策划构造函数
    /// 调用基类构造函数，传入固定的工种和工作内容
    /// </summary>
    public Planner() : base("策划", "写需求、改方案、对接程序美术")
    {
    }
}

/// <summary>
/// 美术类：继承打工人基类
/// </summary>
public class Artist : Worker
{
    /// <summary>
    /// 美术构造函数
    /// 调用基类构造函数，传入固定的工种和工作内容
    /// </summary>
    public Artist() : base("美术", "画原画、做UI、调特效")
    {
    }
}
#endregion

#region 测试代码
class Program
{
    static void Main(string[] args)
    {
        // 实例化程序员对象       
        Worker programmer = new Programmer();
        // 实例化策划对象
        Worker planner = new Planner();
        // 实例化美术对象
        Worker artist = new Artist();

        // 调用工作方法
        programmer.Work();
        planner.Work();
        artist.Work();
    }
}
#endregion