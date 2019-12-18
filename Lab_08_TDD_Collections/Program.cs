using System;
using System.Collections.Generic;

namespace Lab_08_TDD_Collections
{
    class Program
    {
        static void Main(string[] args)
        {
           // Lab_08_Array_List_Dictionary.getTotal();


        }

        

       
    }
    public class Lab_08_Array_List_Dictionary
    {

        


        public static int getTotal(int a, int b, int c, int d, int e)
        {

            List<int> numberList = new List<int>();

            int[] intArray2 = new int[5];

            intArray2[0] = a + 5;
            intArray2[1] = b + 5;
            intArray2[2] = c + 5;
            intArray2[3] = d + 5;
            intArray2[4] = e + 5;

            numberList.Add(intArray2[0] * intArray2[0]);
            numberList.Add(intArray2[1] * intArray2[1]);
            numberList.Add(intArray2[2] * intArray2[2]);
            numberList.Add(intArray2[3] * intArray2[3]);
            numberList.Add(intArray2[4] * intArray2[4]);

            Dictionary<int, int> numberDic = new Dictionary<int, int>()
            {

                [0] = numberList[0] - 10,
                [1] = numberList[1] - 10,
                [2] = numberList[2] - 10,
                [3] = numberList[3] - 10,
                [4] = numberList[4] - 10,

            };
            int sum = numberDic[0] + numberDic[1] + numberDic[2] + numberDic[3] + numberDic[4];


            return sum;
            // Console.WriteLine(sum);
        }



    }
}
