using BikesApp.MAUIInterface;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SztuderWiniecki.BikesApp.Interfaces;


namespace SztuderWiniecki.BikesApp.MAUIInterface.ViewModels
{
    public partial class ProducerViewModel : ObservableObject, IProducer
    {
        [ObservableProperty]
        private int id;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string address;

        public ProducerViewModel(IProducer producer)
        {
            Id = producer.Id;
            Name = producer.Name;
            Address = producer.Address;
        }

        public ProducerViewModel()
        {
            
        }

        [RelayCommand]
        private async void ShowDetails()
        {
            var query = new ShellNavigationQueryParameters
            {
                { "id", Id }
            };
            await Shell.Current.GoToAsync(nameof(ProducerDetailsPage), query);
        }

        [RelayCommand]
        private async void EditProducer()
        {
            var query = new ShellNavigationQueryParameters
            {
                { "id", Id }
            };
            await Shell.Current.GoToAsync(nameof(ProducerEditPage), query);
        }

        [RelayCommand]
        private async void DeleteProducer()
        {
            var query = new ShellNavigationQueryParameters
            {
                { "id", Id }
            };
            await Shell.Current.GoToAsync(nameof(ProducerDeletePage), query);
        }
    }
}
