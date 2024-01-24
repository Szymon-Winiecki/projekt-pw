using BikesApp.MAUIInterface;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SztuderWiniecki.BikesApp.BLC;
using SztuderWiniecki.BikesApp.Core;
using SztuderWiniecki.BikesApp.Interfaces;

namespace SztuderWiniecki.BikesApp.MAUIInterface.ViewModels
{
    public partial class BikeCollectionViewModel: ObservableObject
    {
        static string AllTypesValue = "All";

        [ObservableProperty]
        ObservableCollection<BikeViewModel> bikes;

        BLC.BLC blc = BLC.BLC.GetInstance();

        [ObservableProperty]
        public ObservableCollection<string> types;

        [ObservableProperty]
        string searchString = "";
        [ObservableProperty]
        int yearFrom = -1;
        [ObservableProperty]
        int yearTo = -1;
        [ObservableProperty]
        string selectedType = AllTypesValue;

        public BikeCollectionViewModel() 
        {
            bikes = new ObservableCollection<BikeViewModel>();

            foreach (var bike in blc.GetBikes())
            {
                bikes.Add(new BikeViewModel(bike));
            }


            List<string> types = Enum.GetNames(typeof(BikeType)).ToList();
            types.Insert(0, AllTypesValue);
            Types = new ObservableCollection<string>(types);
        }

        [RelayCommand]
        private void Search()
        {
            //write a code that will print SelectedType in output debug window
            System.Diagnostics.Debug.WriteLine(SelectedType);

            bikes.Clear();

            IEnumerable<IBike> daoBikes = blc.GetBikes();
            if(SearchString != "")
            {
                daoBikes = daoBikes.Where(b => b.Name.Contains(SearchString) || b.Producer.Name.Contains(SearchString));
            }
            if(YearFrom != -1)
            {
                daoBikes = daoBikes.Where(b => b.ReleaseYear >= YearFrom);
            }
            if(YearTo != -1)
            {
                daoBikes = daoBikes.Where(b => b.ReleaseYear <= YearTo);
            }
          

            if(selectedType != AllTypesValue)
            {
                bool isConverted = Enum.TryParse(selectedType, out BikeType SelectedTypeEnum);
                if (isConverted)
                {
                    daoBikes = daoBikes.Where(b => b.Type == SelectedTypeEnum);
                }
            }

            foreach (var bike in daoBikes)
            {
                bikes.Add(new BikeViewModel(bike));
            }
        }

        [RelayCommand]
        public void ResetFilters()
        {
            searchString = "";
            YearFrom = -1;
            YearTo = -1;
            SelectedType = AllTypesValue;

            Search();
        }

        [RelayCommand]
        private async void CreateNewBike(BikeViewModel bike)
        {
            await Shell.Current.GoToAsync(nameof(BikeCreatePage));
        }
    }
}
