﻿using Microsoft.EntityFrameworkCore;
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
                db.Producers.Add(new BO.Producer() { Name = "Haibike", Address = "Akacjowa 2" });
                db.Producers.Add(new BO.Producer() { Name = "Winora", Address = "Różana 7" });
                db.Producers.Add(new BO.Producer() { Name = "Romet", Address = "Krokusowa 12/3" });
                db.SaveChanges();
            }

            if (!db.Bikes.Any())
            {
                var producers = db.Producers.ToList();

                db.Bikes.Add(new BO.Bike() { Producer = producers[0], Name = "Tria 7", ReleaseYear = 2020, Type = BikeType.Mountain });
                db.Bikes.Add(new BO.Bike() { Producer = producers[1], Name = "E_Flitzer", ReleaseYear = 2023, Type = BikeType.Folding });
                db.Bikes.Add(new BO.Bike() { Producer = producers[2], Name = "Monsun", ReleaseYear = 1998, Type = BikeType.Mountain });
                db.Bikes.Add(new BO.Bike() { Producer = producers[2], Name = "Gazela", ReleaseYear = 2017, Type = BikeType.City });
                db.Bikes.Add(new BO.Bike() { Producer = producers[2], Name = "Rombler", ReleaseYear = 2014, Type = BikeType.Gravel });
                db.SaveChanges();
            }
        }

        public IEnumerable<IProducer> GetAllProducers()
        {
            return db.Producers;
        }
        public IProducer? GetProducer(int ID)
        {
            return db.Producers.FirstOrDefault(p => p.Id == ID);
        }
        public IProducer CreateNewProducer()
        {
            return new BO.Producer();
        }
        public IProducer? UpdateProducer(IProducer producer)
        {
            BO.Producer? dbProducer = producer as BO.Producer;
            if(dbProducer == null)
            {
                System.Diagnostics.Debug.WriteLine("UpdateProducer: producer is not of type BO.Producer");
                return null ;
            }
            return db.Producers.Update(dbProducer).Entity;
        }
        public IProducer? RemoveProducer(int ID)
        {
            return db.Producers.Remove(db.Producers.Find(ID)).Entity;
        }

        public IProducer? AddProducer(IProducer producer)
        {
            BO.Producer? dbProducer = producer as BO.Producer;
            if (dbProducer == null)
            {
                System.Diagnostics.Debug.WriteLine("AddProducer: producer is not of type BO.Producer");
                return null;
            }
            return db.Producers.Add(dbProducer).Entity;
        }

        public IEnumerable<IBike> GetAllBikes()
        {
            return db.Bikes.Include(b => b._producer);
        }
        public IBike? GetBike(int ID)
        {
            return db.Bikes.Include(b => b._producer).FirstOrDefault(b => b.Id == ID);
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
            return db.Bikes.Update(dbBike).Entity;
        }
        public IBike? RemoveBike(int ID)
        {
            return db.Bikes.Remove(db.Bikes.Find(ID)).Entity;
        }

        public IBike? AddBike(IBike bike)
        {
            BO.Bike? dbBike = bike as BO.Bike;
            if (dbBike == null)
            {
                System.Diagnostics.Debug.WriteLine("AddBike: bike is not of type BO.Bike");
                return null;
            }
            return db.Bikes.Add(dbBike).Entity;
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

       

        
    }
}
