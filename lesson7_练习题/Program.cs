using System;

namespace CustomArray_ManualMove
{
    #region 题目：用索引器+手动搬家方式实现整型数组的增删查改
    /*
    题目要求：
    1. 严格遵循“搬家原理”：不使用Array.Resize，完全通过for循环复制元素。
    2. 使用索引器实现查、改、增功能。
    3. 封装删除方法，同样使用for循环实现。
    */
    class ManualIntArray
    {
        // 内部的整型数组核心变量
        private int[] _array;

        // 构造函数：初始化一个空数组
        public ManualIntArray()
        {
            _array = new int[0];
        }

        #region 核心：索引器 (实现 查 / 改 / 增)
        public int this[int index]
        {
            get
            {
                // 【查】：索引校验
                if (index < 0 || index >= _array.Length)
                {
                    Console.WriteLine("索引越界，无法查询！");
                    return -1; // 返回默认值代替抛出异常
                }
                return _array[index];
            }
            set
            {
                // 【改】：索引在范围内，直接赋值
                if (index >= 0 && index < _array.Length)
                {
                    _array[index] = value;
                }
                // 【增】：索引超出范围，执行“搬家扩容”
                else if (index >= _array.Length)
                {
                    Console.WriteLine("索引{0}超出范围，执行手动扩容...", index);

                    // 1. 准备新房子：长度为 index + 1 (图片中的原理)
                    int[] newArray = new int[index + 1];

                    // 2. 搬家：用for循环把旧数组的元素复制到新数组
                    for (int i = 0; i < _array.Length; i++)
                    {
                        newArray[i] = _array[i];
                    }

                    // 3. 放入新元素 (对应图片中的 array[5] = 999)

                    newArray[index] = value;

                    // 4. 换门牌号：让旧数组引用指向新数组
                    _array = newArray;
                }
            }
        }
        #endregion

        #region 核心：删除方法 (实现 删)
        /// <summary>
        /// 按索引删除元素，严格遵循图片中的“搬家原理”
        /// </summary>
        /// <param name="removeIndex">要删除的索引</param>
        public void Remove(int removeIndex)
        {
            // 边界校验
            if (removeIndex < 0 || removeIndex >= _array.Length || _array.Length == 0)
            {
                Console.WriteLine("无法删除，索引无效或数组为空！");
                return;
            }

            Console.WriteLine($"执行手动删除索引{removeIndex}的元素...");

            // 1. 准备新房子：长度比原来少1 (图片中的原理)
            int[] newArray = new int[_array.Length - 1];

            // 2. 搬家：分两段复制，跳过要删除的索引
            // 复制前半段：0 到 removeIndex - 1
            for (int i = 0; i < removeIndex; i++)
            {
                newArray[i] = _array[i];
            }

            // 复制后半段：removeIndex + 1 到 末尾
            // 新数组的索引要比旧数组少1
            for (int i = removeIndex + 1; i < _array.Length; i++)
            {
                newArray[i - 1] = _array[i];
            }

            // 3. 换门牌号：更新引用
            _array = newArray;
        }
        #endregion

        #region 辅助方法
        // 获取当前数组长度
        public int Length => _array.Length;

        // 打印数组 (模仿图片中的遍历输出)
        public void PrintArray()
        {
            Console.WriteLine("===== 数组当前内容 =====");
            for (int i = 0; i < _array.Length; i++)
            {
                Console.WriteLine($"索引[{i}] = {_array[i]}");
            }
            Console.WriteLine($"数组长度：{_array.Length}");
            Console.WriteLine("=======================");
        }
        #endregion
    }
    #endregion

    #region 测试程序
    class Program
    {
        static void Main(string[] args)
        {
            ManualIntArray myArray = new ManualIntArray();

            // 1. 【增】：利用索引器扩容 (对应图片中的 array2 逻辑)
            // 此时数组长度为0，赋值索引0会触发扩容
            myArray[0] = 10;
            // 赋值索引5，会扩容到6个长度
            myArray[5] = 999;

            myArray.PrintArray();

            // 2. 【改】：直接修改已有索引
            myArray[0] = 100;
            Console.WriteLine("修改后，索引0的值为：" + myArray[0]);

            // 3. 【删】：调用Remove方法 (对应图片中的 array3 逻辑)
            myArray.Remove(0); // 删除第一个元素
            myArray.PrintArray();

            Console.ReadKey();
            int[] arr = new int[0];
            
        }
    }
    #endregion
}