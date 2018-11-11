

namespace MyApp.ServiceModel
{
    using ServiceStack;
    using MyApp.Model;

    [Route("/quote" , "POST")]
    public class QuoteDTO : IReturn<QuoteDTOResponse>
    {      
        public string ClientId {get;set;}
        public string QuoteId {get;set;}
        public string RateId {get;set;}

    }

    public class QuoteDTOResponse
    {
        public string response = "";
    }
}
