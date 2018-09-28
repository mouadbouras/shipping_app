using ServiceStack;
using MyApp.Model;

namespace MyApp.ServiceModel
{
    [Route("/shipment")]
    public class ShippmentDTO : Shipment, IReturn<ShippmentDTOResponse>
    {
    }

    public class ShippmentDTOResponse
    {
        public string response = "";
    }
}
