using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AffairNamesps;
using App1.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.pages
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class AffairAddingPage : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadAffair(value);
            }
        }

        public AffairAddingPage()
        {
            InitializeComponent();

            BindingContext = new Affair();
        }

        private async void LoadAffair(string value)
        {
            try
            {
                int id = Convert.ToInt32(value);

                Affair affair = await App.DatBasDB.GetAffairAsync(id);

                BindingContext = affair;
            }
            catch { }
        }

        private async void OnSaveButton_Clicked(object sender, EventArgs e)
        {
            Affair affair = (Affair)BindingContext;

            affair.Date = DateTime.UtcNow;

            if (!string.IsNullOrWhiteSpace(affair.affair_name))
            {
                await App.DatBasDB.SaveAffairAsync(affair);
            }

            await Shell.Current.GoToAsync("..");
        }

        private async void OnDeleteButton_Clicked(object sender, EventArgs e)
        {
            Affair affair = (Affair)BindingContext;

            await App.DatBasDB.DeleteAffairAsync(affair);

            await Shell.Current.GoToAsync("..");
        }

        private void PlaceTriggerButton_Clicked(object sender, EventArgs e)
        {
            coord_editor.IsVisible = true;
        }

        //private async void NotificationButton_Clicked(object sender, EventArgs e)
        //{
        //    System.Threading.Thread.Sleep(10000);
        //    await DisplayAlert("Уведомление", "Тест", "Ок");
        //}
    }
}