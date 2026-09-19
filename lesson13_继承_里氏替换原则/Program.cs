using System;

namespace lesson13_继承_里氏替换原则
{
    class GameObject { }

    class Player : GameObject
    {
        public void PlayerAtk() => Console.WriteLine("玩家攻击");
    }

    class Monster : GameObject
    {
        public void MonsterAtk() => Console.WriteLine("怪物攻击");
    }

    class Boss : GameObject
    {
        public void BossAtk() => Console.WriteLine("BOSS攻击");
    }

    class Program
    {
        static void Main(string[] args)
        {
            #region 知识点一 基本概念
            // 里氏替换原则是面向对象七大原则中最重要的原则
            // 概念：
            // 任何父类出现的地方，子类都可以替代
            // 重点：
            // 语法表现—父类容器装子类对象，因为子类对象包含了父类的所有内容
            // 作用：
            // 方便进行对象存储和管理
            #endregion

            #region 知识点二 基本实现
            // 里氏替换原则 用父类容器 装载子类对象
            GameObject player = new Player();
            GameObject monster = new Monster();
            GameObject boss = new Boss();

            GameObject[] objects = new GameObject[] { new Player(), new Monster(), new Boss() };
            #endregion

            #region 知识点三 is和as
            // 基本概念
            // is：判断一个对象是否是执行类对象
            // 返回值：bool 是为真 不是为假
            // as：将一个对象转换为指定类对象
            // 返回值：指定类型对象 成功返回执行类型对象，失败返回null

            // 基本语法
            // 类对象 is 类名  该语句块 会有一个bool返回值 true和false
            // 类对象 as 类名  该语句块 会有一个对象返回值 对象和null

            // 遍历数组演示 is + as
            for (int i = 0; i < objects.Length; i++)
            {
                if (objects[i] is Player)
                {
                    (objects[i] as Player).PlayerAtk();
                }
                else if (objects[i] is Monster)
                {
                    (objects[i] as Monster).MonsterAtk();
                }
                else if (objects[i] is Boss)
                {
                    (objects[i] as Boss).BossAtk();
                }
            }

            // 更现代的写法（C# 7.0+ 模式匹配）
            // 一次性完成判断+转换，更简洁
            foreach (var obj in objects)
            {
                if (obj is Player p) p.PlayerAtk();
                else if (obj is Monster m) m.MonsterAtk();
                else if (obj is Boss b) b.BossAtk();
            }
            #endregion

            #region 总结注释
            // 总结
            // 概念：父类容器装子类对象（里氏替换原则核心体现）
            // 作用：方便进行对象的统一存储、管理与遍历（减少重复代码）
            // 
            // 使用：is 和 as 关键字配合完成类型判断与转换
            //   is 用于判断：检查对象是否兼容某个类型，返回 bool
            //   as 用于转换：安全地将对象转为指定类型，成功返回实例，失败返回 null
            // 
            // 重要注意：
            //   1. 可以用父类容器装子类对象（里氏替换）
            //   2. ❌ 不能直接用子类容器装父类对象（会编译/运行报错，必须强制转换）
            //   3. as 转换失败返回 null，避免强制转换( (类型)对象 )可能抛出的异常
            //   4. 子类是父类的扩展，所以子类包含父类全部成员，可向上兼容
            #endregion
        }
    }
}