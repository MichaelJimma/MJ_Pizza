/*
 Michael Jimma
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJ_Pizza
{
    class FoodItems
    {
        private const double TOPPING_PRICE = 1.50;
        private string pizzaSize;
        private IList<string> toppings = new List<string>();
        private IList<string> chickenWings = new List<string>();
        private IList<string> softDrinks = new List<string>();
        private IList<string> smoothies = new List<string>();
        private string sauces;
        private string cheese;
        private string crust;
        private string specialOrder;
        private double pizzaPrice = 0.00;
        private double chickenPrice = 0.00;
        private double softDrinksPrice = 0.00;
        private double smoothiesPrice = 0.00;

        public FoodItems() { }
        public FoodItems(string size, IList<string> topping, IList<string> wings, IList<string> soft, IList<string> smoothie, string sauce, string cheese,string crust, string special)
        {
            this.pizzaSize = size;
            this.toppings = topping;
            this.chickenWings = wings;
            this.softDrinks = soft;
            this.smoothies = smoothie;
            this.sauces = sauce;
            this.cheese = cheese;
            this.crust = crust;
            this.specialOrder = special;
        }
        public string PizzaSize
        {
            get { return this.pizzaSize; }
            set { this.pizzaSize = value; }
        }
        public IList<string> ToppingList
        {
            get { return this.toppings; }
            set { this.toppings = value; }
        }
        public IList<string> ChickenWings
        {
            get { return this.chickenWings; }
            set { this.chickenWings = value; }
        }
        public IList<string> Softdrinks
        {
            get { return this.softDrinks; }
            set { this.softDrinks = value; }
        }
        public IList<string> Smoothies
        {
            get { return this.smoothies; }
            set { this.smoothies = value; }
        }
        public string Sauces
        {
            get { return this.sauces; }
            set { this.sauces = value; }
        }
        public string Cheese
        {
            get { return this.cheese; }
            set { this.cheese = value; }
        }
        public string Crust
        {
            get { return this.crust; }
            set { this.crust = value; }
        }
        public string SpecialOrder
        {
            get { return this.specialOrder; }
            set { this.specialOrder = value; }
        }
        public double ChickenPrice
        {
            get { return this.chickenPrice; }
            set { this.chickenPrice = value; }
        }
        public double SoftDrinksPrice
        {
            get { return this.softDrinksPrice; }
            set { this.softDrinksPrice = value; }
        }
        public double SmoothiesPrice
        {
            get { return this.smoothiesPrice; }
            set { this.smoothiesPrice = value; }
        }
        public void CalculatePizzaPrice()//Adds the pizza price according to the size
        {
            switch (pizzaSize)
            {
                case "Small Size - $8.95":
                    pizzaPrice += 8.95;
                    break;
                case "Medium Size - $12.95":
                    pizzaPrice += 12.95;
                    break;
                case "Large Size - $18.95":
                    pizzaPrice += 18.95;
                    break;
            }

            for (int i = 0; i < toppings.Count; i++)
            {
                pizzaPrice += TOPPING_PRICE;//adds 1.50 on the pizzaPrice by the number of selected toppings
            }
            
        }

        public double CalculateTotal()
        {
            CalculatePizzaPrice();
            return (pizzaPrice + chickenPrice + softDrinksPrice + smoothiesPrice);
        }
       
    }
}
