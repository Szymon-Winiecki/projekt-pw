using BikesApp.Interfaces;

namespace BikesApp.DAOMock1.BO
{
    public class Producer : IProducer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
    }
}