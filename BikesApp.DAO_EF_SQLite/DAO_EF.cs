using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SztuderWiniecki.BikesApp.Core;
using SztuderWiniecki.BikesApp.Interfaces;

namespace SztuderWiniecki.BikesApp.DAO_EF_SQLite
{
    public class DAO_EF : IDAO
    {

        DataContext db;

        public DAO_EF() 
        {
            db = new DataContext();

            if (!db.Producers.Any())
            {
                db.Producers.Add(new BO.Producer() { ID = 1, Name = "SQLite Producer 1", Adress = "Lorem ipsum" });
                db.Producers.Add(new BO.Producer() { ID = 2, Name = "SQLite Producer 2", Adress = "Lorem ipsum" });
                db.SaveChanges();
            }

            if (!db.Bikes.Any())
            {
                var producers = db.Producers.ToList();

                db.Bikes.Add(new BO.Bike() { ID = 1, Producer = producers[0], Name = "SQLte Bike 1.0", ReleaseYear = 2020, Type = BikeType.Gravel });
                db.Bikes.Add(new BO.Bike() { ID = 2, Producer = producers[1], Name = "SQLte Bike 2.0", ReleaseYear = 2023, Type = BikeType.City });
                db.Bikes.Add(new BO.Bike() { ID = 3, Producer = producers[0], Name = "SQLte Bike 3.0", ReleaseYear = 1998, Type = BikeType.Folding });
                db.SaveChanges();
            }
        }

        public IBike CreateNewBike()
        {
            throw new NotImplementedException();
        }

        public IProducer CreateNewProducer()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IBike> GetAllBikes()
        {
            return db.Bikes;
        }

        public IEnumerable<IProducer> GetAllProducers()
        {
            return db.Producers;
        }
    }
}
