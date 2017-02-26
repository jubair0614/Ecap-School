using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProperty
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.Name = "Md. Jubair Ibna Mostafa";
            person.Age = 22;
            Console.WriteLine("Name: " + person.Name + "\n" + "Age: " + person.Age);
        }
    }

    public class Person
    {
       public string Name { get; set; }
       public int Age { get; set; }
    }
}
