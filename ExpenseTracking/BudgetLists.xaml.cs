using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Android.Icu.Text.DateFormat;
using ExpenseTracking.Models;

namespace ExpenseTracking
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BudgetLists : ContentPage
    {
        public BudgetLists()
        {
            InitializeComponent();

            NavigationPage.SetHasBackButton(this, false);
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();

            var fields = new List<ExpenseTracking.Models.Field>();

            var files = Directory.EnumerateFiles(App.FolderPath, "*.field.txt");
            foreach (var filename in files)
            {
                var data = File.ReadAllText(filename);

                var values = data.Split(new string[] { "\t"}, StringSplitOptions.None);

                fields.Add(new ExpenseTracking.Models.Field
                {
                    Name = values[0],
                    DateOfPurchase = DateTime.Parse(values[2]),
                    Amount = Decimal.Parse(values[1]),
                    itemType = (TypeOfItem)Enum.Parse(typeof(TypeOfItem), values[3])
                });
            }

            listView.ItemsSource = fields
                .OrderBy(d => d.DateOfPurchase)
                .ToList();
        }


        async void OnNoteAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ExpenseEntryPage
            {
                BindingContext = new ExpenseTracking.Models.Field()
            });
        }

        private async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ExpenseEntryPage
                {
                    BindingContext = e.SelectedItem as ExpenseTracking.Models.Field
                });
            }
        }

        private async void OnExpenseListAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ExpenseEntryPage
            {
                BindingContext = new ExpenseTracking.Models.Field()
            });

            //await Navigation.PushAsync(new ExpenseEntryPage());
        }

        private async void NavigateButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ExpenseEntryPage
            {
                BindingContext = new ExpenseTracking.Models.Field()
            });

             await Navigation.PushAsync(new ExpenseEntryPage());

        }

    }
}