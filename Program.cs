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
            jedi.action(dark);
            Console.ReadKey();
        }
    }
    interface IJedi
    {
        public Person person { get; set; }
        public void action(string active);
    }
    
    
    class Jedi
    {
        public string Action { get; set; }
        public void action(IJedi jedi)
        {
            jedi.action(this.Action);
        }
    }
    
    
}
