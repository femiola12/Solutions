using System;

namespace Lab_29_Simpsons_Rule_Area_Under_Graph
{
    class Program
    {
        static void Main(string[] args)
        {

           // Console.WriteLine(   answer.GetAreaUnderGraphUsingSimpsonsRule(6, 0, 6));
            //Console.Read();
        }

        /*
         Homework!
         Graph of Y=X* X(can hard code this in)
         Points 0,1,2,3,4,5,6=N(value of X)
         Value of Y : 0,1,4,9,16,25,36
         Goal : approximate AREA UNDER GRAPH
         Simpsons Rule : 
         Area =  ((MAX X - MIN X)/ 3 N ) * 
            [Y(zeroth item)  + Y(last item) 
              + 4(odd-indexed items ie N = 1,3,5) 
              + 2(even-indexed items ie N = 2,4)
          ]
          https://www.intmath.com/integration/6-simpsons-rule.php
          Because it's a double you can't test for exact value
          But can test<> upper/lower bound which you can fix to 2 decimal places
         * */



        
        

    }

    public class answer
    {
        public  double GetAreaUnderGraphUsingSimpsonsRule(int n, int min, int max)
        {
            // n=6, min=0, max=6, difference =(max-min/n)



            //double number1 = ((max - min) / n);

            //double number2 = (min * min) + (max * max);

            //double number3 = 4 * (number1 * n);

            //double number4 = 2 * (number1 * n);

            //double answer = (number1 * number2) + (number3 + number4);

            //return answer;

            float number = (max - min) / n;
            int[] x = new int[max];
            int[] y = new int[max];
            int oddIndex = 0;
            int evenIndex = 0;
            int count = 0;


            for (int i = 0; i < max; i++)
            {
                x[i] = (i + 1);
                y[i] = ((i + 1) * (i + 1));
            }
            
            foreach (int num in y)
            {
                if (count == (max - 1))
                {

                }
                else if (x[count] % 2 == 0)
                {
                    evenIndex += num;
                    count++;
                }
                else
                {
                    oddIndex += num;
                    count++;
                }
            }

            double area = (number / 3) * (y[min] + y[max - 1] + (oddIndex * 4) + (evenIndex * 2));

            return Math.Round(area);




        }
    }
}
