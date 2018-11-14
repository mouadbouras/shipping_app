using System;
using ServiceStack;
using Shippo;
using Newtonsoft.Json;
using MyApp.ServiceModel;
using System.Collections;
using System.Collections.Generic;
using MyApp.DataAccess.DataAccess;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace MyApp.ServiceInterface
{
    [EnableCors(allowedMethods:"GET,POST")]
    public class MyServices : Service
    {
        public APIResource resource = new APIResource("shippo_test_5f00f661c1f2f19191bfba82cc8575fddb06c202");

        public object Any(Hello request)
        {
            // to address
            // Hashtable toAddressTable = new Hashtable();
            // toAddressTable.Add("name", "moe");
            // toAddressTable.Add("company", "comp");
            // toAddressTable.Add("street_no", "1461");
            // toAddressTable.Add("street1", "Rue du Collège");
            // toAddressTable.Add("city", "Montréal");
            // toAddressTable.Add("state", "QC");
            // toAddressTable.Add("zip", "H4L3P1");
            // toAddressTable.Add("country", "Canada");

            // // from address
            // Hashtable fromAddressTable = new Hashtable();
            // fromAddressTable.Add("name", "Ms Hippo");
            // fromAddressTable.Add("company", "San Diego Zoo");
            // fromAddressTable.Add("street_no", "17");
            // fromAddressTable.Add("street1", "Rue de Calumet");
            // fromAddressTable.Add("city", "Gatineau");
            // fromAddressTable.Add("state", "QC");
            // fromAddressTable.Add("zip", " J8P1Z4 ");
            // fromAddressTable.Add("country", "Canada");

            // Hashtable parcelTable = new Hashtable();
            // parcelTable.Add("length", "5");
            // parcelTable.Add("width", "5");
            // parcelTable.Add("height", "5");
            // parcelTable.Add("distance_unit", "in");
            // parcelTable.Add("weight", "2");
            // parcelTable.Add("mass_unit", "lb");

            // List<Hashtable> parcels = new List<Hashtable>();
            // parcels.Add(parcelTable);
           

            // var response = resource.CreateShipment(new Hashtable(){
            // { "address_to", toAddressTable},
            // { "address_from", fromAddressTable},
            // { "parcels", parcels},
            // { "async", false}});

            // var id =  response.Rates[0].ObjectId;

            // Hashtable transactionParameters = new Hashtable();
            // transactionParameters.Add("rate",id);
            // transactionParameters.Add("async", false);

            //  // Purchase the desired rate.
            // Transaction transaction = resource.CreateTransaction(transactionParameters);

            // if (((String) transaction.Status).Equals("SUCCESS", StringComparison.OrdinalIgnoreCase)){
            //     Console.WriteLine("Label url: " + transaction.LabelURL);
            //     Console.WriteLine("Tracking number: " +
            //         transaction.TrackingNumber);
            //     //return {transaction.LabelURL,transaction.TrackingNumber}

            //     var rresponse = "{\"SSuccess\": \"transaction Sccess\" ," +
            //         "\"label\" : " + transaction.LabelURL.ToString() + ","+
            //         "\"transaction\" : " + transaction.TrackingNumber.ToString() + "}";
            //     return rresponse;


            // } else{
            //     Console.WriteLine("Error generating label. Messages: " +
            //         transaction.Messages);
                
            //     var rresponse = "{\"error\": \"exception caught by server\" ," +
            //         "\"details\" : " + transaction.Messages.ToString() + "}";
            //         return rresponse;
            // }

            // return response.Rates;
            var response = "{\"success\": \"transaction Success\" ," +
                    "\"label_url\" : \"" + "https://shippo-delivery-east.s3.amazonaws.com/e119bde5117946c2a2f121b610db21a4.pdf?Signature=VJnRwuOBpMf788d2GB0zkNjWRh4%3D&Expires=1573254252&AWSAccessKeyId=AKIAJGLCC5MYLLWIG42A" + "\" ,"+
                    "\"tracking_number\" : \"" + "ZW70QJC" + "\","+
                    "\"tracking_url\" : \"" + "https://tools.usps.com/go/TrackConfirmAction.action?tLabels=ZW70QJC" + "\","+ 
                    "\"eta\" : \"" + "2013-12-30T12:00:00.000Z" + "\"}";
                    


            return response;
        }

        public object Post(ShippmentDTO request)
        {
            //APIResource resource = new APIResource("shippo_test_5f00f661c1f2f19191bfba82cc8575fddb06c202");
            //APIResource resource = new APIResource("shippo_live_b248c98357917b42d991df307d6573359a901ea9");
            try { 
                //to address
                Hashtable toAddressTable = new Hashtable();
                toAddressTable.Add("name", request.To.Name);
                toAddressTable.Add("company", request.To.Company);
                toAddressTable.Add("street_no", request.To.StreetNumber);
                toAddressTable.Add("street1", request.To.Street1);
                toAddressTable.Add("city", request.To.City);
                toAddressTable.Add("state", request.To.State);
                toAddressTable.Add("zip", request.To.Zip);
                toAddressTable.Add("country", request.To.Country);
                toAddressTable.Add("validate", "false");

                Address address = resource.CreateAddress(toAddressTable);

                // from address
                Hashtable fromAddressTable = new Hashtable();
                fromAddressTable.Add("name", request.From.Name);
                fromAddressTable.Add("company", request.From.Company);
                fromAddressTable.Add("street_no", request.From.StreetNumber);
                fromAddressTable.Add("street1", request.From.Street1);
                fromAddressTable.Add("city", request.From.City);
                fromAddressTable.Add("state", request.From.State);
                fromAddressTable.Add("zip", request.From.Zip);
                fromAddressTable.Add("country", request.From.Country);
                fromAddressTable.Add("validate", "false");

                List<Hashtable> parcels = new List<Hashtable>();

                foreach (var parcel in request.Parcels)
                {
                    Hashtable parcelTable = new Hashtable();
                    parcelTable.Add("length", parcel.Length);
                    parcelTable.Add("width", parcel.Width);
                    parcelTable.Add("height", parcel.Height);
                    parcelTable.Add("distance_unit", parcel.Distance_unit);
                    parcelTable.Add("weight", parcel.Weight);
                    parcelTable.Add("mass_unit", parcel.Mass_unit);
                    parcels.Add(parcelTable);
                }


                var apiResponse = resource.CreateShipment(new Hashtable(){
                { "address_to", toAddressTable},
                { "address_from", fromAddressTable},
                { "parcels", parcels},
                { "async", false}});


                var response = "{\"success\": \"success\" ," +
                "\"shipment_id\" : \""+ apiResponse.ObjectId +"\","+
                "\"rates\" : "+ JSON.stringify(apiResponse.Rates) + "}";

                return response;

            }
            catch (Exception e)
            {
                var response = "{\"error\": \"exception caught by server\" ," +
                    "\"details\" : " + e.Message.ToString() + "}";
                return response;
            }

        }
        
        public object Post(QuoteDTO request){

            var context = new shippingcoContext();

            if(request.QuoteId != "" && request.QuoteId != null
             && request.UserId != "" && request.UserId != null
             && request.RateId != "" &&  request.RateId != null)
            {
                var shipment = resource.RetrieveShipment(request.QuoteId);
                var rate = resource.RetrieveRate(request.RateId);
                
                var from = new ShippmentUnit();
                var to = new ShippmentUnit();
                var parcel = new MyApp.DataAccess.DataAccess.Parcel();
                var quote = new Quotes();                

                var apiShipmentObject = (Address) ((JObject)shipment.AddressFrom).ToObject(typeof(Address));

                from.StreetNumber = apiShipmentObject.StreetNo.ToString();
                from.StreetAddress = apiShipmentObject.Street1.ToString();
                from.City = apiShipmentObject.City.ToString();
                from.Province = apiShipmentObject.State.ToString();
                from.PostalCode = apiShipmentObject.Zip.ToString();
                from.Country = apiShipmentObject.Country.ToString();
                from.Name = apiShipmentObject.Name.ToString();
                from.Company = apiShipmentObject.Company.ToString();


                apiShipmentObject = (Address) ((JObject)shipment.AddressTo).ToObject(typeof(Address));

                to.StreetNumber = apiShipmentObject.StreetNo.ToString();
                to.StreetAddress = apiShipmentObject.Street1.ToString();
                to.City = apiShipmentObject.City.ToString();
                to.Province = apiShipmentObject.State.ToString();
                to.PostalCode = apiShipmentObject.Zip.ToString();
                to.Country = apiShipmentObject.Country.ToString();
                to.Name = apiShipmentObject.Name.ToString();
                to.Company = apiShipmentObject.Company.ToString();

                var apiParcelObject = (Shippo.Parcel) ((JObject)shipment.Parcels[0]).ToObject(typeof(Shippo.Parcel));

                parcel.Height = Decimal.Parse(apiParcelObject.Height.ToString());
                parcel.Width  = Decimal.Parse(apiParcelObject.Width.ToString());
                parcel.Weight = Decimal.Parse(apiParcelObject.Weight.ToString());
                parcel.Length = Decimal.Parse(apiParcelObject.Length.ToString());
                parcel.MassUnit = apiParcelObject.MassUnit.ToString();
                parcel.DistanceUnit = apiParcelObject.DistanceUnit.ToString();

                context.ShippmentUnit.Add(from);
                context.ShippmentUnit.Add(to);
                context.Parcel.Add(parcel);

                context.SaveChanges();
                 
                quote.UserId = Int32.Parse(request.UserId); 
                quote.FromId = from.Id; 
                quote.ToId = to.Id; 
                quote.ParcelId = parcel.Id; 
                quote.Date = (DateTime) shipment.ShipmentDate;
                quote.Amount =  Decimal.Parse(rate.Amount.ToString());                                      
                quote.Currency =rate.Currency.ToString();
                quote.Provider = rate.Provider.ToString();
                quote.ServiceLevel = rate.Servicelevel.Name.ToString();
                quote.Estimate = rate.EstimatedDays.ToString();       
                quote.Image = rate.ProviderImage200.ToString();                 

                context.Quotes.Add(quote);                
                context.SaveChanges();

                var response = "{\"success\": \"success\"} " ;
                return response;

                // from.StreetNumber = ((Hashtable) shipment.AddressTo)["street_no"].ToString();
                // from.StreetAddress = ((Hashtable) shipment.AddressTo)["street1"].ToString();
                // from.City = ((Hashtable) shipment.AddressTo)["city"].ToString();
                // from.Province = ((Hashtable) shipment.AddressTo)["state"].ToString();
                // from.PostalCode = ((Hashtable) shipment.AddressTo)["zip"].ToString();
                // from.Country = ((Hashtable) shipment.AddressTo)["country"].ToString();
                // var fromId = context.ShippmentUnit.Add(from).GetId();

                // Orders order = new Orders();
                // order.FromId = (int)fromId;
                //    var shippingDb = context.Orders.Add(
                    
                //    );
                //    db.Set<Customer>();
                //     customers.Add( new Customer { CustomerId = id, Name = "John Doe" } );

                //     shippingDb.SaveChanges();

                // var getUSer = context.Users
                //                       .Where(s => s.Id == 2)
                //                       .ToList();
            }

            if(request.UserId != "" && request.QuoteId == null && request.RateId == null)
            {
                var responseList = new List<QuoteDTOResponse>();
                
                var from = new ShippmentUnit();
                var to = new ShippmentUnit();
                var parcel = new MyApp.DataAccess.DataAccess.Parcel();
                var client = new Client();
                var quote = new Quotes();      
                var user = new Users();      


                var quotes = context.Quotes
                            .Where(q => q.UserId.ToString() == request.UserId)
                            .ToList();

                foreach(var q in quotes)
                {
                    to = context.ShippmentUnit
                                .Where(u => u.Id.ToString() == q.ToId.ToString() )
                                .ToList().First();

                    from = context.ShippmentUnit
                                .Where(u => u.Id.ToString() == q.FromId.ToString() )
                                .ToList().First();       

                    parcel = context.Parcel
                                .Where(p => p.Id.ToString() == q.ParcelId.ToString() )
                                .ToList().First();  

                    client = context.Client                             
                                .Where(c => c.Id.ToString() == request.UserId)
                                .ToList().First(); 

                    var rlist = new QuoteDTOResponse();
                    rlist.from = from;
                    rlist.to = to;
                    rlist.parcel = parcel;
                    rlist.quote = q;

                    responseList.Add(rlist);
                }                                                      

                var response = "{\"success\": \"success\" ,"  +
                    "\"quotes\" : " + JSON.stringify(responseList)  + "}";
                return response;

            }
            
            return "{\"error\": \"Invalid Request\"}" ;      
        }

        public object Post(TransactionDTO request){
            
            // Get the first rate in the rates results.
            // Customize this based on your business logic.
            //Rate rate = shipment.RatesList[];
            var context = new shippingcoContext();

            if(request.QuoteId != "" && request.QuoteId != null
            && request.UserId != "" && request.UserId != null
            && request.RateId != "" &&  request.RateId != null)
            {

                Hashtable transactionParameters = new Hashtable();
                transactionParameters.Add("rate", request.RateId);
                transactionParameters.Add("async", false);

                try{ 
                // Purchase the desired rate.
                Transaction transaction = resource.CreateTransaction(transactionParameters);

                if (((String) transaction.Status).Equals("SUCCESS", StringComparison.OrdinalIgnoreCase)){
                    Console.WriteLine("Label url: " + transaction.LabelURL);
                    Console.WriteLine("Tracking number: " +
                        transaction.TrackingNumber);

                        var shipment = resource.RetrieveShipment(request.QuoteId);
                        var rate = resource.RetrieveRate(request.RateId);
                        
                        var from = new ShippmentUnit();
                        var to = new ShippmentUnit();
                        var parcel = new MyApp.DataAccess.DataAccess.Parcel();
                        var order = new Orders();                

                        var apiShipmentObject = (Address) ((JObject)shipment.AddressFrom).ToObject(typeof(Address));

                        from.StreetNumber = apiShipmentObject.StreetNo.ToString();
                        from.StreetAddress = apiShipmentObject.Street1.ToString();
                        from.City = apiShipmentObject.City.ToString();
                        from.Province = apiShipmentObject.State.ToString();
                        from.PostalCode = apiShipmentObject.Zip.ToString();
                        from.Country = apiShipmentObject.Country.ToString();
                        from.Name = apiShipmentObject.Name.ToString();
                        from.Company = apiShipmentObject.Company.ToString();


                        apiShipmentObject = (Address) ((JObject)shipment.AddressTo).ToObject(typeof(Address));

                        to.StreetNumber = apiShipmentObject.StreetNo.ToString();
                        to.StreetAddress = apiShipmentObject.Street1.ToString();
                        to.City = apiShipmentObject.City.ToString();
                        to.Province = apiShipmentObject.State.ToString();
                        to.PostalCode = apiShipmentObject.Zip.ToString();
                        to.Country = apiShipmentObject.Country.ToString();
                        to.Name = apiShipmentObject.Name.ToString();
                        to.Company = apiShipmentObject.Company.ToString();

                        var apiParcelObject = (Shippo.Parcel) ((JObject)shipment.Parcels[0]).ToObject(typeof(Shippo.Parcel));

                        parcel.Height = Decimal.Parse(apiParcelObject.Height.ToString());
                        parcel.Width  = Decimal.Parse(apiParcelObject.Width.ToString());
                        parcel.Weight = Decimal.Parse(apiParcelObject.Weight.ToString());
                        parcel.Length = Decimal.Parse(apiParcelObject.Length.ToString());
                        parcel.MassUnit = apiParcelObject.MassUnit.ToString();
                        parcel.DistanceUnit = apiParcelObject.DistanceUnit.ToString();

                        context.ShippmentUnit.Add(from);
                        context.ShippmentUnit.Add(to);
                        context.Parcel.Add(parcel);

                        context.SaveChanges();
                        
                        order.UserId = Int32.Parse(request.UserId); 
                        order.FromId = from.Id; 
                        order.ToId = to.Id; 
                        order.ParcelId = parcel.Id; 
                        order.Date = (DateTime) shipment.ShipmentDate;
                        order.Amount =  Decimal.Parse(rate.Amount.ToString());                                      
                        order.Currency =rate.Currency.ToString();
                        order.Provider = rate.Provider.ToString();
                        order.ServiceLevel = rate.Servicelevel.Name.ToString();
                        order.Estimate = rate.EstimatedDays.ToString();       
                        order.Image = rate.ProviderImage200.ToString();      
                        order.LabelUrl = transaction.LabelURL.ToString();
                        order.TrackingNumber = transaction.TrackingNumber.ToString();
                        order.TrackingUrl = transaction.TrackingUrlProvider.ToString();
                        //order.Eta = transaction..tostring();

                        context.Orders.Add(order);                
                        context.SaveChanges();

                        //var response = "{\"success\": \"success\"} " ;
                        //return response;


                        var response = "{\"Success\": \"transaction Sccess\" ," +
                        "\"label\" : \"" + transaction.LabelURL.ToString() + "\" ,"+
                        "\"transaction\" : " + transaction.TrackingNumber.ToString() + "}";

                    return response;

                } else{
                    Console.WriteLine("Error generating label. Messages: " +
                        transaction.Messages);
                    
                    var response = "{\"error\": \"exception caught by server\" ," +
                        "\"details\" : " + transaction.Messages.ToString() + "}";
                    return response;
                }
                }
                catch (Exception e)
                {
                    var response = "{\"error\": \"exception caught by server\" ," +
                        "\"details\" : "+ e.Message.ToString() +"}";
                    return response;
                }
            }

           if(request.UserId != "" && request.QuoteId == null && request.RateId == null)
            {
                var responseList = new List<TransactionDTOResponse>();
                
                var from = new ShippmentUnit();
                var to = new ShippmentUnit();
                var parcel = new MyApp.DataAccess.DataAccess.Parcel();
                var client = new Client();
                var order = new Orders();      
                var user = new Users();      


                var orders = context.Orders
                            .Where(q => q.UserId.ToString() == request.UserId)
                            .ToList();

                foreach(var q in orders)
                {
                    to = context.ShippmentUnit
                                .Where(u => u.Id.ToString() == q.ToId.ToString() )
                                .ToList().First();

                    from = context.ShippmentUnit
                                .Where(u => u.Id.ToString() == q.FromId.ToString() )
                                .ToList().First();       

                    parcel = context.Parcel
                                .Where(p => p.Id.ToString() == q.ParcelId.ToString() )
                                .ToList().First();  

                    client = context.Client                             
                                .Where(c => c.Id.ToString() == request.UserId)
                                .ToList().First(); 

                    var rlist = new TransactionDTOResponse();
                    rlist.from = from;
                    rlist.to = to;
                    rlist.parcel = parcel;
                    rlist.order = q;

                    responseList.Add(rlist);
                }                                                      

                var response = "{\"success\": \"success\" ,"  +
                    "\"orders\" : " + JSON.stringify(responseList)  + "}";
                return response;

            }
 
            return null;
        }        
    
    }
}
