using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SztuderWiniecki.BikesApp.BLC;
using SztuderWiniecki.BikesApp.Interfaces;
using SztuderWiniecki.BikesApp.MAUIInterface.ViewModels;

namespace SztuderWiniecki.BikesApp.MAUIInterface.ViewModels
{
    public partial class BikeDetailsViewModel : ObservableObject, IQueryAttributable
    {
        [ObservableProperty]
        private BikeViewModel? bike;

        BLC.BLC blc = BLC.BLC.GetInstance();

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            int? bikeId = query["id"] as int?;

            if(bikeId != null)
            {
                Bike = new BikeViewModel(blc.GetBike((int)bikeId));
            }
            else
            {
                Bike = null;
            }

        }

        [RelayCommand]
        public async void Back()
        {
            await Shell.Current.GoToAsync("///BikesIndex");
        }

    }
}
