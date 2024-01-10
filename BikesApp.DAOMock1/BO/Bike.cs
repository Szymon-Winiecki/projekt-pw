using SztuderWiniecki.BikesApp.Core;
using SztuderWiniecki.BikesApp.Interfaces;

namespace SztuderWiniecki.BikesApp.DAOMock1.BO
{
    public class Bike : IBike
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IProducer Producer { get; set; }
        public int ReleaseYear { get; set; }
        public BikeType Type { get; set; }
    }
}
