using System;

namespace Delegates
{
    class Program
    {

        public delegate void Delegates01();

        delegate int  Delegates02(int x);
        static void Main(string[] args)
        {
            //delegate CAN BE REFERENCED AS CLASS
            //use new keyword
            var delegateInstance = new Delegates01(MyMethod01);
            //call this 

            delegateInstance();
            // trivail cases can simplify (same result)
            // 1. omit 'new'

            Delegates01 delegateInstance2 = MyMethod01;
            delegateInstance2();

            //final trivial case
            //ACTION DELEGATE IN VOID AND TAKES NO PARAMETERS
            Action delegateInstance3 = MyMethod01;
            delegateInstance3();

            Delegates02 delegateInstance4 = (x) => { return x * x * x; }; //Lambda
                                                                          // INPUT PARAMS {// CODE BODY}

            Delegates02 delegateInstance5 = (x) =>  x * x * x;  //Lambda
                                                                // INPUT PARAMS {// CODE BODY}
            Console.WriteLine(MyMethod02(delegateInstance5(10)));
                                                               // INPUT PARAMS {// CODE BODY}

        }

        static void MyMethod01()
        {
            Console.WriteLine("Running Method01");
        }
        static int MyMethod02(int x)
        {
            return x * x;
        }
    }
}
