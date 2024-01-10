using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SztuderWiniecki.BikesApp.BLC;

namespace SztuderWiniecki.BikesApp.MAUIInterface.ViewModels
{
    public partial class ProducersCollectionViewModel: ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<ProducerViewModel> producers;

        BLC.BLC blc = BLC.BLC.GetInstance();

        public ProducersCollectionViewModel()
        {
            producers = new ObservableCollection<ProducerViewModel>();

            foreach (var producer in blc.GetProducers())
            {
                producers.Add(new ProducerViewModel(producer));
            }
        }
    }
}
