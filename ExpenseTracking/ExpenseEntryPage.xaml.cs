using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracking;
using ExpenseTracking.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace ExpenseTracking
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpenseEntryPage : ContentPage
    {
        readonly DateTime MonthYear;

        public ExpenseEntryPage(DateTime monthYear)
        {
            InitializeComponent();

            this.MonthYear = monthYear;
        }

        protected override void OnAppearing()
        {
            NavigationPage.SetHasBackButton(this, false);

            DateTime minDate = new DateTime(MonthYear.Year, MonthYear.Month, 1);
            DateTime maxDate = minDate.AddMonths(1).AddDays(-1);
           
            SelectedDay.SetValue(DatePicker.MaximumDateProperty, maxDate);
            SelectedDay.SetValue(DatePicker.MinimumDateProperty, minDate);
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var field = (ExpenseTracking.Models.Field)BindingContext;
            if (!string.IsNullOrWhiteSpace(field.Name))

            {
                // Append MonthYear to folder name
                var folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), field.MonthYear.Date.Year.ToString() + field.MonthYear.Date.Month.ToString());

                Directory.CreateDirectory(folderPath);

                var filename = string.IsNullOrWhiteSpace(field.FilePath) ? Path.Combine(folderPath, $"{Path.GetRandomFileName()}.field.txt") : field.FilePath;

                string data = field.Name + "\t" + field.Amount.ToString() + "\t" + field.DateOfPurchase.ToString() + "\t" + field.selectedType;

                File.WriteAllText(filename, data);
            }

            await Navigation.PopAsync();
        }

        private async void OnCancelButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
