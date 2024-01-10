namespace SztuderWiniecki.BikesApp.Interfaces
{
    public interface IProducer
    {
        int Id { get; set; }
        string Name { get; set; }
        string Address { get; set; }


        IProducer CopyFrom(IProducer producer)
        {
            Id = producer.Id;
            Name = producer.Name;
            Address = producer.Address;

            return this;
        }
    }
}