using SztuderWiniecki.BikesApp.Core;
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
            bikes.Add(bike);
            int lastId = bikes.Max(b => b.Id);  
            bike.Id = lastId + 1;
            return bike;
        }

        public IProducer? AddProducer(IProducer producer)
        {
            producers.Add(producer);
            int lastId = producers.Max(p => p.Id);
            producer.Id = lastId + 1;
            return producer;
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
            return bikes.FirstOrDefault(b => b.Id == ID);
        }

        public IProducer? GetProducer(int ID)
        {
            return producers.FirstOrDefault(p => p.Id == ID);
        }

        public IBike? RemoveBike(int ID)
        {
            IBike? bikeToRemove = bikes.FirstOrDefault(b => b.Id == ID);
            if(bikeToRemove == null)
            {
                return null;
            }
            bikes.Remove(bikeToRemove);
            return bikeToRemove;
        }

        public IProducer? RemoveProducer(int ID)
        {
            IProducer? producerToRemove = producers.FirstOrDefault(p => p.Id == ID);
            if (producerToRemove == null)
            {
                return null;
            }
            producers.Remove(producerToRemove);
            return producerToRemove;
        }

        public IBike? UpdateBike(IBike bike)
        {
            IBike? bikeToUpdate = bikes.FirstOrDefault(b => b.Id == bike.Id);
            if(bikeToUpdate == null)
            {
                return null;
            }
            bikeToUpdate.CopyFrom(bike);
            return bikeToUpdate;
        }

        public IProducer? UpdateProducer(IProducer producer)
        {
            IProducer? producerToUpdate = producers.FirstOrDefault(p => p.Id == producer.Id);
            if (producerToUpdate == null)
            {
                return null;
            }
            producerToUpdate.CopyFrom(producer);
            return producerToUpdate;
        }

        public void SaveChanges()
        {
            return;
        }
    }
}
