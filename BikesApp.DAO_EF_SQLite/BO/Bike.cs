using System.ComponentModel.DataAnnotations.Schema;
using SztuderWiniecki.BikesApp.Core;
using SztuderWiniecki.BikesApp.Interfaces;

namespace SztuderWiniecki.BikesApp.DAO_EF_SQLite.BO
{
    public class Bike : IBike
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Producer _producer {  get; set; }
        [NotMapped]
        public IProducer Producer {
            get {
                return _producer;
            }
            set {
                _producer = value as Producer;
            }
        }
        public int ReleaseYear { get; set; }
        public BikeType Type { get; set; }
    }
}
