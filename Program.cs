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

            int randomNumber;

            List<string> daysOfWeek = new List<string>() 
                {
                "Sunday", "Monday", "Teusday", "Wednesday", "Thursday", "Friday", "Saturday"
                };
            int dayIndex = 0;

            List<string> timeOfDay = new List<string>()
                {
                "9:00 am", "10:00 am", "11:00 am", "12:00 pm", "1:00 pm", "2:00 pm", "3:00 pm", "4:00 pm"
                };
            int hourIndex = 0;

            string shopName = "Bike Rentals R' US";
            int funds = 1000;


            string playerInput;

            int bikeIndex;
            bool keepPlaying = true;

            string bikeType;
            string bikeColor;


            while (keepPlaying == true)
            {
                Menu();
                playerInput = Console.ReadLine();
                Console.Clear();

                switch (playerInput)
                {
                    case "0":

                        Tutorial();

                        break;

                    case "1":

                        Console.WriteLine("What would you like to name your Bike Rental Shop?");
                        shopName = Console.ReadLine();

                        break;

                    case "2":

                        BuyBike();
                        break;

                    case "3":

                        Console.WriteLine("Which bike do you want to repair?");

                        int count = 1;
                        foreach (Bike bike in listOfBikes)
                        {
                            if (bike.IsRented == false)
                            {
                                Console.WriteLine($"{count}. {bike.Color} {bike.Type} bike, with {bike.Durability}% durability.");
                            }

                            count++;
                        }

                        bikeIndex = Convert.ToInt32(Console.ReadLine());

                        if (listOfBikes[bikeIndex - 1].IsRented == false)
                        {
                            listOfBikes[bikeIndex - 1].PerformMaintenance();
                            Console.WriteLine($"You repaired the {listOfBikes[bikeIndex - 1].Color} {listOfBikes[bikeIndex - 1].Type} bike.");
                        }   

                        else
                        {
                            Console.WriteLine("You spend an hour looking for a bike that is currently rented out.");
                        }
                        

                        break;

                    case "4":

                        bikeIndex = -1;
                        string customerFavoriteColor = RandomColor();

                        foreach (Bike bike in listOfBikes)
                        {
                            if(customerFavoriteColor.Equals(bike.Color))
                            {
                                bikeIndex = listOfBikes.IndexOf(bike);
                            }
                        }

                        if (bikeIndex == -1)
                        {
                            randomNumber = random.Next(1, listOfBikes.Count);
                            randomNumber -= 1;

                            listOfBikes[randomNumber].RentBike();
                            funds += 60;

                            Console.WriteLine($"A customer rented the {listOfBikes[randomNumber].Color} {listOfBikes[randomNumber].Type} bike at random.");
                        }

                        else
                        {
                            listOfBikes[bikeIndex].RentBike();

                            funds += 60;

                            Console.WriteLine($"A customer rented the {listOfBikes[bikeIndex].Color} {listOfBikes[bikeIndex].Type} because it is their favorite color!");
                        }

                        break;

                    case "5":

                        foreach (Bike bike in listOfBikes)
                        {
                            Console.Write($"The {bike.Color} {bike.Type} bike, with {bike.Durability}% Durability,");
                            if (bike.IsRented == false)
                            {
                                Console.Write(" is currently in the shop.\n");
                            }
                            else
                            {
                                Console.Write($" is rented for {bike.RentalTimeRemaining} more hours.\n");
                            }
                        }
                        break;

                    case "6":

                        Console.WriteLine("Thank you for playing!");
                        keepPlaying = false;
                        break;

                    default:
                        Console.WriteLine("You spend an hour playing on your phone, unsure of what to do.");
                        break;
                }

                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                Console.Clear();
                TimeTick();
                foreach (Bike bike in listOfBikes)
                {
                    if (bike.IsRented == true)
                    {
                        bike.Tick();
                    }
                }
                    
            }


            void Tutorial()
            {
                Console.WriteLine($"Welcome, new manager of {shopName}!");
                Console.WriteLine("This onboarding experience is designed to help you succeed in your new position!");
                Console.WriteLine("When you are ready, press any key to continue this tutorial.");
                Console.ReadKey();
                Console.Clear();

                Console.WriteLine($"Welcome to {shopName}");
                Console.WriteLine($"It is {timeOfDay[hourIndex]} on {daysOfWeek[dayIndex]}");
                Console.WriteLine($"Shop Funds: ${funds}");

                Console.WriteLine("\nThis is your main interface. It displays your shop name, the time of day and day of the week, and how much money you have available.");
                Console.WriteLine("Let's start with your clock.");
                Console.WriteLine("As an aspiring business-person, your shop will be open every day of the week, from 9:00 am to 5:00 pm.");
                Console.WriteLine("While we will cover what you can do during business hours a little later, for now know that time will progress on it's own.");
                Console.WriteLine("$350 for rent will be automatically deducted from your account at the end of business hours every Saturday.");
                Console.WriteLine("As you can see, you have $1000 left in the bank after setting up your business!");
                Console.WriteLine("Your funds can go negative, but if you cannot pay rent when it is due, you will be forced to close your shop for good.");
                Console.WriteLine("When ready, press any key to continue.");
                Console.ReadKey();
                Console.Clear();

                Console.WriteLine($"Welcome to {shopName}");
                Console.WriteLine($"It is {timeOfDay[hourIndex]} on {daysOfWeek[dayIndex]}");
                Console.WriteLine($"Shop Funds: ${funds}");

                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1. Change Shop Name");
                Console.WriteLine("2. Buy Bike");
                Console.WriteLine("3. Repair a Bike");
                Console.WriteLine("4. Rent Bike");
                Console.WriteLine("5. Check Inventory");
                Console.WriteLine("6. Quit Game");

                Console.WriteLine("\nThis is your main menu for interacting with the shop during business hours.");
                Console.WriteLine("Option 1 lets you change the name of the shop.");
                Console.WriteLine("Option 2 allows you to add a bike to your inventory. You will be able to choose it's type and color from a list. Each bike costs $150.");
                Console.WriteLine("Option 3 allows you to repair a bike, as they get damaged when rented out.");
                Console.WriteLine("Option 4 is your main method of making money. Customers will rent your bike for 4 hours at a time, paying $60 up front.");
                Console.WriteLine("Every customer has a favorite color, and will always rent a bike in that color if available. If not, they will choose at random.");
                Console.WriteLine("If a rented bike would be returned after business hours, it will be returned on the following day.");
                Console.WriteLine("Option 5 lists every bike you own, and is how you check their durability. It also marks which ones are currently rented out.");
                Console.WriteLine("Each of these options moves time forward by 1 hour.");
                Console.WriteLine("And finally, option 6 exits the game when you are done playing.");
                Console.WriteLine("That's all for the tutorial! When you're ready to start playing, press any key!");

            }

            void Menu()
            {
                Console.WriteLine($"Welcome to {shopName}");
                Console.WriteLine($"It is {timeOfDay[hourIndex]} on {daysOfWeek[dayIndex]}");
                Console.WriteLine($"Shop Funds: ${funds}");

                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("0. View Tutorial");
                Console.WriteLine("1. Change Shop Name");
                Console.WriteLine("2. Buy Bike");
                Console.WriteLine("3. Repair a Bike");
                Console.WriteLine("4. Rent Bike");
                Console.WriteLine("5. Check Inventory");
                Console.WriteLine("6. Quit Game");

            }

            void TimeTick()
            {
                hourIndex += 1;

                if (hourIndex > 7)
                {
                    hourIndex = 0;
                    dayIndex += 1;
                    Console.WriteLine("your work day has come to an end, and you close up shop for the night.");

                    if (dayIndex > 6)
                    {
                        dayIndex = 0;
                        funds -= 350;
                        Console.WriteLine("Another long week is over. Rent has been deducted from your account.");

                        if (funds < 0)
                        {
                            Console.WriteLine("You were unable to pay rent when it was due. You are forced to close your shop.");
                            keepPlaying = false;
                        }
                    }

                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            void BuyBike()
            {
                Console.WriteLine("What kind of bike would you like to buy?");
                Console.WriteLine("1. Mountain");
                Console.WriteLine("2. Tandem");
                Console.WriteLine("3. Recumbent");
                playerInput = Console.ReadLine();

                switch (playerInput)
                {
                    case "1":
                        bikeType = "Mountain";
                        break;

                    case "2":
                        bikeType = "Tandem";
                        break;

                    case "3":
                        bikeType = "Recumbent";
                        break;

                    default:
                        Console.WriteLine("Unable to choose, you picked one at random.");
                        randomNumber = random.Next(1, 3);

                        if (randomNumber == 1)
                        {
                            bikeType = "Mountain";
                        }

                        else if (randomNumber == 2)
                        {
                            bikeType = "Tandem";
                        }

                        else
                        {
                            bikeType = "Recumbent";
                        }
                        break;
                }

                Console.WriteLine($"What color should the bike be?");
                Console.WriteLine("1. Red");
                Console.WriteLine("2. Orange");
                Console.WriteLine("3. Yellow");
                Console.WriteLine("4. Green");
                Console.WriteLine("5. Blue");
                Console.WriteLine("6. Purple");
                playerInput = Console.ReadLine();

                switch (playerInput)
                {
                    case "1":
                        bikeColor = "Red";
                        break;

                    case "2":
                        bikeColor = "Orange";
                        break;

                    case "3":
                        bikeColor = "Yellow";
                        break;

                    case "4":
                        bikeColor = "Green";
                        break;

                    case "5":
                        bikeColor = "Blue";
                        break;

                    case "6":
                        bikeColor = "Purple";
                        break;

                    default:
                        Console.WriteLine("Unable to choose, you picked one at random.");
                        bikeColor = RandomColor();
                        break;
                }

                listOfBikes.Add(new Bike(bikeType, bikeColor));
                funds -= 150;

            }

            string RandomColor()
            {
                string randomColor;

                randomNumber = random.Next(1, 6);

                if (randomNumber == 1)
                {
                    randomColor = "Red";
                }

                else if (randomNumber == 2)
                {
                    randomColor = "Orange";
                }

                else if (randomNumber == 3)
                {
                    randomColor = "Yellow";
                }

                else if (randomNumber == 4)
                {
                    randomColor = "Green";
                }

                else if (randomNumber == 5)
                {
                    randomColor = "Blue";
                }

                else
                {
                    randomColor = "Purple";
                }

                return randomColor;
            }


        }

    }
}
