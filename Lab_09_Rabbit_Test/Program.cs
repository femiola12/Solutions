using System;
using System.Collections.Generic;

namespace Lab_09_Rabbit_Test
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Rabbit_Collection
    {
        public static List<Rabbit> rabbits;

        /*
         Input totalYears to run the system
         Output will be list of rabbits produced 
         Every year, double number of rabnits 
         Every year, increments age also of every reabbits 
         Test data 
         Year 0 1 rabbits age 0 
         Year 1 2       1,0
         Year 2 4       2,1,0,0
         year 3 8       3,2,1,1,0,0  ==> total age = 7 lenght 8
         * 
         * 
         */
        public static (int cumulativeAge, int rabbitCount) MultiplyRabbits(int totalYears)
        {
            rabbits = new List<Rabbit>();

            var rabbit0 = new Rabbit
            {
                RabbitID = 0,
                RabbitName = "Rabbit0",
                RabbitAge = 0
            };

            rabbits.Add(rabbit0);

            for (int year = 0; year < totalYears; year++)
            {
                #region ForEachRabbitGenerateANewOneAndAddOneYear
                // for each rabbit, generate a new one
                foreach (var rabbit in rabbits.ToArray())
                {
                    if(rabbit.RabbitAge >= 3)
                    {
                        var newRabbit = new Rabbit();
                        rabbits.Add(newRabbit);
                       
                    }
                    rabbit.RabbitAge++;
                }

               
            }

            int cumulativeRabbitAge = 0;
            rabbits.ForEach(r => cumulativeRabbitAge += r.RabbitAge);

            return (cumulativeRabbitAge, rabbits.Count);
        }
    }

    public class Rabbit
    {
        public int RabbitID { get; set; }

        public string RabbitName { get; set; }

        public int RabbitAge { get; set; }

        public Rabbit()
        {
            this.RabbitID = Rabbit_Collection.rabbits.Count + 1;
            RabbitName = "Rabbit" + this.RabbitID;
            RabbitAge = 0;
        }

    }
    #endregion


}