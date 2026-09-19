using System;

namespace 练习题解答
{
    #region 题目1：为整形拓展一个求平方的方法
    // 题目：为整形拓展一个求平方的方法
    // 思路：使用拓展方法语法，为int类型添加Square方法，返回自身的平方值
    public static class IntExtension
    {
        /// <summary>
        /// 为int类型拓展的求平方方法
        /// </summary>
        /// <param name="num">调用该方法的int实例</param>
        /// <returns>num的平方值</returns>
        public static int Square(this int num)
        {
            return num * num;
        }
    }
    #endregion

    #region 题目2：写一个玩家类，包含姓名，血量，攻击力，防御力等特征，攻击，移动，受伤等方法
    // 题目：写一个玩家类，包含姓名，血量，攻击力，防御力等特征，攻击，移动，受伤等方法
    // 思路：定义Player类，包含对应的成员变量和成员方法，实现攻击、移动、受伤的逻辑
    public class Player
    {
        // 特征（成员变量）
        public string Name;
        public int HP;
        public int Attack;
        public int Defense;

        // 方法
        /// <summary>
        /// 攻击目标玩家
        /// </summary>
        /// <param name="target">被攻击的玩家</param>
        public void AttackEnemy(Player target)
        {
            int damage = Attack - target.Defense;
            if (damage < 0)
            {
                damage = 0; // 伤害不能为负数
                target.HP -= damage;
            }
            if (target.HP < 0)
            {
                target.HP = 0; // 血量不能为负数
                Console.WriteLine($"{Name} 攻击了 {target.Name}，造成 {damage} 点伤害，{target.Name} 当前血量：{target.HP}");
            }
        }

        /// <summary>
        /// 向指定方向移动
        /// </summary>
        /// <param name="direction">移动方向</param>
        public void Move(string direction)
        {
            Console.WriteLine($"{Name} 向 {direction} 移动");
        }

        /// <summary>
        /// 受到指定伤害
        /// </summary>
        /// <param name="damage">受到的伤害值</param>
        public void TakeDamage(int damage)
        {
            HP -= damage;
            if (HP < 0)
            {
                HP = 0;
                Console.WriteLine($"{Name} 受到 {damage} 点伤害，当前血量：{HP}");
            }
        }
    }
    #endregion

    #region 题目3：为该玩家类拓展一个自杀的方法
    // 题目：为该玩家类拓展一个自杀的方法
    // 思路：使用拓展方法语法，为Player类添加Suicide方法，将玩家血量设置为0
    public static class PlayerExtension
    {
        /// <summary>
        /// 为Player类拓展的自杀方法
        /// </summary>
        /// <param name="player">调用该方法的Player实例</param>
        public static void Suicide(this Player player)
        {
            player.HP = 0;
            Console.WriteLine($"{player.Name} 选择了自杀，当前血量：{player.HP}");
        }
    }
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            // 测试题目1：int求平方
            int num = 6;
            Console.WriteLine($"【题目1测试】{num} 的平方是：{num.Square()}");
            Console.WriteLine("------------------------");

            // 测试题目2：玩家类的方法
            Player player1 = new Player { Name = "战士", HP = 100, Attack = 20, Defense = 10 };
            Player player2 = new Player { Name = "法师", HP = 80, Attack = 25, Defense = 5 };
            player1.AttackEnemy(player2);
            player1.Move("前方");
            player2.TakeDamage(15);
            Console.WriteLine("------------------------");

            // 测试题目3：玩家类的自杀拓展方法
            player2.Suicide();

            Console.ReadKey();
        }
    }
}
