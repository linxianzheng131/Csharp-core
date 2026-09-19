namespace Study
{
    class Person
    {        
        public int age;
        //this所指的是这个
        public Person(int age)
        {
            this.age = age + 1;
            Console.WriteLine($"this age={this.age},age={age}");
        }
        public void speak()
        {
            int age = 10;
            //会隐藏成员变量 加this就不会了
            Console.WriteLine(this.age);
            Console.WriteLine(age);
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {            
            int age = 12;
            Person person = new Person(age);
            Console.WriteLine($"{person.age}");
            person.speak();
        }
    }
}
