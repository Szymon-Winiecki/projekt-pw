using BikesApp.MAUIInterface;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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

            IsEditing = false;
            ProducerEdit = null;

            CancelCommand = new Command(
                execute: () =>
                {
                    ProducerEdit.PropertyChanged -= OnProducerEditPropertyChanged;
                    ProducerEdit = null;
                    IsEditing = false;
                    RefreshCanExecute();
                },
                canExecute: () => IsEditing
                );
        }

        [ObservableProperty]
        private ProducerViewModel? producerEdit;

        [ObservableProperty]
        private bool isEditing;


        [RelayCommand(CanExecute = nameof(CanCreateNewProducer))]
        private async void CreateNewProducer()
        {
            /*ProducerEdit = new ProducerViewModel();
            ProducerEdit.PropertyChanged += OnProducerEditPropertyChanged;
            IsEditing = true;
            RefreshCanExecute();*/
            await Shell.Current.GoToAsync(nameof(ProducerCreatePage));
        }

        [RelayCommand(CanExecute = nameof(CanSaveProducer))]
        private void SaveProducer()
        {
            Producers.Add(ProducerEdit);
            ProducerEdit.PropertyChanged -= OnProducerEditPropertyChanged;
            ProducerEdit = null;
            IsEditing = false;
            RefreshCanExecute();
        }

        public ICommand CancelCommand { get; set; }

        private bool CanCreateNewProducer()
        {
            return !IsEditing;
        }

        private bool CanSaveProducer()
        {
            return ProducerEdit != null &&
                ProducerEdit.Name != null &&
                ProducerEdit.Name.Length > 0 &&
                ProducerEdit.Address != null &&
                ProducerEdit.Address.Length > 2;
        }

        private void OnProducerEditPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            SaveProducerCommand.NotifyCanExecuteChanged();
        }

        private void RefreshCanExecute()
        {
            CreateNewProducerCommand.NotifyCanExecuteChanged();
            SaveProducerCommand.NotifyCanExecuteChanged();
            (CancelCommand as Command).ChangeCanExecute();
        }
    }
}
