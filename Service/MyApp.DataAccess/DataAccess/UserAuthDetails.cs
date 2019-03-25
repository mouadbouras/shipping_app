using System;
using System.Collections.Generic;

namespace MyApp.DataAccess.DataAccess
{
    public partial class UserAuthDetails
    {
        public int Id { get; set; }
        public int UserAuthId { get; set; }
        public string Provider { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public string BirthDateRaw { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Culture { get; set; }
        public string Gender { get; set; }
        public string Language { get; set; }
        public string MailAddress { get; set; }
        public string Nickname { get; set; }
        public string PostalCode { get; set; }
        public string TimeZone { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiry { get; set; }
        public string RequestToken { get; set; }
        public string RequestTokenSecret { get; set; }
        public string Items { get; set; }
        public string AccessToken { get; set; }
        public string AccessTokenSecret { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int? RefId { get; set; }
        public string RefIdStr { get; set; }
        public string Meta { get; set; }
    }
}
