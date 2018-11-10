using System;
using ServiceStack;
using Shippo;
using Newtonsoft.Json;
using MyApp.ServiceModel;
using System.Collections;
using System.Collections.Generic;

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


                var response = resource.CreateShipment(new Hashtable(){
                { "address_to", toAddressTable},
                { "address_from", fromAddressTable},
                { "parcels", parcels},
                { "async", false}});
                return response.Rates;

            }
            catch (Exception e)
            {
                var response = "{\"error\": \"exception caught by server\" ," +
                    "\"details\" : " + e.Message.ToString() + "}";
                return response;
            }

        }
        
        public object Post(QuoteDTO request){
            return null;
        }

        public object Post(TransactionDTO request){
            
            // Get the first rate in the rates results.
            // Customize this based on your business logic.
            //Rate rate = shipment.RatesList[];

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
                //return {transaction.LabelURL,transaction.TrackingNumber}

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
    
    }
}
