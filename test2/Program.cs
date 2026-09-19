

using System.Dynamic;

namespace test2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] arr = new int[5];
            for (int i = 0; i < 5; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
           

            for (int i = 0; i < arr.Length - 1; i++)
            {
                int index = i;
                for (int j = i + 1; j < arr.Length ; j++)
                {
                    if(arr[j] > arr[index])
                    {
                        index = j;
                    }
                    
                }
                Console.WriteLine("index: " + arr[index]);
                if (index != i)
                {
                    int temp = arr[i];
                    arr[i] = arr[index];
                    arr[index] = temp;
                }

            }
           
            
            Console.WriteLine("Sorted array: ");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

    }
}
