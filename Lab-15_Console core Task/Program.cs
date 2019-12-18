using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_15_Console_core_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            //inside can go a delegate or anonymous method using lambda 
            // syntax

            var task01 = new Task(   ()=> { } ); // lambda anonymous method

            var task02 = new Task(() => { Console.WriteLine("in task 2"); });// lambda anonymous method
            task02.Start();

            Console.ReadLine();

            var task03 = Task.Run(() => { Console.WriteLine("In Task 03"); });
            var task04 = Task.Run(() => { Console.WriteLine("In Task 04"); });
            var task05 = Task.Run(() => { Console.WriteLine("In Task 05"); });

            //stopwatch 
            //arrays of tasks
            //wait for one to complet / all to compllete 
        }
    }
}
