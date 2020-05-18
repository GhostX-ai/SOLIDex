using System;

namespace SOLIDex
{
    class Program
    {
        static void Main(string[] args)
        {
            Jedi jedi = new Jedi();
            jedi.Action = "kill";
            ConsoleAcion killing = new ConsoleAcion() { person = new Person() { Age = 16, FirstName = "Khurshed", LastName = "Egamov", MiddleName = "Killer" } };
            jedi.action(killing);
            DarkSide dark = new DarkSide() { person = new Person() { Age = 26, FirstName = "Aziz", LastName = "Muminov", MiddleName = "Abdifatoevich" } };
            jedi.action(dark);
            Console.ReadKey();
        }
    }
    interface IJedi
    {
        public Person person { get; set; }
        public void action(string active);
    }
    interface IDarkSide : IJedi
    {
        public void GiveCommands(string action);
    }
    interface IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int Age { get; set; }
    }
    class Person : IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int Age { get; set; }
    }
    class Jedi
    {
        public string Action { get; set; }
        public void action(IJedi jedi)
        {
            jedi.action(this.Action);
        }
    }
    class ConsoleAcion : IJedi
    {
        public Person person { get; set; }

        public void action(string action)
        {
            Console.WriteLine($"{this.person.FirstName} is {action}ing");
        }

        public void action(IJedi jedi)
        {
            throw new NotImplementedException();
        }
    }
    class DarkSide : IDarkSide
    {
        public Person person { get; set; }

        public void action(string active)
        {
            GiveCommands(active);
        }

        public void GiveCommands(string action)
        {
            Console.WriteLine($"DarkSide giving command to {action}");
        }
    }
}
