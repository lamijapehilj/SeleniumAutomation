using System;

namespace CSharpFundas
{
    
    class Program : Program4
    {
        String name;
        String lastName;

        // Parameterless constructor
        public Program()
        {
            this.name = "DefaultName";
            this.lastName = "DefaultLastName";
        }

        // Constructor sa 1 parametrom
        public Program(String name)
        {
            this.name = name;
            this.lastName = "Unknown";
        }

        // Constructor sa 2 parametra
        public Program(String firstName, String lastName)
        {
            this.name = firstName;
            this.lastName = lastName;
        }

        public void getName()
        {
            Console.WriteLine("My name is " + this.name + " " + this.lastName);
        }

        public void getData()
        {
            Console.WriteLine("I am inside the method getData()");
        }

        public void SetData()
        {
            Console.WriteLine("I am inside the method SetData()");
        }

        static void Main(string[] args)
        {
            // Testiranje svih konstruktora
            Program pDefault = new Program();
            Program p1 = new Program("Rahul");
            Program p2 = new Program("Rahul", "Shetty");

            pDefault.getData();
            pDefault.getName();
            pDefault.SetData();

            p1.getData();
            p1.getName();
            p1.SetData();

            p2.getData();
            p2.getName();
            p2.SetData();

            Console.WriteLine("Hello World!");

            int a = 4;
            Console.WriteLine("number is " + a);

            String name = "Rahul";
            Console.WriteLine("Name is " + name);
            Console.WriteLine($"Name is {name}");

            var age = 23;
            Console.WriteLine("Age is " + age);

            dynamic height = 13.2;
            Console.WriteLine($"Height is {height}");

            height = "hello";
            Console.WriteLine($"Height is {height}");
        }
    }
}