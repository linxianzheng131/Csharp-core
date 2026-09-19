namespace Study
{
    class Person
    {
        public int age;
        //this指的就是这个
        public Person(int age)
        {
            this.age = age + 1;
            Console.WriteLine($"this age={this.age},age={age}");
            //age 是外来的
        }
        public void speak()
        {
            int age = 10;
            //局部变量 = 成员变量时 成员变量就会被覆盖
            //this就是指的 成员变量
            Console.WriteLine(this.age);
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
