using System;

namespace Lesson10_封装_运算符重载
{
    #region 知识点一 基本概念
    //概念
    //让自定义类和结构体
    //能够使用运算符
    //使用关键字
    //operator
    //特点
    //1. 一定是一个公共的静态方法
    //2. 返回值写在operator前
    //3. 逻辑处理自定义
    //作用
    //让自定义类和结构体对象可以进行运算
    //注意
    //1. 条件运算符需要成对实现
    //2. 一个符号可以多个重载
    //3. 不能使用ref和out
    #endregion

    #region 知识点二 基本语法
    //public static 返回类型 operator 运算符(参数列表)
    #endregion

    #region 知识点三 实例
    class Point
    {
        public int x;
        public int y;

        // 重载 + 运算符：两个 Point 相加
        public static Point operator +(Point p1, Point p2)
        {
            Point p = new Point();
            p.x = p1.x + p2.x;
            p.y = p1.y + p2.y;
            return p;
        }

        // 重载 + 运算符：Point 与 int 相加
        public static Point operator +(Point p1, int value)
        {
            Point p = new Point();
            p.x = p1.x + value;
            p.y = p1.y + value;
            return p;
        }

        // 重载 + 运算符：int 与 Point 相加（保证交换律）
        public static Point operator +(int value, Point p1)
        {
            Point p = new Point();
            p.x = p1.x + value;
            p.y = p1.y + value;
            return p;
        }

        #region 算数运算符
        //注意 符号需要两个参数还是一个参数

        // 重载 - 运算符：两个 Point 相减
        public static Point operator -(Point p1, Point p2)
        {
            Point p = new Point();
            p.x = p1.x - p2.x;
            p.y = p1.y - p2.y;
            return p;
        }

        // 重载 * 运算符：两个 Point 相乘
        public static Point operator *(Point p1, Point p2)
        {
            Point p = new Point();
            p.x = p1.x * p2.x;
            p.y = p1.y * p2.y;
            return p;
        }

        // 重载 / 运算符：两个 Point 相除
        public static Point operator /(Point p1, Point p2)
        {
            if (p2.x == 0 || p2.y == 0)
                throw new DivideByZeroException("坐标值不能为0");
            Point p = new Point();
            p.x = p1.x / p2.x;
            p.y = p1.y / p2.y;
            return p;
        }

        // 重载 % 运算符：两个 Point 取模
        public static Point operator %(Point p1, Point p2)
        {
            if (p2.x == 0 || p2.y == 0)
                throw new DivideByZeroException("坐标值不能为0");
            Point p = new Point();
            p.x = p1.x % p2.x;
            p.y = p1.y % p2.y;
            return p;
        }

        // 重载 ++ 运算符：Point 自增（前缀）
        public static Point operator ++(Point p1)
        {
            Point p = new Point();
            p.x = p1.x + 1;
            p.y = p1.y + 1;
            return p;
        }

        // 重载 -- 运算符：Point 自减（前缀）
        public static Point operator --(Point p1)
        {
            Point p = new Point();
            p.x = p1.x - 1;
            p.y = p1.y - 1;
            return p;
        }
        #endregion

        #region 逻辑运算符
        //注意 符号需要两个参数还是一个参数

        // 重载 ! 运算符：逻辑非
        public static bool operator !(Point p1)
        {
            // 当 x 和 y 都为 0 时，返回 true
            return p1.x == 0 && p1.y == 0;
        }
        #endregion

        #region 位运算符
        //注意 符号需要两个参数还是一个参数

        // 重载 | 运算符：按位或
        public static Point operator |(Point p1, Point p2)
        {
            Point p = new Point();
            p.x = p1.x | p2.x;
            p.y = p1.y | p2.y;
            return p;
        }

        // 重载 & 运算符：按位与
        public static Point operator &(Point p1, Point p2)
        {
            Point p = new Point();
            p.x = p1.x & p2.x;
            p.y = p1.y & p2.y;
            return p;
        }

        // 重载 ^ 运算符：按位异或
        public static Point operator ^(Point p1, Point p2)
        {
            Point p = new Point();
            p.x = p1.x ^ p2.x;
            p.y = p1.y ^ p2.y;
            return p;
        }

        // 重载 ~ 运算符：按位取反（一元运算符）
        public static Point operator ~(Point p1)
        {
            Point p = new Point();
            p.x = ~p1.x;
            p.y = ~p1.y;
            return p;
        }
        #endregion

        #region 条件运算符
        //1. 返回值一般是bool值 也可以是其它的
        //2. 相关符号必须配对实现

        // 重载 > 运算符
        public static bool operator >(Point p1, Point p2)
        {
            // 比较到原点的距离平方
            return (p1.x * p1.x + p1.y * p1.y) > (p2.x * p2.x + p2.y * p2.y);
        }

        // 重载 < 运算符
        public static bool operator <(Point p1, Point p2)
        {
            return (p1.x * p1.x + p1.y * p1.y) < (p2.x * p2.x + p2.y * p2.y);
        }

        // 重载 >= 运算符
        public static bool operator >=(Point p1, Point p2)
        {
            return !(p1 < p2);
        }

        // 重载 <= 运算符
        public static bool operator <=(Point p1, Point p2)
        {
            return !(p1 > p2);
        }
        #endregion
    }
    #endregion

    #region 知识点五 可重载和不可重载的运算符
    #region 可重载的运算符
    // 算数运算符：+ - * / % ++ --
    // 逻辑运算符：!
    // 位运算符：| & ^ ~
    // 条件运算符：> < >= <=
    #endregion

    #region 不可重载的运算符
    //逻辑与(&&) 逻辑或(||)
    //索引符 []
    //强转运算符 ()
    //特殊运算符
    //点.   三目运算符?:   赋值符号=
    #endregion
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("运算符重载");

            #region 知识点四 使用
            Point p = new Point();
            p.x = 1;
            p.y = 1;

            Point p2 = new Point();
            p2.x = 2;
            p2.y = 2;

            // 使用重载的 + 运算符
            Point p3 = p + p2;
            Console.WriteLine($"p + p2 = ({p3.x}, {p3.y})"); // 输出 (3, 3)

            // 使用重载的 + 运算符（Point + int）
            Point p4 = p3 + 2;
            Console.WriteLine($"p3 + 2 = ({p4.x}, {p4.y})"); // 输出 (5, 5)

            // 使用重载的 + 运算符（int + Point）
            Point p5 = 2 + p3;
            Console.WriteLine($"2 + p3 = ({p5.x}, {p5.y})"); // 输出 (5, 5)

            // 使用重载的 > 运算符
            bool isLarger = p > p2;
            Console.WriteLine($"p > p2 ? {isLarger}"); // 输出 False
            #endregion
        }
    }
}