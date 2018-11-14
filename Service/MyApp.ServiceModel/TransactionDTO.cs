

namespace MyApp.ServiceModel
{
    using ServiceStack;
    using MyApp.Model;
    using MyApp.DataAccess.DataAccess;


    [Route("/transaction" , "POST")]
    public class TransactionDTO :  IReturn<TransactionDTOResponse>
    {        

        public string UserId {get;set;}
        public string QuoteId {get;set;}
        public string RateId {get;set;}    }

    public class TransactionDTOResponse
    {
        public ShippmentUnit from {get;set;}
        public ShippmentUnit to {get;set;}
        public MyApp.DataAccess.DataAccess.Parcel parcel {get;set;}
        public Orders order {get;set;}      }
}
