using BikesApp.Interfaces;

namespace BikesApp.DAOMock2.BO
{
    public class Producer : IProducer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
    }
}