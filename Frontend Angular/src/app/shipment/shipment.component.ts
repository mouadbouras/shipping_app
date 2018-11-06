import { Component, OnInit } from '@angular/core';
import { Quote } from '../Model/quote.model';
import { QuoteService } from '../Services/quote.service';
import { Rate } from '../Model/rate.model';
import { Shipment } from '../Model/shipment.model';
import { Parcel } from '../Model/parcel.model';
import { Shipp } from '../Model/shipp.model';



@Component({
  selector: 'app-shipment',
  templateUrl: './shipment.component.html',
  styleUrls: ['./shipment.component.css']
})
export class ShipmentComponent implements OnInit {

  private shipment = new Quote();

  constructor(private quoteServcie: QuoteService) { }

  ngOnInit() {
    this.quoteServcie.shipmentOB.subscribe(res => this.shipment = res[0]);  
    
    this.shipment = new Quote();
    this.shipment.From = new Shipp();
    this.shipment.From.Company = "company";
    this.shipment.From.Name = "company";    
    this.shipment.From.StreetNumber = "1234";    
    this.shipment.From.Street1 = "Streen name st";    
    this.shipment.From.City = "City";    
    this.shipment.From.State = "State";    
    this.shipment.From.Zip = "H1H1H1";    
    this.shipment.From.Country = "Country";    

    this.shipment.To = new Shipp();
    this.shipment.To = new Shipp();
    this.shipment.To.Company = "company";
    this.shipment.To.Name = "company";    
    this.shipment.To.StreetNumber = "1234";    
    this.shipment.To.Street1 = "Streen name st";    
    this.shipment.To.City = "City";    
    this.shipment.To.State = "State";    
    this.shipment.To.Zip = "H1H1H1";    
    this.shipment.To.Country = "Country";   

    this.shipment.QuoteParcel = new Parcel();
    this.shipment.QuoteParcel.Height = 5;
    this.shipment.QuoteParcel.Width = 5;
    this.shipment.QuoteParcel.Length = 5;
    this.shipment.QuoteParcel.Weight = 5;
    this.shipment.QuoteParcel.Mass_unit = "lbs";
    this.shipment.QuoteParcel.Distance_unit = "in" ;
    this.shipment.QuoteRate = r;
    this.shipment.QuoteDate = new Date();
    
    var r = new Rate();

    r.Image = "https://d37j7wop4pf4r7.cloudfront.net/sites/default/files/images/news/usps_big_logo_link.png";
    r.Amount = 30;
    r.Currency = "USD";
    r.Estimate = "2 days 3 nights";
    r.Provider = "USPS";
    r.Servicelevel = "priority";

    this.shipment.QuoteRate = r;
  }

}
