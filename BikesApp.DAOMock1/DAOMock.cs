﻿using SztuderWiniecki.BikesApp.Core;
using SztuderWiniecki.BikesApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SztuderWiniecki.BikesApp.DAOMock1
{
    public class DAOMock : IDAO
    {
        private List<IProducer> producers;
        private List<IBike> bikes;

        public DAOMock() 
        {
            producers = new List<IProducer>()
            {
                new BO.Producer() {Id=1, Name="Giant"},
                new BO.Producer() {Id=2, Name="B'Twin"},
                new BO.Producer() {Id=3, Name="Romet"}
            };

            bikes = new List<IBike>()
            {
                new BO.Bike() {Id=1, Producer=producers[0], Name="Propel Advanced SL", ReleaseYear=2018, Type=BikeType.Road},
                new BO.Bike() {Id=2, Producer=producers[1], Name="Rockrider ST 540", ReleaseYear=2017, Type=BikeType.Mountain},
                new BO.Bike() {Id=3, Producer=producers[2], Name="ASPRE 1", ReleaseYear=2022, Type=BikeType.Gravel}
            };
        }

        public IBike? AddBike(IBike bike)
        {
            throw new NotImplementedException();
        }

        public IProducer? AddProducer(IProducer producer)
        {
            throw new NotImplementedException();
        }

        public IBike CreateNewBike()
        {
            return new BO.Bike();
        }

        public IProducer CreateNewProducer()
        {
            return new BO.Producer();
        }

        public IEnumerable<IBike> GetAllBikes()
        {
            return bikes;
        }

        public IEnumerable<IProducer> GetAllProducers()
        {
            return producers;
        }

        public IBike? GetBike(int ID)
        {
            return bikes.First(b => b.Id == ID);
        }

        public IProducer? GetProducer(int ID)
        {
            throw new NotImplementedException();
        }

        public IBike? RemoveBike(int ID)
        {
            throw new NotImplementedException();
        }

        public IProducer? RemoveProducer(int ID)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public IBike? UpdateBike(IBike bike)
        {
            throw new NotImplementedException();
        }

        public IProducer? UpdateProducer(IProducer producer)
        {
            throw new NotImplementedException();
        }
    }
}
