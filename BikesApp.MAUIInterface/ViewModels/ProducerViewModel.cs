using CommunityToolkit.Mvvm.ComponentModel;
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
    }
}
