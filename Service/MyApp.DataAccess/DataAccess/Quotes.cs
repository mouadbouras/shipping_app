using System;
using System.Collections.Generic;

namespace MyApp.DataAccess.DataAccess
{
    public partial class Quotes
    {
        public int? ClientId { get; set; }
        public int? FromId { get; set; }
        public int? ToId { get; set; }
        public int? ParcelId { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Amount { get; set; }
        public string Currency { get; set; }
        public string Provider { get; set; }
        public string ServiceLevel { get; set; }
        public string Estimate { get; set; }
        public int Id { get; set; }
    }
}
