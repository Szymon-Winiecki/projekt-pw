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
    public partial class ProducerEditViewModel : ObservableObject, IQueryAttributable
    {
        [ObservableProperty]
        private ProducerViewModel? producer;

        BLC.BLC blc = BLC.BLC.GetInstance();

        public ProducerEditViewModel()
        {
            
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            int? producerId = query["id"] as int?;

            if (producerId != null)
            {
                Producer = new ProducerViewModel(blc.GetProducer((int)producerId));
                Producer.PropertyChanged += OnProducerPropertyChanged;
            }
            else
            {
                Producer = null;
            }

        }

        [RelayCommand]
        public void Cancel()
        {
            ReturnToPreviousPage();
        }

        [RelayCommand(CanExecute = nameof(CanSave))]
        public void Save()
        {
            IProducer daoProducer = blc.GetProducer(Producer.Id).CopyFrom(Producer);
            blc.UpdateProducer(daoProducer);
            blc.SaveChanges();
            Producer.PropertyChanged -= OnProducerPropertyChanged;

            RefreshCanExecute();

            ReturnToPreviousPage();
        }

        private bool CanSave()
        {
            if (Producer == null)
            {
                return false;
            }

            return !Producer.GetErrors().Any();
        }

        private void OnProducerPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            SaveCommand.NotifyCanExecuteChanged();
        }

        private void RefreshCanExecute()
        {
            SaveCommand.NotifyCanExecuteChanged();
            CancelCommand.NotifyCanExecuteChanged();
        }

        private async void ReturnToPreviousPage()
        {
            await Shell.Current.Navigation.PopAsync();
        }
    }
}
