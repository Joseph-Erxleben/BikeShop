using System;
using System.Collections.Generic;
using System.Text;

namespace Choose_Your_Class
{
    public class Bike
    {

        public string Type { get; set; }
        public string Color { get; set; }
        public int Durability { get; set; } = 100;
        public bool IsRented { get; set; } = false;
        public int RentalTimeRemaining { get; set; } = 0;

        public string GetColor()
        {
            string color = Color;
            return color;
        }

        public Bike()
        {
            
        }

        public Bike(string type, string color)
        {
            Type = type;
            Color = color;
        }

        public void PerformMaintenance()
        {
            Durability += 20;
            if (Durability > 100)
            {
                Durability = 0;
            }
        }

        public void RentBike()
        {
            IsRented = true;
            RentalTimeRemaining = 4;
            Durability -= 30;
        }

        public void Tick()
        {
            RentalTimeRemaining -= 1;
            if (RentalTimeRemaining <= 0)
            {
                IsRented = false;
                RentalTimeRemaining = 0;
            }
        }

    }
}
