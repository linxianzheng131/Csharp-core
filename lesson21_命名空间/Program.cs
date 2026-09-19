using System;

#region 题目1：说明C#中using关键字的作用
/*
 * C#中using关键字有5种核心作用，按使用场景分类如下：
 * 
 * 1. 【引用命名空间】（最常用）
 *    语法：using 命名空间名;
 *    作用：引入指定命名空间，让代码中可以直接使用该命名空间下的类型，无需写完整限定名
 *    示例：using System;  后续可直接写Console.WriteLine()，不用System.Console.WriteLine()
 * 
 * 2. 【using语句：资源自动释放】（IDisposable接口核心用法）
 *    语法：using (资源对象) { 代码块 }
 *    作用：确保实现了IDisposable接口的对象（如文件流、数据库连接）在代码块结束后自动调用Dispose()释放资源
 *         即使代码块中发生异常，也能保证资源被释放，避免内存泄漏
 *    示例：
 *    using (FileStream fs = new FileStream("test.txt", FileMode.Open))
 *    {
 *        // 操作文件流，结束后自动释放
 *    }
 * 
 * 3. 【using别名：解决命名冲突】
 *    语法：using 别名 = 命名空间或类型;
 *    作用：为命名空间/类型创建别名，解决不同命名空间下同名类型的冲突问题
 *    注意：必须放在文件顶部、命名空间外部，禁止在类/方法内部定义
 *    示例：using MyImage = UI.Image;  后续用MyImage代表UI命名空间下的Image类
 * 
 * 4. 【using static：直接引用静态成员】（C# 6+ 特性）
 *   语法：using static 类型名;
 *    作用：直接引入类型的静态成员，使用时无需写类型名
 *    示例：using static System.Console;  后续可直接写WriteLine()，不用Console.WriteLine()
 * 
 * 5. 【全局using】（C# 10+ 特性）
 *    语法：global using 命名空间名;
 *    作用：在项目中全局引用命名空间，无需在每个文件中重复写using
 */
#endregion

#region 题目2：两个命名空间下同名Image类的实例化实现（语法完全正确版）
// ====================== 关键修复：using别名必须放在文件顶部、命名空间外部 ======================
// 为两个同名Image类定义别名，解决命名冲突
using UIImage = UI.Image;
using GraphImage = Graph.Image;

// 1. 定义UI命名空间，包含Image类
namespace UI
{
    /// <summary>
    /// UI命名空间下的Image类：代表用户界面中的图像控件
    /// </summary>
    public class Image
    {
        /// <summary>
        /// 构造函数：初始化UI.Image对象
        /// </summary>
        public Image()
        {
            Console.WriteLine("已实例化 UI 命名空间下的 Image 对象（用户界面图像）");
        }

        /// <summary>
        /// 示例方法：显示UI图像
        /// </summary>
        public void Show()
        {
            Console.WriteLine("UI.Image 显示界面图像");
        }
    }
}

// 2. 定义Graph命名空间，包含同名Image类
namespace Graph
{
    /// <summary>
    /// Graph命名空间下的Image类：代表图表中的图像元素
    /// </summary>
    public class Image
    {
        /// <summary>
        /// 构造函数：初始化Graph.Image对象
        /// </summary>
        public Image()
        {
            Console.WriteLine("已实例化 Graph 命名空间下的 Image 对象（图表图像）");
        }

        /// <summary>
        /// 示例方法：绘制图表图像
        /// </summary>
        public void Draw()
        {
            Console.WriteLine("Graph.Image 绘制图表图像");
        }
    }
}

// 3. 主程序类，在Main方法中实例化两个不同命名空间的Image对象
internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("===== 实例化不同命名空间的Image对象 =====");

        // --------------------------
        // 方式1：使用完整限定名实例化（无需别名，最直观，无语法风险）
        // --------------------------
        Console.WriteLine("\n【方式1：完整限定名】");
        // 实例化UI命名空间下的Image
        UI.Image uiImage1 = new UI.Image();
        uiImage1.Show();

        // 实例化Graph命名空间下的Image
        Graph.Image graphImage1 = new Graph.Image();
        graphImage1.Draw();

        // --------------------------
        // 方式2：使用using别名实例化（代码更简洁，适合频繁使用）
        // --------------------------
        Console.WriteLine("\n【方式2：using别名】");
        // 实例化UI命名空间下的Image（通过别名UIImage）
        UIImage uiImage2 = new UIImage();
        uiImage2.Show();

        // 实例化Graph命名空间下的Image（通过别名GraphImage）
        GraphImage graphImage2 = new GraphImage();
        graphImage2.Draw();

        // 暂停控制台，方便查看结果
        Console.WriteLine("\n按任意键退出...");
        Console.ReadKey();
    }
}
#endregion