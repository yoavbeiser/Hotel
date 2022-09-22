using System;
namespace Hotel
{
    public class Snack : IRefreshments
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Snack(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }
}

