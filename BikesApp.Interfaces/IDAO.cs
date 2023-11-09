using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikesApp.Interfaces
{
    public interface IDAO
    {
        IEnumerable<IProducer> GetAllProducers();
        IEnumerable<IBike> GetAllBikes();

        IProducer CreateNewProducer();
        IBike CreateNewBike();
    }
}
