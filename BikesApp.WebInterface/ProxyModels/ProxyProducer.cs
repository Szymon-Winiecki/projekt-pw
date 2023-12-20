using SztuderWiniecki.BikesApp.Interfaces;

namespace SztuderWiniecki.BikesApp.WebInterface.ProxyModels
{
    public class ProxyProducer: IProducer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
    }
}
