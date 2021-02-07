using System;
using System.Collections.Generic;
using System.Text;

namespace Choose_Your_Class
{
    class Program
    {
        static void Main()
        {

            List<Bike> listOfBikes = new List<Bike>();
            Random random = new Random();
            List<string> daysOfWeek = new List<string>() 
                {
                "Sunday", "Monday", "Teusday", "Wednesday", "Thursday", "Friday", "Saturday"
                };

            string shopName = "Bike Rentals R' US";
            int funds = 1000;


            bool keepPlaying = false;

            Console.WriteLine($"Welcome, new managaer of {shopName}!");
            Console.WriteLine("This onboarding experience is designed to help you suceed in your new position!");
            Console.WriteLine("When you are ready, press any key to continue.");
            Console.ReadKey();








        }

    }
}
