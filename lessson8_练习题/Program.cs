using System;

#region 数学计算静态类
/// <summary>
/// 写一个用于数学计算的静态类
/// 该类中提供计算圆面积，圆周长，矩形面积，矩形周长，取一个数的绝对值等方法
/// </summary>
public static class MathUtility
{
    #region 计算圆的面积
    /// <summary>
    /// 计算圆的面积
    /// </summary>
    /// <param name="radius">圆的半径</param>
    /// <returns>圆的面积</returns>
    public static double CalculateCircleArea(double radius)
    {
        if (radius < 0)
            throw new ArgumentException("半径不能为负数。");
        return Math.PI * radius * radius;
    }
    #endregion

    #region 计算圆的周长
    /// <summary>
    /// 计算圆的周长
    /// </summary>
    /// <param name="radius">圆的半径</param>
    /// <returns>圆的周长</returns>
    public static double CalculateCirclePerimeter(double radius)
    {
        if (radius < 0)
            throw new ArgumentException("半径不能为负数。");
        return 2 * Math.PI * radius;
    }
    #endregion

    #region 计算矩形的面积
    /// <summary>
    /// 计算矩形的面积
    /// </summary>
    /// <param name="length">矩形的长</param>
    /// <param name="width">矩形的宽</param>
    /// <returns>矩形的面积</returns>
    public static double CalculateRectangleArea(double length, double width)
    {
        if (length < 0 || width < 0)
            throw new ArgumentException("长和宽不能为负数。");
        return length * width;
    }
    #endregion

    #region 计算矩形的周长
    /// <summary>
    /// 计算矩形的周长
    /// </summary>
    /// <param name="length">矩形的长</param>
    /// <param name="width">矩形的宽</param>
    /// <returns>矩形的周长</returns>
    public static double CalculateRectanglePerimeter(double length, double width)
    {
        if (length < 0 || width < 0)
            throw new ArgumentException("长和宽不能为负数。");
        return 2 * (length + width);
    }
    #endregion

    #region 取一个数的绝对值
    /// <summary>
    /// 取一个数的绝对值
    /// </summary>
    /// <param name="number">输入的数</param>
    /// <returns>该数的绝对值</returns>
    public static double AbsoluteValue(double number)
    {
        return Math.Abs(number);
    }
    #endregion
}
#endregion

#region 主程序入口
internal class Program
{
    static void Main(string[] args)
    {
        // 示例调用
        double radius = 5;
        //F2表示保留俩位小数
        Console.WriteLine($"半径为{radius}的圆面积：{MathUtility.CalculateCircleArea(radius):F2}");
        Console.WriteLine($"半径为{radius}的圆周长：{MathUtility.CalculateCirclePerimeter(radius):F2}");

        double length = 4, width = 6;
        Console.WriteLine($"长{length}、宽{width}的矩形面积：{MathUtility.CalculateRectangleArea(length, width):F2}");
        Console.WriteLine($"长{length}、宽{width}的矩形周长：{MathUtility.CalculateRectanglePerimeter(length, width):F2}");

        double num = -7.5;
        Console.WriteLine($"{num}的绝对值：{MathUtility.AbsoluteValue(num):F2}");
    }
}
#endregion
