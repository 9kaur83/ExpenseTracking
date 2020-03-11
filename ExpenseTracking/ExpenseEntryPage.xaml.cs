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
        public ExpenseEntryPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            NavigationPage.SetHasBackButton(this, false);
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var field = (ExpenseTracking.Models.Field)BindingContext;
            if (!string.IsNullOrWhiteSpace(field.Name))

            {
                // Append MonthYear to folder name
                var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.field.txt");

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
