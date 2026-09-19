using System;

namespace StudentClassExercise
{
    #region 题目：定义一个学生类，有五种属性，分别为姓名、性别、年龄、CSharp成绩、Unity成绩
    // 有两个方法：
    // 一个打招呼：介绍自己交XX，今年几岁了。是男同学还是女同学
    // 计算自己总分数和平均分并显示的方法
    // 使用属性完成：年龄必须是0~150岁之间，成绩必须是0~100
    // 性别只能是男或女
    // 实例化两个对象并测试
    #endregion

    class Student
    {
        #region 私有成员变量
        private string name;
        private string gender;
        private int age;
        private float cSharpScore;
        private float unityScore;
        #endregion

        #region 姓名属性
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        #endregion

        #region 性别属性（只能是男或女）
        public string Gender
        {
            get { return gender; }
            set
            {
                if (value == "男" || value == "女")
                {
                    gender = value;
                }
                else
                {
                    Console.WriteLine("性别输入错误，只能是'男'或'女'！");
                    gender = "未知";
                }
            }
        }
        #endregion

        #region 年龄属性（0~150岁之间）
        public int Age
        {
            get { return age; }
            set
            {
                if (value >= 0 && value <= 150)
                {
                    age = value;
                }
                else
                {
                    Console.WriteLine("年龄输入错误，必须在0~150之间！");
                    age = 0;
                }
            }
        }
        #endregion

        #region CSharp成绩属性（0~100之间）
        public float CSharpScore
        {
            get { return cSharpScore; }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    cSharpScore = value;
                }
                else
                {
                    Console.WriteLine("CSharp成绩输入错误，必须在0~100之间！");
                    cSharpScore = 0;
                }
            }
        }
        #endregion

        #region Unity成绩属性（0~100之间）
        public float UnityScore
        {
            get { return unityScore; }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    unityScore = value;
                }
                else
                {
                    Console.WriteLine("Unity成绩输入错误，必须在0~100之间！");
                    unityScore = 0;
                }
            }
        }
        #endregion

        #region 打招呼方法：介绍自己
        public void Greet()
        {
            Console.WriteLine($"大家好，我叫{Name}，今年{Age}岁了，是{Gender}同学。");
        }
        #endregion

        #region 计算总分和平均分并显示
        public void ShowScoreInfo()
        {
            float total = CSharpScore + UnityScore;
            float avg = total / 2;
            Console.WriteLine($"我的总分是：{total}，平均分是：{avg}");
        }
        #endregion
    }

    class Program
    {
        static void Main(string[] args)
        {
            #region 实例化第一个学生对象并测试
            Student stu1 = new Student();
            stu1.Name = "张三";
            stu1.Gender = "男";
            stu1.Age = 20;
            stu1.CSharpScore = 95.5f;
            stu1.UnityScore = 88.0f;

            stu1.Greet();
            stu1.ShowScoreInfo();
            Console.WriteLine("------------------------");
            #endregion

            #region 实例化第二个学生对象并测试
            Student stu2 = new Student();
            stu2.Name = "李四";
            stu2.Gender = "女";
            stu2.Age = 18;
            stu2.CSharpScore = 92.0f;
            stu2.UnityScore = 90.5f;

            stu2.Greet();
            stu2.ShowScoreInfo();
            #endregion
        }
    }
}