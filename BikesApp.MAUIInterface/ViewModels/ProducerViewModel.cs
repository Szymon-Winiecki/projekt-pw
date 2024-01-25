using BikesApp.MAUIInterface;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SztuderWiniecki.BikesApp.Interfaces;


namespace SztuderWiniecki.BikesApp.MAUIInterface.ViewModels
{
    public partial class ProducerViewModel : ObservableValidator, IProducer
    {
        [ObservableProperty]
        private int id;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Name is required.")]
        [MinLength(3, ErrorMessage = "Name must be at least 2 characters long.")]
        private string name;

        [ObservableProperty]
        string nameErrors = "";

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Address is required.")]
        [MinLength(2, ErrorMessage = "Address must be at least 3 characters long.")]
        private string address;

        [ObservableProperty]
        string addressErrors = "";

        public ProducerViewModel(IProducer producer) : this()
        {
            Id = producer.Id;
            Name = producer.Name;
            Address = producer.Address;
        }

        public ProducerViewModel()
        {
            Name = "";
            Address = "";
            ErrorsChanged += OnProducerErrorsChanged;
        }

        ~ProducerViewModel()
        {
            ErrorsChanged -= OnProducerErrorsChanged;
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

        private void OnProducerErrorsChanged(object? sender, DataErrorsChangedEventArgs e)
        { 
            var errors = GetErrors(e.PropertyName);
            string errorsString = string.Join(", ", errors);
            
            if(e.PropertyName == nameof(Name))
            {
                NameErrors = errorsString;
            }
            else if(e.PropertyName == nameof(Address))
            {
                AddressErrors = errorsString;
            }
        }
    }
}
