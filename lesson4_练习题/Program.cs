using System;

namespace TicketProblemSolution
{
    #region 题目1：实现Ticket类
    /*
    题目：
    写一个Ticket类，有一个距离变量（在构造对象时赋值，不能为负数），有一个价格特征，
    有一个方法GetPrice可以读取到价格，并且根据距离distance计算价格price（1元/公里）
    0~100公里 不打折
    101~200公里 打9.5折
    201~300公里 打9折
    300公里以上 打8折
    有一个显示方法，可以显示这张票的信息。
    例如：100公里100块钱
    */
    public class Ticket
    {
        // 私有字段：距离（构造时赋值，不能为负）
        private double _distance;
        // 私有字段：价格（根据距离计算得出）
        private double _price;

        // 构造函数：初始化距离并校验合法性，同时计算价格
        public Ticket(double distance)
        {
            if (distance < 0)
                throw new ArgumentException("距离不能为负数！");
            _distance = distance;
            CalculatePrice(); // 调用内部方法计算价格
        }

        // 私有方法：根据距离计算价格
        private void CalculatePrice()
        {
            double basePrice = _distance * 1; // 基础价格：1元/公里

            if (_distance <= 100)
                _price = basePrice; // 0~100公里不打折
            else if (_distance <= 200)
                _price = basePrice * 0.95; // 101~200公里打9.5折
            else if (_distance <= 300)
                _price = basePrice * 0.9; // 201~300公里打9折
            else
                _price = basePrice * 0.8; // 300公里以上打8折
        }

        // 公共方法：读取价格
        public double GetPrice()
        {
            return _price;
        }

        // 公共方法：显示票的信息
        public void ShowInfo()
        {
            Console.WriteLine($"{_distance}公里，价格：{_price:F2}元");
        }
    }
    #endregion

    #region 测试代码
    class Program
    {
        static void Main(string[] args)
        {
            // 测试用例1：100公里
            Ticket ticket1 = new Ticket(100);
            ticket1.ShowInfo();

            // 测试用例2：150公里
            Ticket ticket2 = new Ticket(150);
            ticket2.ShowInfo();

            // 测试用例3：250公里
            Ticket ticket3 = new Ticket(250);
            ticket3.ShowInfo();

            // 测试用例4：350公里
            Ticket ticket4 = new Ticket(350);
            ticket4.ShowInfo();
        }
    }
    #endregion
}
