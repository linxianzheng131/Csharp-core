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
            #region is 操作符完整演示（类型判断 + 模式匹配 + 空判断）
            // 题目：使用 is 进行类型判断、null 判断、模式匹配，理解 is 与 == 的区别
            object objA = new Vector3(1, 1, 1);
            object objB = new Position(2, 2);
            object objC = null;

            // 1. 判断是否为某类型
            if (objA is Vector3)
            {
                Console.WriteLine("objA 是 Vector3 类型");
            }

            // 2. 判断是否为 null（安全，不会抛异常）
            if (objC is null)
            {
                Console.WriteLine("objC 是 null");
            }

            // 3. 模式匹配：判断+赋值一步完成（最常用）
            if (objB is Position pos)
            {
                Console.WriteLine($"objB 是 Position，x={pos.x} y={pos.y}");
            }

            // 4. is 不会触发 == 重载，只看类型和null
            Position pNull = null;
            bool isNull = pNull is null;     // true
            bool equalNull = pNull == null;   // 会走我们重载的 ==
            Console.WriteLine($"pNull is null: {isNull}");
            #endregion
        }
    }
}
