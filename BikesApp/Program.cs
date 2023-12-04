using SztuderWiniecki.BikesApp.BLC;
using SztuderWiniecki.BikesApp.Interfaces;

namespace SztuderWiniecki.BikesApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            string libraryName = System.Configuration.ConfigurationManager.AppSettings["DAOLibraryName"];
            BLC.BLC blc = new BLC.BLC(libraryName);

            foreach(IProducer p in blc.GetProducers()) 
            {
                Console.WriteLine($"{p.ID}: {p.Name}");
            }

            Console.WriteLine("------------------------------");

            foreach (IBike b in blc.GetBikes())
            {
                Console.WriteLine($"{b.ID}: {b.Producer.Name} {b.Name} {b.ReleaseYear} {b.Type}");
            }
        }
    }
}