using System;
using System.Collections.Generic;

namespace MyApp.DataAccess.DataAccess
{
    public partial class Parcel
    {
        public decimal? Width { get; set; }
        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }
        public int Id { get; set; }
        public string DistanceUnit { get; set; }
        public string MassUnit { get; set; }
        public decimal? Length { get; set; }
    }
}
