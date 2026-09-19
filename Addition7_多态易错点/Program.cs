namespace Addition7_多态易错点
{
    public class Father
    {
        public virtual void Speak()
        {
            Console.WriteLine("父亲说话了");
        }
    }
    public class Son : Father
    {
        public void Speak()
        {
            Console.WriteLine("儿子说话了");
        }
    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            Father son = new Son();
            son.Speak();
            (son as Son).Speak();
            //基类加virtual，子类不加override，等于还是隐藏了父类的方法，父类的Speak方法被隐藏了（使用son引用时体现）（和没写virtual一样）
            //所以调用son.Speak()时，输出的是父类的方法内容，而不是子类的方法内容。
            //用Father装载Son对象时，调用Speak方法会调用Father类中的Speak方法，而不是Son类中的Speak方法。
            //相当于Father类指向了许多Father中的值，而这些值用Son实例（而Son的方法并没有实例）这时遇到重复时只能调用Father类中的方法，而无法调用Son类中的方法。
            //如果子类的方法加上override修饰符，表示子类的方法重写了父类的方法，那么调用son.Speak()时，输出的就是子类的方法内容了。

        }
    }
}
