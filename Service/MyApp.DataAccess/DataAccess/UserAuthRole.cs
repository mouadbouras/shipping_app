using System;
using System.Collections.Generic;

namespace MyApp.DataAccess.DataAccess
{
    public partial class UserAuthRole
    {
        public int Id { get; set; }
        public int UserAuthId { get; set; }
        public string Role { get; set; }
        public string Permission { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int? RefId { get; set; }
        public string RefIdStr { get; set; }
        public string Meta { get; set; }
    }
}
