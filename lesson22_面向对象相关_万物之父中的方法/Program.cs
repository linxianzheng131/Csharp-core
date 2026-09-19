using System;

namespace Lesson22_面向对象相关_万物之父中的方法
{
    #region 知识点回顾
    //万物之父 object
    //所有类型的基类 是一个引用类型
    //可以利用里氏替换原则装载一切对象
    //存在装箱拆箱
    #endregion

    class Test2
    {
        //Test2类中定义的整型字段i，初始值为2
        public int i = 2;
    }

    class Test
    {
        //值类型字段i，作为Test类的成员，存储在堆中（因Test是引用类型）
        public int i = 1;
        //引用类型字段t2，存储在堆中，存放的是指向Test2对象的指针（引用）
        //初始化时创建新的Test2对象，确保t2不为空
        public Test2 t2 = new Test2();

        #region 知识点二 object中的成员方法
        //普通方法 GetType
        //该方法在反射相关知识点中是非常重要的方法，之后我们会具体的讲解这里返回的Type类型
        //该方法的主要作用就是获取对象运行时的类型Type
        //通过Type结合反射相关知识点可以做很多关于对象的操作。

        //普通方法 MemberwiseClone
        //该方法用于获取对象的浅拷贝对象，口语化的意思就是会返回一个新的对象
        //但是新对象中的引用变量会和老对象中一致（共享引用）。
        //注意：浅拷贝仅复制值类型字段和引用地址，不会复制引用指向的对象本身

        //Clone方法（自定义封装）
        //调用基类的MemberwiseClone实现浅拷贝，再通过as转换为Test类型
        //返回新创建的Test浅拷贝实例
        public Test Clone()
        {
            return MemberwiseClone() as Test;
        }
        #endregion

        #region 知识点三 object中的虚方法
        //虚方法 ToString
        //自定字符串转换规则
        //默认实现会返回包含类型完整名称的字符串（如Lesson22_xxx.Test）
        //重写后可自定义对象打印时的显示内容

        //虚方法 Equals
        //默认实现还是比较两者是否为同一个引用，即相当于ReferenceEquals。
        //但是微软在所有值类型的基类System.ValueType中重写了该方法，用来比较值相等。
        //我们也可以重写该方法，定义自己的比较相等的规则

        //虚方法 GetHashCode
        //该方法是获取对象的哈希码
        //（一种通过算法算出的，表示对象的唯一编码，不同对象哈希码有可能一样，具体值根据哈希算法决定）
        //我们可以通过重写该函数来自己定义对象的哈希码算法，正常情况下，我们使用的极少，基本不用。

        /// <summary>
        /// 重写ToString方法，自定义对象的字符串表示
        /// </summary>
        /// <returns>自定义的对象描述字符串</returns>
        public override string ToString()
        {
            return "唐老狮申明的Test类";
        }

        /// <summary>
        /// 重写Equals方法，自定义相等判断规则
        /// （示例：可根据业务需求自定义相等逻辑，此处默认调用基类实现，实际可扩展）
        /// </summary>
        /// <param name="obj">待比较的对象</param>
        /// <returns>是否相等的结果</returns>
        public override bool Equals(object obj)
        {
            //默认调用基类object的Equals实现，可根据需求修改为自定义逻辑
            //例如：比较Test的i值和t2引用指向的对象i值是否相等
            return base.Equals(obj);
        }

        /// <summary>
        /// 重写GetHashCode方法，与Equals保持一致的哈希规则
        /// （规范：重写Equals时必须同步重写GetHashCode，保证哈希表存储的正确性）
        /// </summary>
        /// <returns>自定义的哈希码</returns>
        public override int GetHashCode()
        {
            //默认使用基类实现，可根据Test的核心字段计算哈希（如i值 + t2.GetHashCode()）
            return base.GetHashCode();
        }
        #endregion
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("万物之父中的方法");

            #region 知识点一 object中的静态方法
            //静态方法 Equals
            //判断两个对象是否相等
            //最终的判断权，交给左侧对象的Equals方法，
            //不管值类型引用类型都会按照左侧对象Equals方法的规则来进行比较
            Console.WriteLine(Object.Equals(1, 1)); //值类型比较，走ValueType的Equals规则，输出True

            //创建两个Test实例
            Test t = new Test();
            Test t2 = new Test();

            //调用静态Equals比较两个Test对象
            //因Test未重写Equals，默认走object的引用比较逻辑，两个实例引用不同，输出False
            Console.WriteLine(Object.Equals(t, t2));

            //静态方法 ReferenceEquals
            //比较两个对象是否是相同的引用，主要是用来比较引用类型的对象。
            //值类型对象装箱后是不同的引用，返回值始终是false。
            Console.WriteLine(Object.ReferenceEquals(t, t2)); //引用不同，输出False

            int a = 10;
            int b = 10;
            //值类型装箱后为不同对象，ReferenceEquals返回False
            Console.WriteLine(Object.ReferenceEquals(a, b));
            #endregion

            #region 知识点二 object中的成员方法 - 浅拷贝测试
            //通过Type结合反射相关知识点可以做很多关于对象的操作
            Test tClone = new Test();
            Type type = tClone.GetType(); //获取对象运行时类型，输出Lesson22_xxx.Test

            //调用Clone方法实现浅拷贝
            Test t2Clone = tClone.Clone();
            Console.WriteLine("克隆对象后");
            Console.WriteLine("t.i = " + tClone.i); //输出1，值类型独立
            Console.WriteLine("t.t2.i = " + tClone.t2.i); //输出2，引用类型共享
            Console.WriteLine("t2.i = " + t2Clone.i); //输出1，浅拷贝值类型字段
            Console.WriteLine("t2.t2.i = " + t2Clone.t2.i); //输出2，引用类型共享地址

            //修改浅拷贝对象t2Clone的成员值
            t2Clone.i = 20;
            t2Clone.t2.i = 21;
            Console.WriteLine("改变克隆体信息后");
            Console.WriteLine("t.i = " + tClone.i); //输出1，值类型不受影响
            Console.WriteLine("t.t2.i = " + tClone.t2.i); //输出21，引用类型共享，原对象被修改
            Console.WriteLine("t2.i = " + t2Clone.i); //输出20，克隆体值类型独立修改
            Console.WriteLine("t2.t2.i = " + t2Clone.t2.i); //输出21，克隆体引用类型指向同一对象
            #endregion
            
            /*             
            1. 所有 class 默认为：class X : object
            2. object 是所有类型的最终基类
            3. 方法/函数不是类，不继承 object
             */
            #region 知识点三 object中的虚方法 - 调用测试
            //调用重写后的ToString方法，输出自定义字符串
            Console.WriteLine(t.ToString()); //输出“唐老狮申明的Test类”

            //测试对象相等性（因Test默认Equals未重写，比较引用）
            Console.WriteLine(t.Equals(t2)); //输出False
            Console.WriteLine(Object.Equals(t, t2)); //输出False
            #endregion

            Console.ReadLine();
        

        //总结
        //1.虚方法 toString 自定字符串转换规则
        //2.成员方法 GetType 反射相关
        //3.成员方法 MemberwiseClone 浅拷贝
        //4.虚方法 Equals 自定义判断相等的规则
    
}
    }
}