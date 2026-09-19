using System;

// ==============================================
// 【核心知识点：多个脚本文件】
// 知识点说明：
// 1. C#项目中一个功能模块对应一个.cs脚本文件，实现代码拆分管理
// 2. 多个脚本文件通过【命名空间】关联，通过【访问修饰符】控制跨文件访问
// 3. 编译时编译器会自动合并所有.cs文件，生成统一程序集
// 4. 核心价值：代码解耦、便于维护、团队协作、复用性强
// ==============================================

#region 脚本文件1：Student.cs（学生类脚本 - 模拟单独的脚本文件）
// 模拟：新建名为 Student.cs 的脚本文件，仅存放学生相关代码
namespace MultiScriptDemo // 命名空间：统一管理当前脚本文件的类，避免命名冲突
{
    /// <summary>
    /// 学生类（对应独立脚本文件：Student.cs）
    /// 多个脚本文件的核心：按功能拆分，每个文件专注实现单一类型
    /// </summary>
    public class Student // public：跨脚本文件访问的必要修饰符（internal仅同项目可访问）
    {
        // 私有字段：封装数据，仅当前脚本文件内可访问（private）
        private string _studentId;
        private string _studentName;

        // 构造函数：初始化学生对象，是脚本文件中类的核心初始化逻辑
        public Student(string studentId, string studentName)
        {
            _studentId = studentId;
            _studentName = studentName;
        }

        // 公开属性：提供跨脚本文件访问私有字段的安全接口
        public string StudentId => _studentId;
        public string StudentName => _studentName;

        // 实例方法：学生的行为，封装在专属脚本文件中
        public void Study()
        {
            Console.WriteLine($"【{_studentName}】正在学习，学号：{_studentId}");
        }
    }
}
#endregion

#region 脚本文件2：Teacher.cs（教师类脚本 - 模拟单独的脚本文件）
// 模拟：新建名为 Teacher.cs 的脚本文件，仅存放教师相关代码
namespace MultiScriptDemo // 与Student.cs同命名空间，实现跨文件类调用
{
    /// <summary>
    /// 教师类（对应独立脚本文件：Teacher.cs）
    /// 多个脚本文件的关联：同命名空间下，可直接调用其他脚本文件的类
    /// </summary>
    public class Teacher
    {
        private string _teacherId;
        private string _teacherName;

        public Teacher(string teacherId, string teacherName)
        {
            _teacherId = teacherId;
            _teacherName = teacherName;
        }

        // 教师核心行为：授课（可调用其他脚本文件的Student类）
        public void Teach(Student student)
        {
            Console.WriteLine($"【{_teacherName}】老师正在指导【{student.StudentName}】学习");
            // 跨脚本文件调用：在Teacher脚本中使用Student脚本定义的类
            student.Study();
        }
    }
}
#endregion

#region 脚本文件3：SchoolHelper.cs（工具类脚本 - 模拟单独的脚本文件）
// 模拟：新建名为 SchoolHelper.cs 的脚本文件，存放通用工具逻辑
namespace MultiScriptDemo
{
    /// <summary>
    /// 校园工具类（对应独立脚本文件：SchoolHelper.cs）
    /// 多个脚本文件的复用：工具类脚本可被多个其他脚本文件调用
    /// </summary>
    public static class SchoolHelper // 静态类：无需实例化，直接通过类名调用，适合工具脚本
    {
        /// <summary>
        /// 静态方法：打印校园欢迎语（通用工具逻辑，可被任意脚本文件调用）
        /// </summary>
        public static void PrintSchoolWelcome()
        {
            Console.WriteLine("===== 欢迎进入校园管理系统 =====");
            Console.WriteLine("当前支持：学生管理、教师授课功能");
            Console.WriteLine("================================\n");
        }

        /// <summary>
        /// 静态方法：计算学生学习时长（模拟业务工具逻辑）
        /// </summary>
        /// <param name="hours">学习小时数</param>
        public static void CalculateStudyTime(int hours)
        {
            Console.WriteLine($"学生今日学习时长：{hours}小时，累计进步！");
        }
    }
}
#endregion

#region 主程序脚本：Program.cs（程序入口脚本 - 模拟主脚本文件）
// 模拟：主脚本文件 Program.cs，作为程序入口，调用其他脚本文件的类
namespace MultiScriptDemo
{
    class Program
    {
        // C#程序唯一入口，所有脚本文件的逻辑都通过入口执行
        static void Main(string[] args)
        {
            // 1. 调用工具类脚本（SchoolHelper.cs）的静态方法
            SchoolHelper.PrintSchoolWelcome();

            // 2. 调用学生类脚本（Student.cs）创建对象
            Student student = new Student("2024001", "张三");

            // 3. 调用教师类脚本（Teacher.cs）创建对象，并调用跨文件方法
            Teacher teacher = new Teacher("T001", "李老师");
            teacher.Teach(student);

            Console.WriteLine("\n");

            // 4. 再次调用工具类脚本的其他方法
            SchoolHelper.CalculateStudyTime(3);

            // 防止程序退出
            Console.WriteLine("\n按任意键退出程序...");
            Console.ReadKey();
        }
    }
}
#endregion