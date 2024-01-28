using BikesApp.MAUIInterface;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SztuderWiniecki.BikesApp.Core;
using SztuderWiniecki.BikesApp.Interfaces;

namespace SztuderWiniecki.BikesApp.MAUIInterface.ViewModels
{
    public partial class BikeViewModel : ObservableValidator, IBike
    {
        [ObservableProperty]
        private int id;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Name is required.")]
        [MinLength(1, ErrorMessage = "Name must be at least 2 character long.")]
        private string name;

        [ObservableProperty]
        private string nameErrors = "";

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Producer is required.")]
        private IProducer producer;

        [ObservableProperty]
        private string producerErrors = "";

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Release year is required.")]
        [Range(1700, 2100, ErrorMessage = "Release year must be between 1700 and 2100.")]
        private int releaseYear;

        [ObservableProperty]
        private string releaseYearErrors = "";

        [ObservableProperty]
        private BikeType type;

        public BikeViewModel(IBike bike) : this()
        {
            Id = bike.Id;
            Name = bike.Name;
            Producer = bike.Producer;
            ReleaseYear = bike.ReleaseYear;
            Type = bike.Type;
        }

        public BikeViewModel()
        {
            Name = "";
            ReleaseYear = DateTime.Now.Year;
            Type = BikeType.City;
            ErrorsChanged += OnBikeErrorsChanged;
        }

        ~BikeViewModel()
        {
            ErrorsChanged -= OnBikeErrorsChanged;
        }

        [RelayCommand]
        private async void ShowDetails()
        {
            var query = new ShellNavigationQueryParameters
            {
                { "id", Id }
            };
            await Shell.Current.GoToAsync(nameof(BikeDetailsPage), query);
        }

        [RelayCommand]
        private async void EditBike()
        {
            var query = new ShellNavigationQueryParameters
            {
                { "id", Id }
            };
            await Shell.Current.GoToAsync(nameof(BikeEditPage), query);
        }

        [RelayCommand]
        private async void DeleteBike()
        {
            var query = new ShellNavigationQueryParameters
            {
                { "id", Id }
            };
            await Shell.Current.GoToAsync(nameof(BikeDeletePage), query);
        }

        private void OnBikeErrorsChanged(object? sender, DataErrorsChangedEventArgs e)
        {
            var errors = GetErrors(e.PropertyName);
            string errorsString = string.Join(", ", errors);

            if(e.PropertyName == nameof(Name))
            {
                NameErrors = errorsString;
            }
            else if(e.PropertyName == nameof(Producer))
            {
                ProducerErrors = errorsString;
            }
            else if(e.PropertyName == nameof(ReleaseYear))
            {
                ReleaseYearErrors = errorsString;
            }
        }
    }
}
