using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PointOfSales
{
    class BusinessLayer
    {

    }
    public class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class Cart {

        public List<Item> Items { get; private set; }
        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        public decimal CalculateTotal()
        {
            decimal total = 0;
            foreach (Item k in Items)
                total += k.Price;
            return total;
        }
    }
}
