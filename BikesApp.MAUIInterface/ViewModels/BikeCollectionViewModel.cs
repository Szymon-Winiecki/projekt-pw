using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SztuderWiniecki.BikesApp.BLC;

namespace SztuderWiniecki.BikesApp.MAUIInterface.ViewModels
{
    public partial class BikeCollectionViewModel: ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<BikeViewModel> bikes;

        BLC.BLC blc = BLC.BLC.GetInstance();

        public BikeCollectionViewModel() 
        {
            bikes = new ObservableCollection<BikeViewModel>();

            foreach (var bike in blc.GetBikes())
            {
                bikes.Add(new BikeViewModel(bike));
            }
        }

        [RelayCommand]
        private void Reload()
        {
            bikes.Clear();

            foreach (var bike in blc.GetBikes())
            {
                bikes.Add(new BikeViewModel(bike));
            }
        }

        [RelayCommand]
        private async void CreateNewBike(BikeViewModel bike)
        {
            //await Shell.Current.GoToAsync(nameof(BikeCreatePage));
        }
    }
}
