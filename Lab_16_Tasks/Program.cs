using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Linq;

namespace Lab_16_Tasks
{
    public class Program
    {
        static Stopwatch ms = new Stopwatch(); // doesnt like the var
        static void Main(string[] args)
        {

            var s = new Stopwatch();
            s.Start();

            var task01 = Task.Run(() =>
            {
                Console.WriteLine("Task01 is running ");
                Console.WriteLine($"Task01 completed at time {s.ElapsedMilliseconds}");

            });

            //old facshioned way of putting a delegate 
            var actionDelegate = new Action(SpecialActionMethod);// pass in methods as arguments 
            var task02 = new Task(actionDelegate);
            task02.Start();

            Task[] taskAarray = new Task[]
            {
                //lamba is cool if you want to do background task 
                new Task( ()=> { }),
                 new Task( ()=> { }),
                 new Task( ()=> { }),
                 new Task( ()=> { }),
                 new Task( ()=> { }),
                 new Task( ()=> { }),
                 new Task( ()=> { })


            };

            foreach(var task in taskAarray)
            {
                task.Start();
            }

            var taskArray2 = new Task[3];
            taskArray2[0] = Task.Run(() => {
                Thread.Sleep(500);
                Console.WriteLine($"Array task 0 completing at {s.ElapsedMilliseconds}"); });

            taskArray2[1] = Task.Run(() => {
                Thread.Sleep(200);
                Console.WriteLine($"Array task 1 completing at {s.ElapsedMilliseconds}");
            });

            taskArray2[2] = Task.Run(() => {
                Thread.Sleep(100);
                Console.WriteLine($"Array task 2 completing at {s.ElapsedMilliseconds}");
            });

            Task.WaitAny(taskArray2);
            Console.WriteLine($"Waiting for the first array task to complete at {s.ElapsedMilliseconds}");

            Task.WaitAll(taskArray2);
            Console.WriteLine($"Waiting for all  array task to complete at {s.ElapsedMilliseconds}");

            // parallel foreach loop
            int[] myCollection = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
            //regular for each is in order 1..2..3..4
            // parallel for each just kick opf  x jobs at same time , wait for answer
            Parallel.ForEach(myCollection, (item) => {
                Thread.Sleep(item * 100);
                Console.WriteLine($"for each new item {item} finish at time{s.ElapsedMilliseconds}");

                Console.WriteLine($"\n\n Now run as Sync loop\n");

                
               
               





            }); // pass our delegate IE method 

            long t = 0;
            foreach (var item in myCollection)
            {
                Thread.Sleep(item * 100);
                Console.WriteLine($"for each new item {item} finish at time{s.ElapsedMilliseconds}");

                t += s.ElapsedMilliseconds;

                Console.WriteLine($"syne {t}");


            }

            //Also powerfull is parallel linq :  database querues in parallel
            //fakle it here : use local collection

            var databaseOutput =
                (from item in myCollection
                 select item).AsParallel().ToList();
            // could use 

            //getttign data back fro task
            var taskWithOutReturnData = new Task(() => { });
            var taskWithReturningData = new Task<int>(() =>{
               int total = 0;
               for(int i = 0; i< 100; i++)
               {
                   total += i;

               }

                return total;
           });

            Console.WriteLine($"I have counted to 100 using a background task so i dont have" +
                            $"to hang the main thread while i wait . the answer is{taskWithReturningData.Result} "
                
                );






            Console.WriteLine($"Application has finished at time {s.ElapsedMilliseconds}");
            // one tick is 10 to the power -7 seconds ie 0.1 micro second
            Console.WriteLine($"Application has finished at time {s.ElapsedTicks}");
            Console.ReadLine();
        }

        static void SpecialActionMethod()
        {
            Console.WriteLine("This action method taskes on parameters, returns nothing, but just" + 
                "performs an action, in this case print out ..");
            var total = 0;
            for(int i=0; i < 1_000_000; i++)
            {
                total += i;
            }
            Console.WriteLine($"special action method completing at {ms.ElapsedMilliseconds}" );
        }

    }
}
