using SztuderWiniecki.BikesApp.Interfaces;
using System.Reflection;

namespace SztuderWiniecki.BikesApp.BLC
{
    public class BLC
    {
        private static BLC? instance;

        private IDAO dao;

        private BLC()
        {
            string libraryName = System.Configuration.ConfigurationManager.AppSettings["DAOLibraryName"];

            Type? typeToCreate = null;

            Assembly assembly = Assembly.UnsafeLoadFrom(libraryName);

            foreach (Type type in assembly.GetTypes()) 
            {
                if (type.IsAssignableTo(typeof(IDAO)))
                {
                    typeToCreate = type;
                    break;
                }
            }

            dao = (IDAO)Activator.CreateInstance(typeToCreate, null);
        }

        public static BLC GetInstance()
        {
            if (instance == null)
            {
                instance = new BLC();
            }

            return instance;
        }

        public void SaveChanges()
        {
            dao.SaveChanges();
        }

        public IEnumerable<IProducer> GetProducers() 
        {
            return dao.GetAllProducers();
        }

        public IProducer? GetProducer(int ID)
        {
            return dao.GetProducer(ID);
        }

        public IProducer CreateProducer()
        {
            return dao.CreateNewProducer();
        }

        public IProducer? UpdateProducer(IProducer producer)
        {
            return dao.UpdateProducer(producer);
        }

        public IProducer? RemoveProducer(int ID)
        {
            return dao.RemoveProducer(ID);
        }

        public IProducer? AddProducer(IProducer producer)
        {
            return dao.AddProducer(producer);
        }

        public IEnumerable<IBike> GetBikes()
        {
            return dao.GetAllBikes();
        }

        public IBike? GetBike(int ID) 
        {
            return dao.GetBike(ID);
        }

        public IBike? RemoveBike(int ID)
        {
            return dao.RemoveBike(ID);
        }

        public IBike CreateBike()
        {
            return dao.CreateNewBike();
        }

        public IBike? UpdateBike(IBike bike) 
        {
            return dao.UpdateBike(bike);
        }

        public IBike? AddBike(IBike bike)
        {
            return dao.AddBike(bike);
        }
    }
}