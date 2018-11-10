

namespace MyApp.ServiceModel
{
    using ServiceStack;
    using MyApp.Model;

    [Route("/transaction" , "POST")]
    public class TransactionDTO :  IReturn<TransactionDTOResponse>
    {        
        public string RateId {set;get;}
    }

    public class TransactionDTOResponse
    {
        public string response = "";
    }
}
