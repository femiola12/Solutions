using System;

namespace Lab_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Cat ca = new Tiger();
            ca.road();

            Cat ca1 = new Lion();
            ca1.road();


            Console.ReadLine();
        }
    }

    class Mammal
    {
        bool IsWarmBlooded = true;
        private int  weight;
        private int height;
        private int lengh;

        public int Weight { get => weight; set => weight = value; }
        public int Height { get => height; set => height = value; }
        public int Lengh { get => lengh; set => lengh = value; }
    }

    class Cat: Mammal, IUseVSmell,IUseVISION
    {

        public virtual void road()
        {
            
        }

        public virtual void seeMyPray()
        {
           
        }

        public virtual void SmellMyPrey()
        {
            
        }
    }
    
    class Lion: Cat
    {
        public override void road()
        {
            Console.WriteLine("Lion is roaring");
        }

        public override void seeMyPray()
        {
            Console.WriteLine("Lion is see its prey ");

        }

        public override void SmellMyPrey()
        {
            Console.WriteLine("Lion is smells it prey");
        }
    }

    class Tiger:Cat
    {
        public override void road()
        {
            Console.WriteLine("Tiger is roaring");
        }

        public override void seeMyPray()
        {
            Console.WriteLine("Tiger is see its prey ");

        }

        public override void SmellMyPrey()
        {
            Console.WriteLine("Tiger is smells it prey");
        }
    }

    interface IUseVISION
    {

        public void seeMyPray();

    }

    interface IUseVSmell
    {
        public void SmellMyPrey();


    }




}
