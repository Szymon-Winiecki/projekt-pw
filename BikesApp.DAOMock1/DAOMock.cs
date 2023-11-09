using BikesApp.Core;
using BikesApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikesApp.DAOMock1
{
    public class DAOMock : IDAO
    {
        private List<IProducer> producers;
        private List<IBike> bikes;

        public DAOMock() 
        {
            producers = new List<IProducer>()
            {
                new BO.Producer() {ID=1, Name="Giant"},
                new BO.Producer() {ID=2, Name="B'Twin"},
                new BO.Producer() {ID=3, Name="Romet"}
            };

            bikes = new List<IBike>()
            {
                new BO.Bike() {ID=1, Producer=producers[0], Name="Propel Advanced SL", ReleaseYear=2018, Type=BikeType.Road},
                new BO.Bike() {ID=2, Producer=producers[1], Name="Rockrider ST 540", ReleaseYear=2017, Type=BikeType.Mountain},
                new BO.Bike() {ID=3, Producer=producers[2], Name="ASPRE 1", ReleaseYear=2022, Type=BikeType.Gravel}
            };
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
    }
}
