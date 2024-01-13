﻿using CommunityToolkit.Mvvm.ComponentModel;
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
    public partial class ProducerCreateViewModel : ObservableObject
    {
        [ObservableProperty]
        private ProducerViewModel? newProducer;

        BLC.BLC blc = BLC.BLC.GetInstance();

        public ProducerCreateViewModel()
        {
            NewProducer = new ProducerViewModel(blc.CreateProducer());
            NewProducer.PropertyChanged += OnProducerPropertyChanged;
        }

        [RelayCommand]
        public async void Cancel()
        {
            await Shell.Current.GoToAsync("///ProducersIndex");
        }

        [RelayCommand(CanExecute = nameof(CanSave))]
        public void Save()
        {
            IProducer daoProducer = blc.CreateProducer().CopyFrom(NewProducer);
            blc.AddProducer(daoProducer);
            blc.SaveChanges();
            NewProducer.PropertyChanged -= OnProducerPropertyChanged;

            NewProducer = new ProducerViewModel(blc.CreateProducer());
            NewProducer.PropertyChanged += OnProducerPropertyChanged;

            RefreshCanExecute();
        }

        private bool CanSave()
        {
            return !string.IsNullOrWhiteSpace(NewProducer.Name) && !string.IsNullOrWhiteSpace(NewProducer.Address);
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
    }
}
