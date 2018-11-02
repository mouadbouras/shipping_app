

namespace MyApp.ServiceModel
{
    using ServiceStack;
    using MyApp.Model;

    [Route("/qote" , "POST")]
    public class QuoteDTO : IReturn<QuoteDTOResponse>
    {      
        public string UserId = "";
        public string QuoteId = "";

    }

    public class QuoteDTOResponse
    {
        public string response = "";
    }
}
