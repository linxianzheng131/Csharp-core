namespace lesson3_练习题
{
    using System;
    #region 第一题：为人类定义说话、走路、吃饭等方法
    /*
    题目：基于成员变量练习题
    为人类定义说话、走路、吃饭等方法
    */
    public class Human
    {
        // 成员变量
        public string Name { get; set; }
        public int Age { get; set; }
        // 构造函数
        public Human(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public Human(string name)
        {
            Name=name;
        }
        // 说话方法
        public void Speak(string message)
        {
            Console.WriteLine($"{Name}说：{message}");
        }
        // 走路方法
        public void Walk(int steps)
        {
            Console.WriteLine($"{Name}走了{steps}步");
        }
        // 吃饭方法
        public void Eat(Food food)
        {
            Console.WriteLine($"{Name}正在吃{food.Name}，摄入热量{food.Calories}千卡");
        }
    }
    #endregion

    #region 第二题：为学生类定义学习、吃饭等方法
    /*
    题目：基于成员变量练习题
    为学生类定义学习、吃饭等方法
    */
    public class Student : Human
    {
        public string StudentId { get; set; }
        public string Major { get; set; }
        public Student(string name, int age, string studentId, string major)
            : base(name, age)
        {
            StudentId = studentId;
            Major = major;
        }
        // 学习方法
        public void Study(int hours)
        {
            Console.WriteLine($"{Name}（学号：{StudentId}）在{Major}专业学习了{hours}小时");
        }
        // 重写吃饭方法，体现学生特点
        public new void Eat(Food food)
        {
            Console.WriteLine($"{Name}（学生）在食堂吃了{food.Name}，补充能量继续学习");
        }
    }
    #endregion

    #region 第三题：定义食物类并思考与人类、学生类的联系
    /*
    题目：定义一个食物类，有名称，热量等特征
    思考如何和人类以及学生类联系起来
    */
    public class Food
    {
        public string Name { get; set; }
        public int Calories { get; set; } // 热量（千卡）
        public string Taste { get; set; } // 口味
        public Food(string name, int calories, string taste)
        {
            Name = name;
            Calories = calories;
            Taste = taste;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"食物：{Name}，热量：{Calories}千卡，口味：{Taste}");
        }
    }
    /*
    思考与人类、学生类的联系：
    1. 组合关系：人类和学生类中可以包含食物类的对象（如Eat方法参数为Food）
    2. 依赖关系：人类和学生的Eat方法依赖于Food类提供的信息
    3. 继承关系：可以进一步定义具体食物子类（如Fruit、Meat）继承自Food类
    */
    #endregion

    #region 测试代码
    class Program
    {
        static void Main(string[] args)
        {
            // 测试第一题：人类类
            Human human = new Human("张三", 30);
            human.Speak("你好，世界！");
            human.Walk(100);
            // 测试第三题：食物类
            Food rice = new Food("米饭", 130, "清淡");
            rice.ShowInfo();
            human.Eat(rice);
            Console.WriteLine("------------------------");
            // 测试第二题：学生类
            Student student = new Student("李四", 20, "2023001", "计算机科学");
            student.Study(3);
            student.Speak("我要努力学习！");
            student.Walk(50);
            student.Eat(new Food("汉堡", 550, "香辣"));
        }
    }
    #endregion
}
