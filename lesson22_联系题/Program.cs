using System;
using System.Collections.Generic;

#region 题目1：玩家类实现 + 控制台打印指定格式信息
/// <summary>
/// 玩家类：包含姓名、血量、攻击力、防御力、闪避率等特征
/// </summary>
public class Player
{
    // 玩家属性（封装：私有字段 + 公共属性，保证数据安全）
    private string _name;
    private int _hp;
    private int _attack;
    private int _defense;
    private float _dodgeRate; // 闪避率（0-1之间的浮点数）

    /// <summary>
    /// 玩家类构造函数：初始化玩家所有属性
    /// </summary>
    /// <param name="name">姓名</param>
    /// <param name="hp">血量</param>
    /// <param name="attack">攻击力</param>
    /// <param name="defense">防御力</param>
    /// <param name="dodgeRate">闪避率</param>
    public Player(string name, int hp, int attack, int defense, float dodgeRate)
    {
        // 参数合法性校验
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("玩家姓名不能为空！");
        if (hp < 0) throw new ArgumentOutOfRangeException(nameof(hp), "血量不能为负数！");
        if (attack < 0) throw new ArgumentOutOfRangeException(nameof(attack), "攻击力不能为负数！");
        if (defense < 0) throw new ArgumentOutOfRangeException(nameof(defense), "防御力不能为负数！");
        if (dodgeRate < 0 || dodgeRate > 1)
            throw new ArgumentOutOfRangeException(nameof(dodgeRate), "闪避率必须在0-1之间！");

        _name = name;
        _hp = hp;
        _attack = attack;
        _defense = defense;
        _dodgeRate = dodgeRate;
    }

    /// <summary>
    /// 重写ToString方法：按照题目要求的格式打印玩家信息
    /// 格式：玩家XX，血量XX，攻击力XX，防御力XX
    /// </summary>
    /// <returns>格式化后的玩家信息字符串</returns>
    public override string ToString()
    {
        return $"玩家{_name}，血量{_hp}，攻击力{_attack}，防御力{_defense}";
    }

    // 可选：为属性提供公共访问器，方便外部读取/修改（如需严格控制可添加set逻辑）
    public string Name => _name;
    public int Hp => _hp;
    public int Attack => _attack;
    public int Defense => _defense;
    public float DodgeRate => _dodgeRate;
}
#endregion

#region 题目2：Monster类深拷贝实现（修改B不影响A）
/// <summary>
/// Monster类：包含攻击力、防御力、血量、技能ID等属性
/// 实现ICloneable接口，支持深拷贝，确保修改副本不影响原对象
/// </summary>
public class Monster : ICloneable
{
    // Monster属性（包含值类型和引用类型，确保深拷贝完全独立）
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int Hp { get; set; }
    public List<int> SkillIds { get; set; } // 技能ID列表（引用类型，深拷贝需单独处理）

    /// <summary>
    /// Monster类构造函数：初始化怪物属性
    /// </summary>
    /// <param name="attack">攻击力</param>
    /// <param name="defense">防御力</param>
    /// <param name="hp">血量</param>
    /// <param name="skillIds">技能ID列表</param>
    public Monster(int attack, int defense, int hp, List<int> skillIds)
    {
        Attack = attack;
        Defense = defense;
        Hp = hp;
        // 初始化时深拷贝技能列表，避免外部引用修改内部数据
        SkillIds = new List<int>(skillIds);
    }

    /// <summary>
    /// 实现ICloneable接口的Clone方法：深拷贝Monster对象
    /// 深拷贝：不仅复制对象本身，还复制所有引用类型成员，确保副本与原对象完全独立
    /// </summary>
    /// <returns>深拷贝后的新Monster对象</returns>
    public object Clone()
    {
        // 1. 复制值类型属性（自动完成）
        Monster clone = (Monster)this.MemberwiseClone();
        // 2. 深拷贝引用类型属性（技能列表），创建新的列表对象，避免共享引用
        clone.SkillIds = new List<int>(this.SkillIds);
        return clone;
    }

    /// <summary>
    /// 提供强类型的Clone方法，更方便使用（避免强制类型转换）
    /// </summary>
    /// <returns>深拷贝后的Monster对象</returns>
    public Monster DeepClone()
    {
        return (Monster)Clone();
    }

    /// <summary>
    /// 重写ToString方法，方便打印怪物信息
    /// </summary>
    public override string ToString()
    {
        return $"攻击力:{Attack}, 防御力:{Defense}, 血量:{Hp}, 技能ID:[{string.Join(",", SkillIds)}]";
    }
}
#endregion

/// <summary>
/// 程序主入口类：测试所有功能
/// </summary>
internal class Program
{
    static void Main(string[] args)
    {
        #region 题目1测试：玩家类打印
        Console.WriteLine("===== 题目1：玩家信息打印 =====");
        // 实例化玩家对象
        Player player = new Player("亚瑟", 1500, 80, 40, 0.15f);
        // 按照题目要求打印信息（调用重写的ToString方法）
        Console.WriteLine(player.ToString());
        Console.WriteLine();
        #endregion

        #region 题目2测试：Monster深拷贝（修改B不影响A）
        Console.WriteLine("===== 题目2：Monster深拷贝测试 =====");
        // 1. 创建原对象A
        List<int> skillIdsA = new List<int> { 1001, 1002, 1003 };
        Monster monsterA = new Monster(100, 30, 800, skillIdsA);
        Console.WriteLine($"原对象A：{monsterA}");

        // 2. 深拷贝A得到对象B（完全独立，修改B不影响A）
        Monster monsterB = monsterA.DeepClone();
        Console.WriteLine($"拷贝对象B：{monsterB}");

        // 3. 修改B的属性（包括值类型和引用类型）
        monsterB.Attack = 150;
        monsterB.Defense = 50;
        monsterB.Hp = 1000;
        monsterB.SkillIds.Add(1004); // 修改引用类型成员
        Console.WriteLine("\n修改B的属性后：");
        Console.WriteLine($"原对象A：{monsterA}"); // A完全不受影响
        Console.WriteLine($"修改后B：{monsterB}");

        // 暂停控制台，方便查看结果
        Console.WriteLine("\n按任意键退出...");
        Console.ReadKey();
        #endregion
    }
}