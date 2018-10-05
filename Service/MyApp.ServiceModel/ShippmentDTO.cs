

namespace MyApp.ServiceModel
{
    using ServiceStack;
    using MyApp.Model;

    [Route("/shipment" , "POST")]
    public class ShippmentDTO : Shipment , IReturn<ShippmentDTOResponse>
    {        
    }

    public class ShippmentDTOResponse
    {
        public string response = "";
    }
}
