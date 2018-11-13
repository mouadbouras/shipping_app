

namespace MyApp.ServiceModel
{
    using ServiceStack;
    using MyApp.Model;
    using MyApp.DataAccess.DataAccess;

    [Route("/quote" , "POST")]
    public class QuoteDTO : IReturn<QuoteDTOResponse>
    {      
        public string UserId {get;set;}
        public string QuoteId {get;set;}
        public string RateId {get;set;}

    }

    public class QuoteDTOResponse
    {
        public ShippmentUnit from {get;set;}
        public ShippmentUnit to {get;set;}
        public MyApp.DataAccess.DataAccess.Parcel parcel {get;set;}
        public Quotes quote {get;set;}    
    }

}
