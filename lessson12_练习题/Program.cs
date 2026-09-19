using System;

namespace 继承练习题_人类与战士
{
    #region 练习题：写一个人类，人类中有姓名，年龄属性，有说话行为；战士类继承人类，有攻击行为
    // 解题思路注释：
    // 1. 先定义父类「人类（Person）」，封装核心属性（姓名、年龄）和基础行为（说话）
    // 2. 再定义子类「战士（Warrior）」，通过继承语法（: Person）获取父类的属性和方法
    // 3. 在子类中扩展专属行为「攻击」，同时可复用父类的姓名属性实现个性化输出

    // 父类：人类
    public class Person
    {
        // 姓名属性
        public string Name { get; set; }
        // 年龄属性
        public int Age { get; set; }

        // 说话行为方法
        public void Speak()
        {
            Console.WriteLine($"大家好，我叫{Name}，今年{Age}岁。");
        }
    }

    // 子类：战士（继承自人类）
    public class Warrior : Person
    {
        // 战士专属攻击行为方法
        public void Attack()
        {
            Console.WriteLine($"{Name}举起武器，发起冲锋攻击！");
        }
    }

    // 程序入口
    class Program
    {
        static void Main(string[] args)
        {
            // 实例化人类对象并调用方法
            Person person = new Person();
            person.Name = "张三";
            person.Age = 25;
            person.Speak();

            // 实例化战士对象，复用父类属性并调用专属方法
            Warrior warrior = new Warrior();
            warrior.Name = "李将军";
            warrior.Age = 30;
            warrior.Speak();    // 调用继承自人类的说话方法
            warrior.Attack();   // 调用战士专属的攻击方法

            // 阻止控制台立即关闭
            Console.ReadLine();
        }
    }
    #endregion
}