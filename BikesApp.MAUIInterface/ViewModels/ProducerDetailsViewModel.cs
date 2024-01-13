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
    public partial class ProducerDetailsViewModel : ObservableObject, IQueryAttributable
    {
        [ObservableProperty]
        private ProducerViewModel? producer;

        BLC.BLC blc = BLC.BLC.GetInstance();

        public ProducerDetailsViewModel()
        {
            
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            int? producerId = query["id"] as int?;

            if(producerId != null)
            {
                Producer = new ProducerViewModel(blc.GetProducer((int)producerId));
            }
            else
            {
                Producer = null;
            }

        }

        [RelayCommand]
        public async void Back()
        {
            await Shell.Current.GoToAsync("///ProducersIndex");
        }

    }
}
