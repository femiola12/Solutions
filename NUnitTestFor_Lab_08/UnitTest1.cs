using NUnit.Framework;
using Lab_08_TDD_Collections;
using Lab_09_Rabbit_Test;

using Lab_17_Northwide_Tests;
using Lad_14_Linq;
using Lab_20_NorthWwnd_Products;
using Lab_28_Fibonacci;
using Lab_29_Simpsons_Rule_Area_Under_Graph;


namespace NUnitTestFor_Lab_08
{
    public class Tests
    {
        Lab_08_Array_List_Dictionary nm = new Lab_08_Array_List_Dictionary();

        [SetUp]
        public void Setup()
        {

        }

        // annotations
        [Test]
        public void Test1()
        {

            //eg get data from database for all tests
            //var expected = 280;
            //var actual = nm.getTotal(5, 5, 5, 5, 5);
            //Assert.AreNotEqual(expected, actual);
        }

        [Test]
        //public void getTotal()
        //{
        //    var expected = 280;
        //    var actual = nm.getTotal(1,2,3,4,5);
        //    Assert.AreEqual(expected, actual);
        //}


        [TestCase(1, 2, 3, 4, 5, 280)]
        // [TestCase(20, 21, 22, 23, 24, 3605)]
        // [TestCase(30, 31, 32, 33, 34, 6805)]
        // [TestCase(40, 41, 42, 43, 44, )]

        public void getTotal(int a, int b, int c, int d, int e, int expected)
        {
            // call method in OTHER PROJECT 
            int act = Lab_08_Array_List_Dictionary.getTotal(1, 2, 3, 4, 5);
            //get answer
            // act = 280;
            // see if answer is correct or not
            Assert.AreEqual(expected, act);
        }

        //[TestCase(3,7,8)]
        [TestCase(3, 3, 1)]
        [TestCase(4, 4, 2)]
        [TestCase(9, 25, 10)]

        public void RabbitGrowthTest(int totalYears, int expectedRabbitAge, int expectedRabbitCount)
        {
            (int actualCumulativeAge, int actualRabbitCount) = Rabbit_Collection.MultiplyRabbits(totalYears);

            Assert.AreEqual(expectedRabbitAge, actualCumulativeAge);
            Assert.AreEqual(expectedRabbitCount, actualRabbitCount);
        }

        #region TestNumberOfNorthwindCustomers
        [TestCase(null, 101)]// how many customers total
        public void testNumberOfNorthwindCustomer(string city, int expected)
        {
            // arrange




            //act

            //var TestInstance = Lad_14_Linq.CustomersRead.PrintCustomer();
            var TestInstance1 = Lad_14_Linq.CustomersRead.PrintCustomer();
            //var actualTestInstance = TestInstance.p

            //assect
            // Assert.AreEqual(expected, TestInstance);
            Assert.AreEqual(expected, TestInstance1);
        }


        [TestCase("London", 8)]//howmany customer in London 

        public void testNumberOfNorthwindCustomer2(string city, int expected)
        {
            // arrange




            //act

            //var TestInstance = Lad_14_Linq.CustomersRead.PrintCustomer();
            var TestInstance1 = Lad_14_Linq.CustomersRead.PrintCustomer2(city);
            //var actualTestInstance = TestInstance.p

            //assect
           // Assert.AreEqual(expected, TestInstance);
            Assert.AreEqual(expected, TestInstance1);
        }

        [TestCase(null,12)]
        public void AmountOfProduct(string productName,int expected)
        {
            var TestInstance = Lad_14_Linq.CustomersRead.product();

            Assert.AreEqual(expected, TestInstance);
        }

        #endregion

        #region TestNumberOfProducts
        [TestCase("p",3)]
        public void TestNumberOfProduct(string letter, int expected)
        {
            //arrange (instance)

            var actual =  Lab_20_NorthWwnd_Products.NWPorducts.numberofProduct();
            var actual1 = Lab_20_NorthWwnd_Products.NWPorducts.numberofProductLetter(letter);
            //act (method)
            //asset

            Assert.AreEqual(actual, expected);
            Assert.AreEqual(actual1, expected);
        }

        #endregion

        [TestCase(0,0)]
        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(3, 2)]
        [TestCase(4, 3)]
        [TestCase(5, 5)]

        public void TestWorkOut(int n, int expected)
        {
            var fib = new Fiboncci();

            var answer = fib.ReturnFibonciNthItemInSequence(n);

            Assert.AreEqual(answer, expected);
        }

        [TestCase(10,0,10,72)]
        [TestCase (20,0,20, 1366)]
        public void TestSimpsonsCaculation(int n, int min, int max , double expected)
        {
            var area = new answer();
            var caculation = area.GetAreaUnderGraphUsingSimpsonsRule(n, min, max);
            Assert.AreEqual(caculation, expected);
        }


    }
}