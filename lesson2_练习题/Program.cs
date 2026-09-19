using System;

// 人类
class Person
{
    public string name; // 姓名
    public float height; // 身高
    public int age; // 年龄
    public string address; // 家庭住址
}

// 学生类
class Student
{
    public string name; // 姓名
    public string studentId; // 学号
    public int age; // 年龄
    public Student deskmate; // 同桌
    // 学习方法
    public void Study()
    {
        Console.WriteLine($"{name}正在学习");
    }
}

// 班级类
class Class
{
    public string majorName; // 专业名称
    public int teacherCapacity; // 教师容量
    public Student[] students; // 学生数组
}

class Program
{
    static void Main(string[] args)
    {
        #region 问题1
        // Person p = new Person();
        // p.age = 10;
        // Person p2 = new Person();
        // p2.age = 20;
        // 请问p.age为多少？

        Person p = new Person();
        p.age = 10;
        Person p2 = new Person();
        p2.age = 20;
        // 分析：p和p2是两个独立的Person对象，修改p2.age不会影响p.age
        // 答案：p.age = 10
        Console.WriteLine($"问题1：p.age = {p.age}");
        #endregion

        #region 问题2
        // Person p = new Person();
        // p.age = 10;
        // Person p2 = p;
        // p2.age = 20;
        // 请问p.age为多少？

        Person p3 = new Person();
        p3.age = 10;
        Person p4 = p3;
        p4.age = 20;
        // 分析：p4和p3指向同一个对象，修改p4.age会同步修改p3.age
        // 答案：p.age = 20
        Console.WriteLine($"问题2：p.age = {p3.age}");
        #endregion

        #region 问题3
        // Student s = new Student();
        // s.age = 10;
        // int age = s.age;
        // age = 20;
        // 请问s.age为多少？

        Student s = new Student();
        s.age = 10;
        int age = s.age;
        age = 20;
        // 分析：age是值类型变量，赋值时是复制值，修改age不会影响s.age
        // 答案：s.age = 10
        Console.WriteLine($"问题3：s.age = {s.age}");
        #endregion

        #region 问题4
        // Student s = new Student();
        // s.deskmate = new Student();
        // s.deskmate.age = 10;
        // Student s2 = s.deskmate;
        // s2.age = 20;
        // 请问s.deskmate.age为多少？

        Student s4 = new Student();
        s4.deskmate = new Student();
        s4.deskmate.age = 10;
        Student s2 = s4.deskmate;
        s2.age = 20;
        // 分析：s2和s.deskmate指向同一个对象，修改s2.age会同步修改s.deskmate.age
        // 答案：s.deskmate.age = 20
        Console.WriteLine($"问题4：s.deskmate.age = {s4.deskmate.age}");
        #endregion
    }
}