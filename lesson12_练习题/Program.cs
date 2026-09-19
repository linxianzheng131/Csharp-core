using System;

namespace lesson12_练习题
{
    #region 题目1：写一个人类，人类中有姓名、年龄属性，有说话行为；战士类继承人类，有攻击行为
    // 题目原文：写一个人类，人类中有姓名，年龄属性，有说话行为；战士类继承人类，有攻击行为
    // 解题思路：
    // 1. 先定义父类Human，包含Name、Age属性和Speak()方法
    // 2. 定义子类Warrior继承Human，新增Attack()方法
    // 3. 通过base关键字调用父类构造函数初始化属性

    // 人类（父类）
    public class Human
    {
        // 属性：姓名、年龄
        public string Name { get; set; }
        public int Age { get; set; }      

        // 构造函数
        public Human(string name, int age)
        {
            Name = name;
            Age = age;
        }

        // 说话行为
        public void Speak()
        {
            Console.WriteLine($"{Name}（{Age}岁）正在说话");
        }
    }

    // 战士类（子类，继承人类）
    public class Warrior : Human
    {
        // 构造函数，通过base调用父类构造
        //声明一个变量 外部传入之后 优先给基类 
        //多了基类不需要的值传入时没影响 不用就行
        //但是不能少传入 因为基类的构造函数需要
        public Warrior(string name,int age,int a) : base(name, age)
        {

        }

        // 攻击行为（子类新增功能）
        public void Attack()
        {
            Console.WriteLine($"{Name}（{Age}岁）发起攻击！");
        }        
    }
    #endregion    

    class Program
    {
        public static void TestWarrior()
        {   
            // 测试代码
            Warrior warrior = new Warrior("张三", 25 ,1);
            warrior.Speak(); // 继承自人类的方法
            warrior.Attack(); // 战士类的专属的专属方法
        }
        static void Main(string[] args)
        {
            // 运行题目1的测试
            TestWarrior();
        }
    }
}
