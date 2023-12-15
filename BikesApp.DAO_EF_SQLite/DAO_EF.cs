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
                db.Producers.Add(new BO.Producer() { Name = "SQLite Producer 1", Adress = "Lorem ipsum" });
                db.Producers.Add(new BO.Producer() { Name = "SQLite Producer 2", Adress = "Lorem ipsum" });
                db.SaveChanges();
            }

            if (!db.Bikes.Any())
            {
                var producers = db.Producers.ToList();

                db.Bikes.Add(new BO.Bike() { Producer = producers[0], Name = "SQLte Bike 1.0", ReleaseYear = 2020, Type = BikeType.Gravel });
                db.Bikes.Add(new BO.Bike() { Producer = producers[1], Name = "SQLte Bike 2.0", ReleaseYear = 2023, Type = BikeType.City });
                db.Bikes.Add(new BO.Bike() { Producer = producers[0], Name = "SQLte Bike 3.0", ReleaseYear = 1998, Type = BikeType.Folding });
                db.SaveChanges();
            }
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
            return db.Bikes;
        }

        public IEnumerable<IProducer> GetAllProducers()
        {
            return db.Producers;
        }

        public IBike? GetBike(int ID)
        {
            return db.Bikes.First(b => b.ID == ID);
        }
    }
}
