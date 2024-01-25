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
    public partial class ProducerDeleteViewModel : ObservableObject, IQueryAttributable
    {
        [ObservableProperty]
        private ProducerViewModel? producer;

        BLC.BLC blc = BLC.BLC.GetInstance();

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            int? producerId = query["id"] as int?;

            if (producerId != null)
            {
                Producer = new ProducerViewModel(blc.GetProducer((int)producerId));
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

        [RelayCommand(CanExecute = nameof(CanDelete))]
        public void Delete()
        {
            blc.RemoveProducer(Producer.Id);
            blc.SaveChanges();

            RefreshCanExecute();

            ReturnToPreviousPage();
        }

        private bool CanDelete()
        {
            return Producer != null;
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
