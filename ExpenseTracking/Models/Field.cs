using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracking.Models
{
    public enum TypeOfItem
    {
        Home,

        Entertainment,

        Food,

        Charity,

        Utilities,

        Auto,

        Education,

        HealthAndWellness,

        Shopping
    }

    class Field
    {
        public Field()
        {
            DateOfPurchase = DateTime.Now;
        }

        public string Name { get; set; }
        public decimal Amount { get; set; }

        public string DateOfPurchaseString
        {
            get
            {
                return DateOfPurchase.ToString("MM-dd-yyyy");
            }
        }

        public DateTime DateOfPurchase
        {
            get; set;
        }

        public TypeOfItem itemType { get; set; }

        public string selectedType { get; set; }
    }
}
