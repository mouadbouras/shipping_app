using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Model
{
    public class Shipment
    {
        public Shipp From { get; set; }
        public Shipp To{ get; set; }
        public List<Parcel> Parcels { get; set; }
    }
}
