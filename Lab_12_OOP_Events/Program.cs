using System;

namespace Lab_12_OOP_Events
{
    class Program
    {
        static void Main(string[] args)
        {
            var James = new Child("James");
            James.Grow();
            James.Grow();
            James.Grow();
            James.Grow();

        }

        class Child
        {

            //TRIVIAL EVENTS ANUAL BIRTHDAY!

            delegate void BirthdayDelegate();
             event BirthdayDelegate HaveABirthday;

            public string Name { get; set; }

            public int Age { get; set; }

            public void HaveAparty()
            {
                // this refers to the instance
                this.Age++;
                Console.WriteLine($"Hey cele another year HELLOOOOOO" +  $"Age is now {this.Age}");
            }

            public Child (string Name)
            {
                this.Name = Name;
                this.Age = 0;
                HaveABirthday += HaveAparty; // placeholder
            }

            public void Grow()
            {
                HaveABirthday();// call the events
            }

            
        }
    }
}
