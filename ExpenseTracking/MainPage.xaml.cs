using Android.Content.Res;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExpenseTracking
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        string filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + ".fields.txt");
        public MainPage()
        {
            InitializeComponent();

            RefreshBudget();
        }

        private void RefreshBudget()
        {
            if (File.Exists(filename))
            {
                budgetInputField.Text = File.ReadAllText(filename);
            }
            else
            {
                budgetInputField.Text = String.Empty;
            }
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            File.WriteAllText(filename, budgetInputField.Text);

            await NavigateToNextPage();
        }

        private async Task NavigateToNextPage()
        {
            await Navigation.PushAsync(new BudgetLists(monthYear.Date), true);
        }

        private void monthYear_DateSelected(object sender, DateChangedEventArgs e)
        {
            filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), monthYear.Date.Year.ToString() + monthYear.Date.Month.ToString() + ".fields.txt");
            RefreshBudget();
        }
    }
}
