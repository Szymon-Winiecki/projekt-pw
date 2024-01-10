using SztuderWiniecki.BikesApp.Core;
using SztuderWiniecki.BikesApp.Interfaces;

namespace SztuderWiniecki.BikesApp.DAOMock2
{
    public class DAOMock : IDAO
    {
        private List<IProducer> producers;
        private List<IBike> bikes;

        public DAOMock()
        {
            producers = new List<IProducer>()
            {
                new BO.Producer() {Id=1, Name="Kross"},
                new BO.Producer() {Id=2, Name="Dallas Bike"}
            };

            bikes = new List<IBike>()
            {
                new BO.Bike() {Id=1, Producer=producers[0], Name="EARTH 3.0", ReleaseYear=2020, Type=BikeType.Mountain},
                new BO.Bike() {Id=2, Producer=producers[1], Name="Holland City 28", ReleaseYear=2015, Type=BikeType.City},
                new BO.Bike() {Id=3, Producer=producers[0], Name="TRANS 8.0", ReleaseYear=2023, Type=BikeType.Touring}
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
