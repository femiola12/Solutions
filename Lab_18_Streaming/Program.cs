using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Diagnostics;
using System.Text;

    
namespace Lab_18_Streaming
{
    class Program
    {
        static void Main(string[] args)
        {
            File.WriteAllText("data.txt", "Hello this is some data");

            var myArray = new string[] { "Hello", "This" };
            File.WriteAllLines("ArrayDta.txt", myArray);


            Console.WriteLine(File.ReadAllText("data.txt"));

            var output = File.ReadAllLines("ArrayDta.txt").ToList();
            output.ForEach(line => Console.WriteLine(line));

            //for(int i = 0; i<10; i++)
            //{
            //    File.AppendAllLines("data.txt", Environment.NewLine + $"Add");
            //}

            Directory.CreateDirectory("Here is a folder");
            File.Create("Here is a folder\\myfile.txt");
            File.Create(@"Here is a folder\myfile2.txt");

            Directory.CreateDirectory(@"C:\RootFolder");
            Console.WriteLine(Directory.Exists(@"C:\RootFolder"));


            //Stream some data to a file
            //system can cope  with large
            var number_line = 70_000;
            var s = new Stopwatch();
            s.Start();
            using (var stream01 = new StreamWriter("output.dat"))
            {


                for(int i = 0; i < number_line; i++)
                {
                    stream01.WriteLine($"Logging some data at {DateTime.Now}");
                }
                
            }

            var writeTime = s.ElapsedMilliseconds;
            Console.WriteLine($"it takes {s.ElapsedMilliseconds} to wtite 10000 lines");

            string nextline;

            using (var reader = new StreamReader("output.dat"))
            {

                // string nextline;
                //Reader does not know how big file is 
                // read until .readline is null
                while ((nextline = reader.ReadLine()) != null)
                {

                }

                reader.Close();
                Console.WriteLine($"it took {s.ElapsedMilliseconds - writeTime} to read {number_line}");

                //building a string
                //regular string building with + GENERATE a new Instance every time 
                // t ==> th  == thi
            }
            s.Restart();

            var longString = "";

            using (var reader = new StreamReader("output.dat"))
            {
                while((nextline = reader.ReadLine()) != null)
                {
                    longString += nextline;
                }
                reader.Close();
            }

            Console.WriteLine($"it took {s.ElapsedMilliseconds} to write {number_line}");

            s.Restart();
            longString = "";
            var stringBuilder = new StringBuilder();

            using (var reader = new StreamReader("output.dat"))
            {
                while ((nextline = reader.ReadLine()) != null)
                {
                    stringBuilder.Append(nextline);
                }
                reader.Close();
            }

            Console.WriteLine($"it took {s.ElapsedMilliseconds} to write {number_line} string Builder");
        }
    }
}
