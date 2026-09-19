using System;

namespace 内部类和分部类
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("内部类和分部类");
            Console.WriteLine("------------------------");

            #region 知识点一 内部类 调用示例
            // 内部类调用：严格遵循「外部类.内部类」的访问规则
            Person person = new Person();
            person.age = 18;
            person.name = "张三";

            // 实例化一级内部类
            Person.Body personBody = new Person.Body();
            // 实例化嵌套内部类（需逐层访问）
            personBody.leftArm = new Person.Body.Arm();
            personBody.rightArm = new Person.Body.Arm();

            Console.WriteLine($"【内部类演示】姓名：{person.name}，年龄：{person.age}");
            Console.WriteLine($"【内部类演示】左手臂长度：{personBody.leftArm.length}米");
            #endregion

            Console.WriteLine("------------------------");

            #region 知识点二 分部类 & 分部方法 调用示例
            // 分部类实例化：虽分两部分，编译后是一个完整类
            Student student = new Student();
            student.name = "李四";
            student.sex = true;
            student.number = 2026001;

            // 修复核心：调用公共方法，内部触发私有分部方法（解决CS7036）
            student.CallPartialSpeak();
            // 调用带参数的普通方法：参数完整，无报错
            student.Speak("我是C#分部类的普通重载方法！");
            #endregion
        }
    }

    #region 知识点一 内部类
    //概念
    //在一个类中再申明一个类
    //特点
    //使用时要用包裹者点出自己
    //作用
    //亲密关系的变现
    //注意
    //访问修饰符作用很大
    class Person
    {
        public int age;
        public string name;
        public Body body;

        // 公共内部类：允许外部访问
        public class Body
        {
            // 公共嵌套内部类的对象
            public Arm leftArm;
            public Arm rightArm;

            // 公共嵌套内部类：需通过 Person.Body.Arm 访问
            public class Arm
            {
                // 内部类的属性
                public float length = 0.8f;
            }
        }
    }
    #endregion

    #region 知识点二 分部类
    //概念
    //把一个类分成几部分申明
    //关键字
    //partial
    //作用
    //分部描述一个类
    //增加程序的拓展性
    //注意
    //分部类可以写在多个脚本文件中
    //分部类的访问修饰符要一致
    //分部类中不能有重复成员

    // 分部类第一部分：声明基础属性 + 私有分部方法 + 公共调用方法
    partial class Student
    {
        public bool sex;
        public string name;
        public int number;

        // 分部方法声明：严格遵循「无访问修饰符、返回void、无out参数」
        partial void Speak();

        // 新增：公共方法，用于外部调用私有分部方法（核心修复点）
        public void CallPartialSpeak()
        {
            Speak(); // 内部调用私有分部方法，无参数匹配问题
        }
    }

    // 分部类第二部分：实现分部方法 + 普通重载方法
    partial class Student
    {
        // 分部方法实现：与声明签名完全一致
        partial void Speak()
        {
            string sexStr = sex ? "男" : "女";
            Console.WriteLine($"【分部方法】大家好，我是{sexStr}生{name}，学号{number}");
        }

        // 普通重载方法：带string参数，公共访问修饰符
        public void Speak(string str)
        {
            Console.WriteLine($"【普通方法】{str}");
        }
    }
    #endregion

    #region 知识点三 分部方法
    //概念
    //将方法的申明和实现分离
    //特点
    //1.不能加访问修饰符 默认私有
    //2.只能在分部类中申明
    //3.返回值只能是void
    //4.可以有参数但不用 out关键字
    //局限性大，了解即可
    #endregion
}