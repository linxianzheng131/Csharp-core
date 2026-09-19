using System.Numerics;

namespace 其他
{
    public class Position
    {
        public int x;
        public int y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            #region ReferenceEquals 完整演示（判断引用是否相同）
            // 题目：理解 ReferenceEquals 作用：判断两个对象是否是同一个实例
            Position p1 = new Position(5, 5);
            Position p2 = p1;          // 和 p1 指向同一个对象
            Position p3 = new Position(5, 5); // 内容一样，但新对象

            // 1. 判断是否为同一个对象
            bool sameRef = ReferenceEquals(p1, p2);
            bool diffRef = ReferenceEquals(p1, p3);
            Console.WriteLine($"p1 和 p2 是同一个对象：{sameRef}");    // true
            Console.WriteLine($"p1 和 p3 是同一个对象：{diffRef}");    // false

            // 2. 判断 null
            bool bothNull = ReferenceEquals(null, null);
            bool oneNull = ReferenceEquals(p1, null);
            Console.WriteLine($"两个 null 相等：{bothNull}");          // true
            Console.WriteLine($"对象和 null 相等：{oneNull}");        // false
            #endregion
        }
    }
}

