using System;

#region 题目1：接口实现登记功能（人/汽车/房子不同登记地点）
/// <summary>
/// 登记接口：定义所有需要登记的对象的通用行为
/// 接口是一种契约，强制实现类必须实现登记方法
/// </summary>
public interface IRegister
{
    /// <summary>
    /// 登记方法：由具体类实现不同的登记逻辑
    /// </summary>
    void Register();
}

/// <summary>
/// 人类：实现IRegister接口，到派出所登记
/// </summary>
public class Person : IRegister
{
    /// <summary>
    /// 实现接口的Register方法：人到派出所登记
    /// </summary>
    public void Register()
    {
        Console.WriteLine("人需要到派出所登记");
    }
}

/// <summary>
/// 汽车类：实现IRegister接口，到车管所登记
/// </summary>
public class Car : IRegister
{
    /// <summary>
    /// 实现接口的Register方法：汽车到车管所登记
    /// </summary>
    public void Register()
    {
        Console.WriteLine("汽车需要去车管所登记");
    }
}

/// <summary>
/// 房子类：实现IRegister接口，到房管局登记
/// </summary>
public class House : IRegister
{
    /// <summary>
    /// 实现接口的Register方法：房子到房管局登记
    /// </summary>
    public void Register()
    {
        Console.WriteLine("房子需要去房管局登记");
    }
}
#endregion

#region 题目2：面向对象实现鸟类/直升机的飞/走/游泳行为
/// <summary>
/// 飞的接口：定义能飞的对象的行为
/// </summary>
public interface IFlyable
{
    void Fly();
}

/// <summary>
/// 走的接口：定义能走的对象的行为
/// </summary>
public interface IWalkable
{
    void Walk();
}

/// <summary>
/// 游泳的接口：定义能游泳的对象的行为
/// </summary>
public interface ISwimmable
{
    void Swim();
}

/// <summary>
/// 鸟类抽象基类：所有鸟类的父类，默认实现走的行为
/// </summary>
public abstract class Bird : IWalkable
{
    /// <summary>
    /// 鸟类默认都能走，实现IWalkable接口
    /// </summary>
    public virtual void Walk()
    {
        Console.WriteLine($"{GetType().Name} 能走");
    }
}

/// <summary>
/// 麻雀类：继承Bird，实现飞的接口
/// </summary>
public class Sparrow : Bird, IFlyable
{
    public void Fly()
    {
        Console.WriteLine("麻雀 能飞");
    }
}

/// <summary>
/// 鸵鸟类：继承Bird，不能飞，不能游泳
/// </summary>
public class Ostrich : Bird
{
    // 不实现IFlyable和ISwimmable，代表不能飞、不能游泳
}

/// <summary>
/// 企鹅类：继承Bird，实现游泳接口，不能飞
/// </summary>
public class Penguin : Bird, ISwimmable
{
    public void Swim()
    {
        Console.WriteLine("企鹅 能游泳");
    }
}

/// <summary>
/// 鹦鹉类：继承Bird，实现飞的接口
/// </summary>
public class Parrot : Bird, IFlyable
{
    public void Fly()
    {
        Console.WriteLine("鹦鹉 能飞");
    }
}

/// <summary>
/// 天鹅类：继承Bird，实现飞和游泳的接口
/// </summary>
public class Swan : Bird, IFlyable, ISwimmable
{
    public void Fly()
    {
        Console.WriteLine("天鹅 能飞");
    }

    public void Swim()
    {
        Console.WriteLine("天鹅 能游泳");
    }
}

/// <summary>
/// 直升机类：实现飞的接口，不能走、不能游泳
/// </summary>
public class Helicopter : IFlyable
{
    public void Fly()
    {
        Console.WriteLine("直升机 能飞");
    }

    // 不实现IWalkable和ISwimmable，代表不能走、不能游泳
}
#endregion

#region 题目3：多态+USB接口实现存储/播放设备数据传输
/// <summary>
/// USB接口：定义所有能插在电脑上的设备的通用行为
/// 电脑通过这个接口和所有设备通信，实现多态
/// </summary>
public interface IUsbDevice
{
    /// <summary>
    /// 传输数据方法：由具体设备实现不同的传输逻辑
    /// </summary>
    void TransferData();
}

/// <summary>
/// 存储设备抽象基类：继承IUsbDevice，所有存储设备的父类
/// </summary>
public abstract class StorageDevice : IUsbDevice
{
    public abstract void TransferData();
}

/// <summary>
/// 移动硬盘类：继承StorageDevice，实现存储设备的传输逻辑
/// </summary>
public class MobileHardDisk : StorageDevice
{
    public override void TransferData()
    {
        Console.WriteLine("移动硬盘（存储设备）插到电脑上，传输数据");
    }
}

/// <summary>
/// U盘类：继承StorageDevice，实现存储设备的传输逻辑
/// </summary>
public class UDisk : StorageDevice
{
    public override void TransferData()
    {
        Console.WriteLine("U盘（存储设备）插到电脑上，传输数据");
    }
}

/// <summary>
/// MP3类：实现IUsb接口，属于播放设备，也能传输数据
/// </summary>
public class Mp3Player : IUsbDevice
{
    public void TransferData()
    {
        Console.WriteLine("MP3（播放设备）插到电脑上，传输数据");
    }

    /// <summary>
    /// MP3特有的播放音乐方法
    /// </summary>
    public void PlayMusic()
    {
        Console.WriteLine("MP3 播放音乐");
    }
}

/// <summary>
/// 电脑类：提供USB接口，实现传输数据的功能
/// </summary>
public class Computer
{
    /// <summary>
    /// 电脑的USB接口：接收任何实现IUsbDevice接口的设备，传输数据
    /// 多态核心：通过接口类型引用不同的设备对象
    /// </summary>
    /// <param name="device">实现IUsbDevice接口的设备</param>
    public void ConnectDevice(IUsbDevice device)
    {
        Console.WriteLine("电脑通过USB接口连接设备...");
        device.TransferData();
    }
}
#endregion

/// <summary>
/// 程序主入口类：统一管理测试逻辑
/// </summary>
public class Program
{
    #region 题目1测试方法
    public static void TestRegister()
    {
        Console.WriteLine("===== 题目1：登记功能测试 =====");
        // 多态：用接口类型引用不同的实现类对象
        IRegister person = new Person();
        IRegister car = new Car();
        IRegister house = new House();

        person.Register();
        car.Register();
        house.Register();
        Console.WriteLine();
    }
    #endregion

    #region 题目2测试方法
    public static void TestBirdAndHelicopter()
    {
        Console.WriteLine("===== 题目2：飞/走/游泳行为测试 =====");

        // 测试麻雀
        Sparrow sparrow = new Sparrow();
        sparrow.Walk();
        sparrow.Fly();

        // 测试鸵鸟
        Ostrich ostrich = new Ostrich();
        ostrich.Walk();

        // 测试企鹅
        Penguin penguin = new Penguin();
        penguin.Walk();
        penguin.Swim();

        // 测试鹦鹉
        Parrot parrot = new Parrot();
        parrot.Walk();
        parrot.Fly();

        // 测试天鹅
        Swan swan = new Swan();
        swan.Walk();
        swan.Fly();
        swan.Swim();

        // 测试直升机
        Helicopter helicopter = new Helicopter();
        helicopter.Fly();

        Console.WriteLine();
    }
    #endregion

    #region 题目3测试方法
    public static void TestUsbDevice()
    {
        Console.WriteLine("===== 题目3：USB设备数据传输测试 =====");
        // 创建电脑对象
        Computer computer = new Computer();

        // 多态：用接口类型引用不同的设备对象
        IUsbDevice mobileHardDisk = new MobileHardDisk();
        IUsbDevice uDisk = new UDisk();
        IUsbDevice mp3 = new Mp3Player();

        // 电脑通过USB接口连接不同设备，传输数据
        computer.ConnectDevice(mobileHardDisk);
        computer.ConnectDevice(uDisk);
        computer.ConnectDevice(mp3);

        // 测试MP3的特有方法
        Mp3Player mp3Player = new Mp3Player();
        mp3Player.PlayMusic();

        Console.WriteLine();
    }
    #endregion

    static void Main(string[] args)
    {
        // 执行所有测试
        TestRegister();
        TestBirdAndHelicopter();
        TestUsbDevice();

        // 暂停控制台，方便查看结果
        Console.WriteLine("按任意键退出...");
        Console.ReadKey();
    }
}