namespace Addition6_protect
{
    public class Father
    {
        public int i;
        protected void Speak()
        {
            Console.WriteLine("Protected");
        }
        public void clone()
        {
            Speak();
        }
        protected Father Father1()
        {
            Father father = new Father();
            father.i = 1;
            return father;
        }
    }

    public class Son : Father
    {
        public void Speak1()
        {
            this.Speak();
            //默认隐式调用
        }
        
    }
    internal class Program : Father
    {
        public void Speak1()
        {
            Speak();
        }
        public Father Father1()
        {
            return Father1();
        }
        //死循环不要运行
        static void Main(string[] args)
        {
            //Speak();报错
            //可以将Main函数当成外面理解
            //而且一定要有实例声明后 用实例调用 （不可以隐式调用）
            //static存在的时候其他函数都没有出现
            //在Main函数这个外面中无论如何都无法使用protected的东西 只能中转

            //静态函数中不能使用非静态成员
            // 成员变量只能将对象实例化出来后 才能点出来使用 不能无中生有
            // 不能直接使用 非静态成员 否则会报错
            Father father = new Father();
            //father.Speak();报错
            //在外面调用protected 只能在Father内部和子类使用
            //（son as Son）.Speak():报错
            //也是在外面调用protect             
            father.clone ();
            Father son = new Son();
            if(son is Son )
            {
                (son as Son).Speak1();

            }
        }
    }
}
