using System;
using System.Collections.Generic;

namespace SOLIDex
{
    class Program
    {
        static void Main(string[] args)
        {
            Jedi jedi = new Jedi();
            ConsoleAcion action1 = new ConsoleAcion() { person = new Person() { Age = 16, FirstName = "Khurshed", LastName = "Egamov", MiddleName = "Killer", Level = "Падаван ДаркСидиуса" } };
            ConsoleAcion action2 = new ConsoleAcion() { person = new Person() { Age = 14, FirstName = "Shahzod", LastName = "Bahriev", MiddleName = "Pulodovich", Level = "SkyWalker" } };
            ConsoleAcion action3 = new ConsoleAcion() { person = new Person() { Age = 18, FirstName = "Amin", LastName = "Mirzoev", MiddleName = "Unknown", Level = "Падаван" } };
            DarkSide dark = new DarkSide() { person = new Person() { Age = 26, FirstName = "Aziz", LastName = "Muminov", MiddleName = "Abdifatoevich",Level="Сенсей Дарксидиус" } };
            List<Person> li = new List<Person>();
            li.Add(action1.person);
            li.Add(action2.person);
            li.Add(action3.person);
            li.Add(dark.person);
            GetJediNames(li);
            jedi.Action = "kill";
            jedi.action(action1);
            jedi.action(dark);
            Console.ReadKey();
        }
        static void GetJediNames(List<Person> li)
        {
            li.ForEach(p =>
            {
                Console.WriteLine($"Name:{p.FirstName} Age:{p.Age} Level:{p.Level}");
            });
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
        public string Level { get; set; }
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
        public string Level { get; set; }
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
