using BikesApp.Interfaces;
using System.Reflection;

namespace BikesApp.BLC
{
    public class BLC
    {
        private IDAO dao;

        public BLC(string libraryName)
        {
            Type? typeToCreate = null;

            Assembly assembly = Assembly.UnsafeLoadFrom(libraryName);

            foreach(Type type in assembly.GetTypes()) 
            {
                if (type.IsAssignableTo(typeof(IDAO)))
                {
                    typeToCreate = type;
                    break;
                }
            }

            dao = (IDAO)Activator.CreateInstance(typeToCreate, null);
        }

        public IEnumerable<IProducer> GetProducers() 
        {
            return dao.GetAllProducers();
        }

        public IEnumerable<IBike> GetBikes() 
        {
            return dao.GetAllBikes();
        }
    }
}