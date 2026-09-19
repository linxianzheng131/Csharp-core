using System;

namespace Vector3Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 第一题：定义位置类并重载相等运算符
            // 定义一个位置结构体或类，为其重载判断是否相等的运算符
            // (x1,y1) == (x2,y2) => 两个值同时相等才为true
            Position pos1 = new Position(2, 3);
            Position pos2 = new Position(2, 3);
            Position pos3 = new Position(1, 4);
            Console.WriteLine($"pos1 == pos2: {pos1 == pos2}"); // True
            Console.WriteLine($"pos1 == pos3: {pos1 == pos3}"); // False
            #endregion

            #region 第二题：定义Vector3类并重载运算符
            // 定义一个Vector3类 (x,y,z) 通过重载运算符实现以下运算
            // (x1,y1,z1) + (x2,y2,z2) = (x1+x2,y1+y2,z1+z2)
            // (x1,y1,z1) - (x2,y2,z2) = (x1-x2,y1-y2,z1-z2)
            // (x1,y1,z1) * num = (x1*num,y1*num,z1*num)
            // 补充：点积、叉积运算
            Vector3 v1 = new Vector3(1, 2, 3);
            Vector3 v2 = new Vector3(4, 5, 6);
            Vector3 vAdd = v1 + v2;
            Vector3 vSub = v1 - v2;
            Vector3 vMul = v1 * 2;
            float dot = v1 | v2; // 用 | 表示点积
            Vector3 cross = v1 * v2; // 用 * 表示叉积（也可以用其他符号）

            Console.WriteLine($"v1 + v2 = ({vAdd.x}, {vAdd.y}, {vAdd.z})"); // (5,7,9)
            Console.WriteLine($"v1 - v2 = ({vSub.x}, {vSub.y}, {vSub.z})"); // (-3,-3,-3)
            Console.WriteLine($"v1 * 2 = ({vMul.x}, {vMul.y}, {vMul.z})"); // (2,4,6)
            Console.WriteLine($"v1 · v2 = {dot}"); // 点积结果：1*4 + 2*5 + 3*6 = 32
            Console.WriteLine($"v1 × v2 = ({cross.x}, {cross.y}, {cross.z})"); // 叉积结果：(-3, 6, -3)
            #endregion
        }
    }

    #region 第一题实现
    /// <summary>
    /// 位置类，用于表示二维坐标点 (x, y)
    /// </summary>
    public class Position
    {
        public int x;
        public int y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// 重载 == 运算符，判断两个位置是否相等
        /// 只有当 x 和 y 坐标都相等时，两个位置才相等
        /// </summary>
        public static bool operator ==(Position p1, Position p2)
        {
            // 处理两个都为 null 的情况
            if (ReferenceEquals(p1, p2))
                return true;
            // 处理其中一个为 null 的情况
            if (p1 is null || p2 is null)
                return false;
            return p1.x == p2.x && p1.y == p2.y;
        }

        /// <summary>
        /// 重载 != 运算符，与 == 运算符逻辑相反
        /// </summary>
        public static bool operator !=(Position p1, Position p2)
        {
            return !(p1 == p2);
        }

        /// <summary>
        /// 重写 Equals 方法，保证与 == 运算符行为一致
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj is Position other)
                return this == other;
            return false;
        }

        /// <summary>
        /// 重写 GetHashCode 方法，当重写 Equals 时必须同时重写
        /// </summary>
        public override int GetHashCode()
        {
            return HashCode.Combine(x, y);
        }
    }
    #endregion

    #region 第二题实现
    /// <summary>
    /// 三维向量类，用于表示三维空间中的向量 (x, y, z)
    /// </summary>
    public class Vector3
    {
        public float x;
        public float y;
        public float z;

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// 重载 + 运算符，实现两个三维向量的加法
        /// 对应分量相加：(x1+x2, y1+y2, z1+z2)
        /// </summary>
        public static Vector3 operator +(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        /// <summary>
        /// 重载 - 运算符，实现两个三维向量的减法
        /// 对应分量相减：(x1-x2, y1-y2, z1-z2)
        /// </summary>
        public static Vector3 operator -(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        /// <summary>
        /// 重载 * 运算符，实现向量与标量的乘法
        /// 每个分量乘以标量：(x*num, y*num, z*num)
        /// </summary>
        public static Vector3 operator *(Vector3 v, float num)
        {
            return new Vector3(v.x * num, v.y * num, v.z * num);
        }

        /// <summary>
        /// 重载 * 运算符，实现标量与向量的乘法（保证交换律）
        /// 每个分量乘以标量：(num*x, num*y, num*z)
        /// </summary>
        public static Vector3 operator *(float num, Vector3 v)
        {
            return v * num;
        }

        #region 补充：点积与叉积
        /// <summary>
        /// 重载 | 运算符，实现向量点积（Dot Product）
        /// 公式：v1 · v2 = x1*x2 + y1*y2 + z1*z2
        /// 返回一个标量值
        /// </summary>
        public static float operator |(Vector3 v1, Vector3 v2)
        {
            return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
        }

        /// <summary>
        /// 重载 * 运算符，实现向量叉积（Cross Product）
        /// 公式：v1 × v2 = (y1*z2 - z1*y2, z1*x2 - x1*z2, x1*y2 - y1*x2)
        /// 返回一个新的 Vector3，该向量与 v1、v2 都垂直
        /// </summary>
        public static Vector3 operator *(Vector3 v1, Vector3 v2)
        {
            float crossX = v1.y * v2.z - v1.z * v2.y;
            float crossY = v1.z * v2.x - v1.x * v2.z;
            float crossZ = v1.x * v2.y - v1.y * v2.x;
            return new Vector3(crossX, crossY, crossZ);
        }
        #endregion
    }
    #endregion
}