using SztuderWiniecki.BikesApp.Interfaces;

namespace SztuderWiniecki.BikesApp.WebInterface.ProxyModels
{
    public class ProxyProducer: IProducer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
