using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppRESTAPIAssignments.Shared.Models
{
    public class ShoppingItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public bool HaveBought { get; set; }

        public ShoppingItem(int id, string name, int quantity, bool haveBought)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            HaveBought = haveBought;
        }
    }
}
