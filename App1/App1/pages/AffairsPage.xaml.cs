using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AffairNamesps;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1;

namespace App1.pages
{
    public partial class AffairsPage : ContentPage
    {
        public AffairsPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            collectionView.ItemsSource = await App.DatBasDB.GetAffairsAsync();

            base.OnAppearing();
        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(AffairAddingPage));
        }

        private async void PositionButton_Clicked(object sender, EventArgs e)
        {
            var position = await FindPosition.FindMyPosition();
            tlbPosition.Text = position;
        }

        private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(e.CurrentSelection != null)
            {
                Affair affair = (Affair)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync(
                    $"{nameof(AffairAddingPage)}?{nameof(AffairAddingPage.ItemId)}={affair.Id.ToString()}");
            }
        }
    }
}