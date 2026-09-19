namespace lesson18_练习题
{
    public abstract class Animal
    {
        public string Name { get; set; }
        public abstract void Speak();
    }
    public class Dog : Animal
    {
        public override void Speak()
        {
            Console.WriteLine($"{Name} says: Woof!");
        }
    }
    public class Cat : Animal
    {
        public override void Speak()
        {
            Console.WriteLine($"{Name} says: Meow!");
        }
    }
    public class Person : Animal
    {
        public string Name { get; set; }
        public override void Speak()
        {
            Console.WriteLine($"{Name} says: Hello!");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
           Animal dog = new Dog { Name = "Buddy" };
           Animal cat = new Cat { Name = "Whiskers" };
           Animal person = new Person { Name = "Alice" };
        }
    }
}
