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
    public partial class BikeEditViewModel : ObservableObject, IQueryAttributable
    {
        [ObservableProperty]
        public ObservableCollection<string> types;

        [ObservableProperty]
        public ObservableCollection<ProducerViewModel> producers;

        [ObservableProperty]
        private BikeViewModel? bike;

        BLC.BLC blc = BLC.BLC.GetInstance();

        public BikeEditViewModel()
        {
            Types = new ObservableCollection<string>(Enum.GetNames(typeof(BikeType)));

            Producers = new ObservableCollection<ProducerViewModel>();

            foreach (var producer in blc.GetProducers())
            {
                producers.Add(new ProducerViewModel(producer));
            }
            
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            int? bikeId = query["id"] as int?;

            if (bikeId != null)
            {
                Bike = new BikeViewModel(blc.GetBike((int)bikeId));
                Bike.Producer = Producers.Where(p => p.Id == Bike.Producer.Id).First();
                Bike.PropertyChanged += OnBikePropertyChanged;
            }
            else
            {
                Bike = null;
            }

        }

        [RelayCommand]
        public async void Cancel()
        {
            await Shell.Current.GoToAsync("///BikesIndex");
        }

        [RelayCommand(CanExecute = nameof(CanSave))]
        public void Save()
        {
            IBike daoBike = blc.GetBike(Bike.Id).CopyFrom(Bike);
            daoBike.Producer = blc.GetProducer(Bike.Producer.Id);
            blc.UpdateBike(daoBike);
            blc.SaveChanges();

            RefreshCanExecute();
        }

        private bool CanSave()
        {
            return !string.IsNullOrWhiteSpace(Bike?.Name) && Bike.ReleaseYear > 1700;
        }

        private void OnBikePropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            SaveCommand.NotifyCanExecuteChanged();
        }

        private void RefreshCanExecute()
        {
            SaveCommand.NotifyCanExecuteChanged();
            CancelCommand.NotifyCanExecuteChanged();
        }
    }
}
