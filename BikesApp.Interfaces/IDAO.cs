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
        IEnumerable<IBike> GetAllBikes();
        IBike? GetBike(int ID);

        IProducer CreateNewProducer();
        IBike CreateNewBike();
    }
}
