using SztuderWiniecki.BikesApp.BLC;
using SztuderWiniecki.BikesApp.Interfaces;

namespace SztuderWiniecki.BikesApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            BLC.BLC blc = BLC.BLC.GetInstance();

            foreach(IProducer p in blc.GetProducers()) 
            {
                Console.WriteLine($"{p.Id}: {p.Name}");
            }

            Console.WriteLine("------------------------------");

            foreach (IBike b in blc.GetBikes())
            {
                Console.WriteLine($"{b.Id}: {b.Producer.Name} {b.Name} {b.ReleaseYear} {b.Type}");
            }
        }
    }
}