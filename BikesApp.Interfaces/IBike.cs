using SztuderWiniecki.BikesApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SztuderWiniecki.BikesApp.Interfaces
{
    public interface IBike
    {
        int ID { get; set;  }
        string Name { get; set; }
        IProducer Producer { get; set; }
        int ReleaseYear {  get; set; }

        BikeType Type { get; set; }

        IBike CopyFrom(IBike bike)
        {
            ID = bike.ID;
            Name = bike.Name;
            Producer = bike.Producer;
            ReleaseYear = bike.ReleaseYear;
            Type = bike.Type;

            return this;
        }
    }
}
