namespace lesson23_面对对象相关_String方法
{
    
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("=== C# 字符串常用操作演示 ===");
                Console.WriteLine();

                #region 知识点一 字符串指定位置获取
                // 字符串本质是char数组，可通过索引访问单个字符
                string str = "唐老狮";
                // 索引从0开始，str[0]获取第一个字符
                Console.WriteLine("知识点一：字符串指定位置获取");
                Console.WriteLine($"原字符串：{str}");
                Console.WriteLine($"str[0] = {str[0]}"); // 输出：唐

                // 转为char数组，可更灵活操作
                char[] chars = str.ToCharArray();
                Console.WriteLine($"chars[1] = {chars[1]}"); // 输出：老

                // 遍历字符串所有字符
                Console.WriteLine("遍历字符串所有字符：");
                for (int i = 0; i < str.Length; i++)
                {
                    Console.WriteLine(str[i]);
                }
                Console.WriteLine();
                #endregion

                #region 知识点二 字符串拼接
                // 字符串拼接的常用方式：string.Format
                Console.WriteLine("知识点二：字符串拼接");
                // {0} {1} 是占位符，对应后面的第1、2个参数
                str = string.Format("{0}{1}", 1, 3333);
                Console.WriteLine($"拼接结果：{str}"); // 输出：13333

                // 补充：其他常用拼接方式
                // 1. 直接+号拼接
                string str1 = "Hello";
                string str2 = "World";
                Console.WriteLine($"+号拼接：{str1 + " " + str2}"); // 输出：Hello World
                                                                // 2. $字符串插值（C# 6+推荐）
                int a = 10;
                int b = 20;
                Console.WriteLine($"插值拼接：a={a}, b={b}"); // 输出：a=10, b=20
                Console.WriteLine();
                #endregion

                #region 知识点三 正向查找字符位置
                // IndexOf：从字符串开头正向查找，返回第一个匹配项的索引
                Console.WriteLine("知识点三：正向查找字符位置");
                str = "我是唐老狮！";
                // 查找"唐"第一次出现的位置
                int index = str.IndexOf("唐");
                Console.WriteLine($"\"唐\"第一次出现的索引：{index}"); // 输出：2

                // 查找不存在的字符，返回-1
                index = str.IndexOf("吊");
                Console.WriteLine($"不存在的\"吊\"的索引：{index}"); // 输出：-1
                Console.WriteLine();
                #endregion

                #region 知识点四 反向查找指定字符串位置
                // LastIndexOf：从字符串末尾反向查找，返回最后一个匹配项的索引
                Console.WriteLine("知识点四：反向查找指定字符串位置");
                str = "我是唐老狮唐老狮";
                // 查找"唐老狮"最后一次出现的位置
                index = str.LastIndexOf("唐老狮");
                Console.WriteLine($"\"唐老狮\"最后一次出现的索引：{index}"); // 输出：5

                // 查找不存在的字符串，返回-1
                index = str.LastIndexOf("唐老师");
                Console.WriteLine($"不存在的\"唐老师\"的索引：{index}"); // 输出：-1
                Console.WriteLine();
                #endregion

                #region 知识点五 移除指定位置后的字符
                // Remove：移除字符串中指定位置的字符
                Console.WriteLine("知识点五：移除指定位置后的字符");
                str = "我是唐老狮唐老狮";
                Console.WriteLine($"原字符串：{str}");

                // 单参数：从指定索引开始，移除后面所有字符
                // 注意：字符串是不可变类型，方法返回新字符串，原字符串不变
                str.Remove(4);
                Console.WriteLine($"直接调用Remove(4)，原字符串不变：{str}");
                // 必须接收返回值才会生效
                str = str.Remove(4);
                Console.WriteLine($"接收返回值后，Remove(4)结果：{str}"); // 输出：我是唐老

                // 双参数：参数1=开始位置，参数2=要移除的字符个数
                str = str.Remove(1, 1);
                Console.WriteLine($"Remove(1,1)结果：{str}"); // 输出：我唐老
                Console.WriteLine();
                #endregion

                #region 知识点六 替换指定字符串
                // Replace：将字符串中指定的子串替换为新的子串
                Console.WriteLine("知识点六：替换指定字符串");
                str = "我是唐老狮唐老狮";
                Console.WriteLine($"原字符串：{str}");

                // 同样，字符串不可变，直接调用不改变原字符串
                str.Replace("唐老狮", "老炮儿");
                Console.WriteLine($"直接调用Replace，原字符串不变：{str}");
                // 必须接收返回值
                str = str.Replace("唐老狮", "老炮儿");
                Console.WriteLine($"替换后结果：{str}"); // 输出：我是老炮儿老炮儿
                Console.WriteLine();
                #endregion

                #region 知识点七 大小写转换
                // ToUpper()：转大写；ToLower()：转小写
                Console.WriteLine("知识点七：大小写转换");
                str = "ksdfasdfasfasdf sasdfasdf";
                Console.WriteLine($"原字符串：{str}");

                // 字符串不可变，直接调用不改变原字符串
                str.ToUpper();
                Console.WriteLine($"直接调用ToUpper，原字符串不变：{str}");
                // 接收返回值
                str = str.ToUpper();
                Console.WriteLine($"ToUpper转大写结果：{str}");

                // 转小写
                str.ToLower();
                Console.WriteLine($"直接调用ToLower，原字符串不变：{str}");
                str = str.ToLower();
                Console.WriteLine($"ToLower转小写结果：{str}");
                Console.WriteLine();
                #endregion

                #region 知识点八 字符串截取
                // Substring：截取字符串的子串
                Console.WriteLine("知识点八：字符串截取");
                str = "唐老狮唐老狮";
                Console.WriteLine($"原字符串：{str}");

                // 单参数：从指定索引开始，截取后面所有字符
                str.Substring(2);
                Console.WriteLine($"直接调用Substring(2)，原字符串不变：{str}");
                str = str.Substring(2);
                Console.WriteLine($"Substring(2)结果：{str}"); // 输出：狮唐老狮

                // 双参数：参数1=开始位置，参数2=要截取的字符个数
                // 注意：不会自动判断越界，必须自己保证参数合法，否则会报错
                str = str.Substring(2, 2);
                Console.WriteLine($"Substring(2,2)结果：{str}"); // 输出：老狮
                Console.WriteLine();
                #endregion

                #region 知识点九 字符串切割
                // Split：按指定分隔符将字符串切割为字符串数组
                Console.WriteLine("知识点九：字符串切割");
                str = "1_1|2_2|3_3|5_1|6_1|7_2|8_3";
                Console.WriteLine($"原字符串：{str}");

                // 按'|'分隔，返回string[]数组
                string[] strs = str.Split('|');
                Console.WriteLine("切割后遍历结果：");
                for (int i = 0; i < strs.Length; i++)
                {
                    Console.WriteLine(strs[i]);
                }
                // 补充：可按多个分隔符切割
                str2 = "a,b;c d";
                string[] strs2 = str2.Split(',', ';', ' ');
                Console.WriteLine("多分隔符切割结果：");
                foreach (string s in strs2)
                {
                    Console.WriteLine(s);
                }
                #endregion

                Console.WriteLine("\n=== 演示结束 ===");
                Console.ReadKey();
            }
        }
    }
