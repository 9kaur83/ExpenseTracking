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
        public Field(DateTime monthYear)
        {
            DateOfPurchase = DateTime.Now;
            this.MonthYear = monthYear;
        }

        public string Name { get; set; }
        public DateTime MonthYear { get; }
        public decimal Amount { get; set; }

        public string DateOfPurchaseString
        {
            get
            {
                return DateOfPurchase.ToString("MM-dd-yyyy");
            }
        }

        public DateTime MinimumDate
        {
            get
            {
                return new DateTime(MonthYear.Year, MonthYear.Month, 1);
            }
        }

        public DateTime MaximumDate
        {
            get
            {
                DateTime maxDate = MinimumDate.AddMonths(1).AddDays(-1);
                return maxDate;
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
