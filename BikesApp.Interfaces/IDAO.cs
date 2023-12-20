using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SztuderWiniecki.BikesApp.Interfaces
{
    public interface IDAO
    {
        IEnumerable<IProducer> GetAllProducers();
        IProducer? GetProducer(int ID);
        IProducer CreateNewProducer();
        IProducer? UpdateProducer(IProducer producer);
        IProducer? RemoveProducer(int ID);
        IProducer? AddProducer(IProducer producer);

        IEnumerable<IBike> GetAllBikes();
        IBike? GetBike(int ID);
        IBike CreateNewBike();
        IBike? UpdateBike(IBike bike);
        IBike? RemoveBike(int ID);
        IBike? AddBike(IBike bike);

        void SaveChanges();
    }
}
