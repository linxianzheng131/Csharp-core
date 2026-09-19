using System;

// 统一命名空间，符合C#项目规范
namespace GameDemo
{
    #region 题目1：is和as的区别是什么 + 怪物类继承练习
    /*
    题目：
    is和as的区别是什么
    写一个Monster类，它派生出Boss和Goblin两个类，Boss有技能；小怪有攻击；
    随机生成10个怪，装载到数组中，遍历这个数组，调用他们的攻击方法，如果是boss就释放技能
    */

    // ------------------------------
    // 1. is 和 as 的核心区别（注释说明）
    // ------------------------------
    /*
    is 关键字：
    - 作用：类型检查，判断对象是否为指定类型（或派生类型）
    - 返回值：bool（true/false），不会进行转换，仅做判断
    - 特点：转换失败不会抛出异常，直接返回false
    - 适用场景：仅需要判断类型，不需要使用转换后的对象

    as 关键字：
    - 作用：类型转换，将对象转换为指定类型（或派生类型）
    - 返回值：转换成功返回目标类型对象，失败返回null（引用类型）/ 抛出异常（值类型）
    - 特点：转换失败不会抛出异常，返回null，需要判空后使用
    - 适用场景：需要转换类型并使用对象，且希望用null处理失败场景

    核心区别总结：
    | 特性         | is                  | as                  |
    |--------------|---------------------|---------------------|
    | 功能         | 类型检查            | 类型转换            |
    | 返回值       | bool                | 目标类型对象/null   |
    | 异常         | 无                  | 无（引用类型）      |
    | 使用场景     | 仅判断类型          | 转换后使用对象      |
    */

    // 父类：Monster
    public class Monster
    {
        // 通用攻击方法
        public virtual void Attack()
        {
            Console.WriteLine("怪物进行攻击！");
        }
    }

    // 子类：Boss（继承Monster）
    public class Boss : Monster
    {
        // 重写父类攻击方法
        public override void Attack()
        {
            Console.WriteLine("Boss发动强力攻击！");
        }

        // Boss专属技能方法
        public void UseSkill()
        {
            Console.WriteLine("Boss释放专属技能！");
        }
    }

    // 子类：Goblin（小怪，继承Monster）
    public class Goblin : Monster
    {
        // 重写父类攻击方法
        public override void Attack()
        {
            Console.WriteLine("哥布林发动普通攻击！");
        }
    }

    // 怪物测试类
    public static class MonsterTest
    {
        public static void Run()
        {
            // 随机数生成器
            Random random = new Random();
            // 怪物数组，长度10
            Monster[] monsters = new Monster[10];

            // 随机生成10个怪物（Boss/Goblin各50%概率）
            for (int i = 0; i < monsters.Length; i++)
            {
                if (random.Next(2) == 0)
                {
                    monsters[i] = new Boss();
                }
                else
                {
                    monsters[i] = new Goblin();
                }
            }

            // 遍历数组，调用攻击方法，Boss额外释放技能
            foreach (Monster monster in monsters)
            {
                // 统一调用攻击方法（多态）
                monster.Attack();

                // 方式1：用is判断类型，再强制转换（C# 7+ 模式匹配写法）
                if (monster is Boss boss)
                {
                    boss.UseSkill();
                }

                // 方式2：用as转换，再判空（兼容旧版本写法，二选一即可）
                // Boss boss = monster as Boss;
                // if (boss != null)
                // {
                //     boss.UseSkill();
                // }

                Console.WriteLine("-------------------");
            }
        }
    }
    #endregion

    #region 题目2：FPS游戏模拟（玩家+武器类）
    /*
    题目：
    FPS游戏模拟
    写一个玩家类，玩家可以拥有各种武器
    现在有四种武器，冲锋枪，散弹枪，手枪，匕首
    玩家默认拥有匕首
    请在玩家类中写一个方法，可以拾取不同的武器替换自己拥有的枪械
    */

    // 武器抽象父类（统一武器行为）
    public abstract class Weapon
    {
        // 武器名称
        public string WeaponName;

        // 抽象攻击方法，子类必须实现
        public abstract void Attack();
    }

    // 子类：冲锋枪
    public class SubmachineGun : Weapon
    {
        public SubmachineGun()
        {
            WeaponName = "冲锋枪";
        }

        public override void Attack()
        {
            Console.WriteLine("使用冲锋枪进行连续射击！");
        }
    }

    // 子类：散弹枪
    public class Shotgun : Weapon
    {
        public Shotgun()
        {
            WeaponName = "散弹枪";
        }

        public override void Attack()
        {
            Console.WriteLine("使用散弹枪进行范围射击！");
        }
    }

    // 子类：手枪
    public class Pistol : Weapon
    {
        public Pistol()
        {
            WeaponName = "手枪";
        }

        public override void Attack()
        {
            Console.WriteLine("使用手枪进行精准射击！");
        }
    }

    // 子类：匕首（默认武器）
    public class Dagger : Weapon
    {
        public Dagger()
        {
            WeaponName = "匕首";
        }

        public override void Attack()
        {
            Console.WriteLine("使用匕首进行近战攻击！");
        }
    }

    // 玩家类
    public class Player
    {
        // 当前持有的武器（默认初始化匕首）
        private Weapon currentWeapon;

        // 构造函数：默认拥有匕首
        public Player()
        {
            currentWeapon = new Dagger();
            Console.WriteLine($"玩家初始化，默认武器：{currentWeapon.WeaponName}");
        }

        // 拾取武器方法：替换当前武器
        public void PickUpWeapon(Weapon newWeapon)
        {
            // 判空处理
            if (newWeapon == null)
            {
                Console.WriteLine("拾取的武器无效！");
                return;
            }

            // 替换当前武器
            currentWeapon = newWeapon;
            Console.WriteLine($"玩家拾取新武器：{currentWeapon.WeaponName}，已替换当前武器！");
        }

        // 攻击方法：使用当前武器攻击
        public void Attack()
        {
            Console.Write("玩家攻击：");
            currentWeapon.Attack();
        }

        // 获取当前武器名称（可选）
        public string GetCurrentWeaponName()
        {
            return currentWeapon.WeaponName;
        }
    }

    // FPS游戏测试类
    public static class FPSTest
    {
        public static void Run()
        {
            // 创建玩家
            Player player = new Player();
            Console.WriteLine("-------------------");

            // 初始攻击（匕首）
            player.Attack();
            Console.WriteLine("-------------------");

            // 拾取冲锋枪
            player.PickUpWeapon(new SubmachineGun());
            player.Attack();
            Console.WriteLine("-------------------");

            // 拾取散弹枪
            player.PickUpWeapon(new Shotgun());
            player.Attack();
            Console.WriteLine("-------------------");

            // 拾取手枪
            player.PickUpWeapon(new Pistol());
            player.Attack();
            Console.WriteLine("-------------------");

            // 切回匕首
            player.PickUpWeapon(new Dagger());
            player.Attack();
        }
    }
    #endregion

    // 程序入口类
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== 题目1：怪物类测试 =====");
            MonsterTest.Run();

            Console.WriteLine("\n===== 题目2：FPS游戏测试 =====");
            FPSTest.Run();

            // 暂停控制台，方便查看结果
            Console.ReadLine();
        }
    }
}