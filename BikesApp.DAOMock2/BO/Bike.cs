using SztuderWiniecki.BikesApp.Core;
using SztuderWiniecki.BikesApp.Interfaces;

namespace SztuderWiniecki.BikesApp.DAOMock2.BO
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
