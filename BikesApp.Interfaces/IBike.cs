using BikesApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikesApp.Interfaces
{
    public interface IBike
    {
        int ID { get; set;  }
        string Name { get; set; }
        IProducer Producer { get; set; }
        int ReleaseYear {  get; set; }

        BikeType Type { get; set; }
    }
}
