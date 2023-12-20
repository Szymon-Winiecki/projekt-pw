namespace SztuderWiniecki.BikesApp.Interfaces
{
    public interface IProducer
    {
        int ID { get; set; }
        string Name { get; set; }
        string Adress { get; set; }


        IProducer CopyFrom(IProducer producer)
        {
            ID = producer.ID;
            Name = producer.Name;
            Adress = producer.Adress;

            return this;
        }
    }
}