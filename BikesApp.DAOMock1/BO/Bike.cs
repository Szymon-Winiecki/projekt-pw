using BikesApp.Core;
using BikesApp.Interfaces;

namespace BikesApp.DAOMock1.BO
{
    public class Bike : IBike
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IProducer Producer { get; set; }
        public int ReleaseYear { get; set; }
        public BikeType Type { get; set; }
    }
}
