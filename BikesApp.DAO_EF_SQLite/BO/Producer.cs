using SztuderWiniecki.BikesApp.Interfaces;

namespace SztuderWiniecki.BikesApp.DAO_EF_SQLite.BO
{
    public class Producer : IProducer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
    }
}