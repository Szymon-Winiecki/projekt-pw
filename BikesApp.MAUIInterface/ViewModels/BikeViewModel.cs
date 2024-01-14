using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SztuderWiniecki.BikesApp.Core;
using SztuderWiniecki.BikesApp.Interfaces;

namespace SztuderWiniecki.BikesApp.MAUIInterface.ViewModels
{
    public partial class BikeViewModel : ObservableObject, IBike
    {
        [ObservableProperty]
        private int id;
        [ObservableProperty]
        private string name;
        [ObservableProperty]
        private IProducer producer;
        [ObservableProperty]
        private int releaseYear;
        [ObservableProperty]
        private BikeType type;

        public BikeViewModel(IBike bike)
        {
            Id = bike.Id;
            Name = bike.Name;
            Producer = bike.Producer;
            ReleaseYear = bike.ReleaseYear;
            Type = bike.Type;
        }

        public BikeViewModel()
        {

        }

        [RelayCommand]
        private async void ShowDetails(int id)
        {
            System.Diagnostics.Debug.WriteLine($"ShowDetails({id})");
            var query = new ShellNavigationQueryParameters
            {
                { "id", id }
            };
            //await Shell.Current.GoToAsync(nameof(BikeDetailsPage), query);
        }
    }
}
