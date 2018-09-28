using System;
using ServiceStack;
using Shippo;
using Newtonsoft.Json;
using MyApp.ServiceModel;
using System.Collections;
using System.Collections.Generic;

namespace MyApp.ServiceInterface
{
    public class MyServices : Service
    {
        public object Any(Hello request)
        {
            APIResource resource = new APIResource("shippo_test_5f00f661c1f2f19191bfba82cc8575fddb06c202");

           // APIResource resource = new APIResource("shippo_live_b248c98357917b42d991df307d6573359a901ea9");
            // to address
            Hashtable toAddressTable = new Hashtable();
            toAddressTable.Add("name", "Mr Hippo");
            toAddressTable.Add("company", "Shippo");
            toAddressTable.Add("street1", "215 Clayton St.");
            toAddressTable.Add("city", "San Francisco");
            toAddressTable.Add("state", "CA");
            toAddressTable.Add("zip", "94117");
            toAddressTable.Add("country", "US");

            // from address
            Hashtable fromAddressTable = new Hashtable();
            fromAddressTable.Add("name", "Ms Hippo");
            fromAddressTable.Add("company", "San Diego Zoo");
            fromAddressTable.Add("street1", "2920 Zoo Drive");
            fromAddressTable.Add("city", "San Diego");
            fromAddressTable.Add("state", "CA");
            fromAddressTable.Add("zip", "92101");
            fromAddressTable.Add("country", "US");

            Hashtable parcelTable = new Hashtable();
            parcelTable.Add("length", "5");
            parcelTable.Add("width", "5");
            parcelTable.Add("height", "5");
            parcelTable.Add("distance_unit", "in");
            parcelTable.Add("weight", "2");
            parcelTable.Add("mass_unit", "lb");

            List<Hashtable> parcels = new List<Hashtable>();
            parcels.Add(parcelTable);
           

            var response = resource.CreateShipment(new Hashtable(){
            { "address_to", toAddressTable},
            { "address_from", fromAddressTable},
            { "parcels", parcels},
            { "async", false}});


            return response;
        }

        public object Post(ShippmentDTO request)
        {
            APIResource resource = new APIResource("shippo_test_5f00f661c1f2f19191bfba82cc8575fddb06c202");

            //APIResource resource = new APIResource("shippo_live_b248c98357917b42d991df307d6573359a901ea9");

            // to address
            Hashtable toAddressTable = new Hashtable();
            toAddressTable.Add("name",    request.To.Name);
            toAddressTable.Add("company", request.To.Company);
            toAddressTable.Add("street1", request.To.Street1);
            toAddressTable.Add("city",    request.To.City);
            toAddressTable.Add("state",   request.To.State);
            toAddressTable.Add("zip",     request.To.Zip);
            toAddressTable.Add("country", request.To.Country);
            toAddressTable.Add("validate", "true");

            Address address = resource.CreateAddress(toAddressTable);
            Console.Out.WriteLine("Address IsValid: " + address.ValidationResults.IsValid);

            // from address
            Hashtable fromAddressTable = new Hashtable();
            fromAddressTable.Add("name",    request.From.Name);
            fromAddressTable.Add("company", request.From.Company);
            fromAddressTable.Add("street1", request.From.Street1);
            fromAddressTable.Add("city",    request.From.City);
            fromAddressTable.Add("state",   request.From.State);
            fromAddressTable.Add("zip",     request.From.Zip);
            fromAddressTable.Add("country", request.From.Country);
            fromAddressTable.Add("validate", "true");

            address = resource.CreateAddress(toAddressTable);
            Console.Out.WriteLine("Address IsValid: " + address.ValidationResults.IsValid);

            List<Hashtable> parcels = new List<Hashtable>();

            foreach(var parcel in request.Parcels)
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

            return response;
        }

    }
}
