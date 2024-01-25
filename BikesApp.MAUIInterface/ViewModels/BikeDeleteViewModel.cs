using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SztuderWiniecki.BikesApp.BLC;
using SztuderWiniecki.BikesApp.Core;
using SztuderWiniecki.BikesApp.Interfaces;
using SztuderWiniecki.BikesApp.MAUIInterface.ViewModels;

namespace SztuderWiniecki.BikesApp.MAUIInterface.ViewModels
{
    public partial class BikeDeleteViewModel : ObservableObject, IQueryAttributable
    {
        [ObservableProperty]
        private BikeViewModel? bike;

        BLC.BLC blc = BLC.BLC.GetInstance();

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            int? bikeId = query["id"] as int?;

            if (bikeId != null)
            {
                Bike = new BikeViewModel(blc.GetBike((int)bikeId));
            }
            else
            {
                Bike = null;
            }

        }

        [RelayCommand]
        public void Cancel()
        {
            ReturnToPreviousPage();
        }

        [RelayCommand(CanExecute = nameof(CanDelete))]
        public void Delete()
        {
            blc.RemoveBike(Bike.Id);
            blc.SaveChanges();

            RefreshCanExecute();

            ReturnToPreviousPage();
        }

        private bool CanDelete()
        {
            return Bike != null;
        }

        private void OnBikePropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            DeleteCommand.NotifyCanExecuteChanged();
        }

        private void RefreshCanExecute()
        {
            DeleteCommand.NotifyCanExecuteChanged();
            CancelCommand.NotifyCanExecuteChanged();
        }

        private async void ReturnToPreviousPage()
        {
            await Shell.Current.Navigation.PopAsync();
        }
    }
}
