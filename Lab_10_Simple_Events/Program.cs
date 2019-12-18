using System;

namespace Lab_10_Simple_Events
{
    class Program
    {
        //cerate delegate type
        delegate void MyDelegate();
        //create events (empty at moment)
        static event MyDelegate MyEvents;
        static void Main(string[] args)
        {
            MyEvents += Method01;
            MyEvents += Method02;
            MyEvents -= Method01;


            MyEvents();
        }

        static void Method01()
        {
            Console.WriteLine("Running Method01");

        }

        static void Method02()
        {
            Console.WriteLine("Running Method02");
        }
    }
}
