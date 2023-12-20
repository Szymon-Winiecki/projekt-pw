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

        public IEnumerable<IProducer> GetAllProducers()
        {
            return db.Producers;
        }
        public IProducer? GetProducer(int ID)
        {
            return db.Producers.FirstOrDefault(p => p.ID == ID);
        }
        public IProducer CreateNewProducer()
        {
            return new BO.Producer();
        }
        public IProducer? UpdateProducer(IProducer producer)
        {
            // write a code to updat producer in db
            BO.Producer? dbProducer = producer as BO.Producer;
            if(dbProducer == null)
            {
                System.Diagnostics.Debug.WriteLine("UpdateProducer: producer is not of type BO.Producer");
                return null ;
            }
            System.Diagnostics.Debug.WriteLine("UpdateProducer: producer is of type BO.Producer");
            return db.Producers.Update(dbProducer).Entity;
        }
        public IProducer? RemoveProducer(int ID)
        {
            return (IProducer?)db.Producers.Remove(db.Producers.Find(ID)).Entity;
        }

        public IProducer? AddProducer(IProducer producer)
        {
            BO.Producer? dbProducer = producer as BO.Producer;
            if (dbProducer == null)
            {
                System.Diagnostics.Debug.WriteLine("AddProducer: producer is not of type BO.Producer");
                return null;
            }
            System.Diagnostics.Debug.WriteLine("AddProducer: producer is of type BO.Producer");
            return db.Producers.Add(dbProducer).Entity;
        }

        public IEnumerable<IBike> GetAllBikes()
        {
            return db.Bikes;
        }
        public IBike? GetBike(int ID)
        {
            return db.Bikes.FirstOrDefault(b => b.ID == ID);
        }
        public IBike CreateNewBike()
        {
            return new BO.Bike();
        }
        public IBike? UpdateBike(IBike bike)
        {
            BO.Bike? dbBike = bike as BO.Bike;
            if(dbBike == null)
            {
                System.Diagnostics.Debug.WriteLine("UpdateBike: bike is not of type BO.Bike");
                return null;
            }
            System.Diagnostics.Debug.WriteLine("UpdateBike: bike is of type BO.Bike");
            return db.Bikes.Update(dbBike).Entity;
        }
        public IBike? RemoveBike(int ID)
        {
            return (IBike?)db.Bikes.Remove(db.Bikes.Find(ID));
        }

        public IBike? AddBike(IBike bike)
        {
            BO.Bike? dbBike = bike as BO.Bike;
            if (dbBike == null)
            {
                System.Diagnostics.Debug.WriteLine("AddBike: bike is not of type BO.Bike");
                return null;
            }
            System.Diagnostics.Debug.WriteLine("AddBike: bike is of type BO.Bike");
            return db.Bikes.Add(dbBike).Entity;
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

       

        
    }
}
