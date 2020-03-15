using System;
using System.Reflection;
using Xamarin.Forms;

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

        public string FilePath { get; set; }

        public string Name { get; set; }
        public DateTime MonthYear { get; }
        public decimal Amount { get; set; }

        public ImageSource itemTypeImage
        {
            get
            {
                /*var assembly = typeof(ExpenseTracking.Models.Field).GetTypeInfo().Assembly;
                foreach (var res in assembly.GetManifestResourceNames())
                {
                    System.Diagnostics.Debug.WriteLine("found resource: " + res);
                }*/

                var Source = ImageSource.FromResource("ExpenseTracking.Assets." + itemType.ToString() + ".png",
                    typeof(ExpenseTracking.Models.Field).GetTypeInfo().Assembly);

                return Source;
            }
        }

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
