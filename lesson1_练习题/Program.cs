namespace lesson1_练习题
{
    // 定义一个空的GameObject类，用于模拟题目中的类
    public class GameObject { }

    class Program
    {
        static void Main()
        {
            // 第一题：
            // GameObject A = new GameObject();
            // GameObject B = A;
            // B = null;
            // A目前等于多少？

            // 代码执行：
            // 1. 在堆上创建一个新的GameObject对象，栈上的变量A指向这个对象
            GameObject A = new GameObject();
            // 2. 变量B也指向A所指向的同一个对象（A和B是同一个引用的副本）
            GameObject B = A;
            // 3. 将B的引用设置为null，即B不再指向任何对象
            B = null;

            // 回答：
            // A 仍然指向最初 new GameObject() 创建的那个对象实例，不为 null。
            // 因为 B = null 只是修改了 B 的引用，并没有影响 A 所指向的对象。
            Console.WriteLine($"A 是否为 null: {A == null}"); // 输出: False


            // 第二题：
            // GameObject A = new GameObject();
            // GameObject B = A;
            // B = new GameObject();
            // A和B有什么关系？

            // 代码执行：
            // 1. A 指向一个新的GameObject对象
            A = new GameObject();
            // 2. B 先和A指向同一个对象
            B = A;
            // 3. B 被重新赋值，指向一个全新的、独立的GameObject对象
            B = new GameObject();

            // 回答：
            // A 和 B 现在指向两个完全独立的 GameObject 对象实例。
            // 它们分别引用了内存中不同的对象，彼此之间没有引用关系。
            Console.WriteLine($"A 和 B 是否指向同一个对象: {ReferenceEquals(A, B)}"); // 输出: False
        }
    }
}
