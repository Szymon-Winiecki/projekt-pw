using SztuderWiniecki.BikesApp.Interfaces;
using System.Reflection;

namespace SztuderWiniecki.BikesApp.BLC
{
    public class BLC
    {
        private IDAO dao;

        public BLC(string libraryName)
        {
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

        public static IEnumerable<Type> GetLoadableTypes(Assembly assembly)
        {
            if (assembly == null) throw new ArgumentNullException(nameof(assembly));
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                return e.Types.Where(t => t != null);
            }
        }

        public IEnumerable<IProducer> GetProducers() 
        {
            return dao.GetAllProducers();
        }

        public IEnumerable<IBike> GetBikes() 
        {
            return dao.GetAllBikes();
        }

        public IBike? GetBike(int ID) 
        {
            return dao.GetBike(ID);
        }
    }
}