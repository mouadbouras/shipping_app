import { Component, OnInit } from '@angular/core';
import { QuoteService } from '../Services/quote.service';
import { Quote } from '../model/quote.model';
import { Order } from '../model/order.model';
import { Shipp } from '../model/Shipp.model';
import { Parcel } from '../model/Parcel.model';
import { Rate } from '../model/Rate.model';
import { Constants } from '../util/constants.util';
import { HttpClient } from '@angular/common/http'; 
import { HttpHeaders } from '@angular/common/http';
import { NgxSpinnerService } from 'ngx-spinner';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json'
  })
};

@Component({
  selector: 'app-myquotes',
  templateUrl: './myquotes.component.html',
  styleUrls: ['./myquotes.component.css']
})
export class MyquotesComponent implements OnInit {

  private quotes = new Array<Quote>();
  private shipment = new Order();
  private selectedQuote = true;


  constructor(private quoteServcie: QuoteService,
              private http: HttpClient,
              private spinner: NgxSpinnerService ) { }

  ngOnInit() {
    this.quoteServcie.quoteOB.subscribe(res => this.quotes = res);

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

    this.shipment.OrderDate  = new Date();
    this.shipment.TotalPrice = (r.Amount * 1.15);

    this.http.post(Constants.baseUrl+'/hello.json' ,
                   JSON.stringify(this.shipment), httpOptions).subscribe(
      data => {

      this.spinner.hide();

      console.log(data);
      if(data["error"]!= undefined)
      {
        console.log("An Error Happened");
        console.log(data["details"]);
      }

      if(data["success"] != undefined){
        this.shipment.LabelURL = data["label_url"];
        this.shipment.TrackingNumber = data["tracking_number"];
        this.shipment.TrackingURL = data["tracking_url"];
        this.shipment.Eta = new Date(data["eta"]);
        console.log(this.shipment);
        
      }


    });


  }




}
