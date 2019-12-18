using System;

namespace Lab_03_Every_Feature_Compained
{
    class Program
    {
        static void Main(string[] args)
        {
            Club myClub = new Stadium();
            myClub.BigMatch();

            Team man = new Team();
            man.thePlayerName();
            
            
        }
    }


     public abstract class Club
     {
        private string ClubName { get; set; }
        public int clubNetWorth { get; set; }
        public abstract void BigMatch();
     }

    class Stadium : Club
    {
        public int pitchSize;
        public int goalPostSize;

        

        public override void BigMatch()
        {
            Console.WriteLine("Man united will play Man City in Old Trafford Stadium");
        }

        public virtual void SizeOfPitch()
        {
            Console.WriteLine("This size of this pitch is 40mm");
        }
        
    }

    class Manager : Stadium
    {

        public override void SizeOfPitch()
        {
            Console.WriteLine("This stadium is the theater of dreams");
        }

    }

    class Team : Stadium
    {

        //public int NumberOfPlayer;

        // private string LastName;
        public string FirstName = "Pogba";
        public void thePlayerName()

        {
            if(FirstName == "Pogber")
            {
                Console.WriteLine("He plays for ManUnited");
            }
            else
            {
                Console.WriteLine("He plays for ManCity");
            }
        }
    }
}
