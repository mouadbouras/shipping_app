import { Component, OnInit } from '@angular/core';
import { QuoteService } from '../services/quote.service';
import { Quote } from '../model/quote.model';
import { Order } from '../model/order.model';
import { Shipp } from '../model/shipp.model';
import { Parcel } from '../model/parcel.model';
import { Rate } from '../model/rate.model';
import { Constants } from '../util/constants.util';
import { HttpClient } from '@angular/common/http'; 
import { HttpHeaders } from '@angular/common/http';
import { NgxSpinnerService } from 'ngx-spinner';
import { Router } from '@angular/router';



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
  private selectedQuote : Quote;
  private shipment = new Order();


  constructor(private quoteServcie: QuoteService,
              private http: HttpClient,
              private spinner: NgxSpinnerService ) { }

  ngOnInit() {
    this.spinner.show();
    this.quoteServcie.quoteOB.subscribe(res => this.quotes = res);

    // this.shipment.From = new Shipp();
    // this.shipment.From.Company = "company";
    // this.shipment.From.Name = "company";    
    // this.shipment.From.StreetNumber = "1234";    
    // this.shipment.From.Street1 = "Streen name st";    
    // this.shipment.From.City = "City";    
    // this.shipment.From.State = "State";    
    // this.shipment.From.Zip = "H1H1H1";    
    // this.shipment.From.Country = "Country";    

    // this.shipment.To = new Shipp();
    // this.shipment.To.Company = "company";
    // this.shipment.To.Name = "company";    
    // this.shipment.To.StreetNumber = "1234";    
    // this.shipment.To.Street1 = "Streen name st";    
    // this.shipment.To.City = "City";    
    // this.shipment.To.State = "State";    
    // this.shipment.To.Zip = "H1H1H1";    
    // this.shipment.To.Country = "Country";   

    // this.shipment.QuoteParcel = new Parcel();
    // this.shipment.QuoteParcel.Height = 5;
    // this.shipment.QuoteParcel.Width = 5;
    // this.shipment.QuoteParcel.Length = 5;
    // this.shipment.QuoteParcel.Weight = 5;
    // this.shipment.QuoteParcel.Mass_unit = "lbs";
    // this.shipment.QuoteParcel.Distance_unit = "in" ;
    // this.shipment.QuoteRate = r;
    // this.shipment.QuoteDate = new Date();
    
    // var r = new Rate();

    // r.Image = "https://d37j7wop4pf4r7.cloudfront.net/sites/default/files/images/news/usps_big_logo_link.png";
    // r.Amount = 30;
    // r.Currency = "USD";
    // r.Estimate = "2 days 3 nights";
    // r.Provider = "USPS";
    // r.Servicelevel = "priority";

    // this.shipment.QuoteRate = r;

    // this.shipment.OrderDate  = new Date();
    // this.shipment.TotalPrice = (r.Amount * 1.15);


    // this.http.post(Constants.baseUrl+'/hello.json' ,
    //                JSON.stringify(this.shipment), httpOptions).subscribe(
    //   data => {

    //   this.spinner.hide();

    //   console.log(data);
    //   if(data["error"]!= undefined)
    //   {
    //     console.log("An Error Happened");
    //     console.log(data["details"]);
    //   }

    //   if(data["success"] != undefined){
    //     this.shipment.LabelURL = data["label_url"];
    //     this.shipment.TrackingNumber = data["tracking_number"];
    //     this.shipment.TrackingURL = data["tracking_url"];
    //     this.shipment.Eta = new Date(data["eta"]);
    //     console.log(this.shipment);
        
    //   }

    // });


    this.http.post(Constants.baseUrl+'/quote.json' ,
    JSON.stringify({UserId:1}), httpOptions).subscribe(
      data => {
        this.spinner.hide();

        this.quotes = new Array<Quote>();

        console.log(data);
        if(data["error"]!= undefined)
        {
          console.log("An Error Happened");
          console.log(data["details"]);
        }
        if(data["success"]!= undefined)
        {
          console.log("Saved Succesfully");
          console.log(data);

          for(var i in data["quotes"]){
            console.log(data["quotes"][i]);
            var q = new Quote();

            q.From = new Shipp(); 
            q.From.Name = data["quotes"][i]["from"]["name"];
            q.From.Company = data["quotes"][i]["from"]["company"];                
            q.From.StreetNumber = data["quotes"][i]["from"]["streetNumber"];    
            q.From.Street1 =data["quotes"][i]["from"]["streetAddress"];    
            q.From.City = data["quotes"][i]["from"]["city"];    
            q.From.State = data["quotes"][i]["from"]["province"];    
            q.From.Zip = data["quotes"][i]["from"]["postalCode"];    
            q.From.Country = data["quotes"][i]["from"]["country"];    
            
            q.To = new Shipp();            
            q.To.Name = data["quotes"][i]["to"]["name"];
            q.To.Company = data["quotes"][i]["to"]["company"];             
            q.To.StreetNumber = data["quotes"][i]["to"]["streetNumber"];    
            q.To.Street1 =data["quotes"][i]["to"]["streetAddress"];    
            q.To.City = data["quotes"][i]["to"]["city"];    
            q.To.State = data["quotes"][i]["to"]["province"];    
            q.To.Zip = data["quotes"][i]["to"]["postalCode"];    
            q.To.Country = data["quotes"][i]["to"]["country"];   

            q.QuoteParcel = new Parcel();
            q.QuoteParcel.Height = data["quotes"][i]["parcel"]["height"];
            q.QuoteParcel.Width = data["quotes"][i]["parcel"]["wight"];
            q.QuoteParcel.Length = data["quotes"][i]["parcel"]["length"];
            q.QuoteParcel.Weight = data["quotes"][i]["parcel"]["weight"];
            q.QuoteParcel.Mass_unit = data["quotes"][i]["parcel"]["massUnit"];
            q.QuoteParcel.Distance_unit = data["quotes"][i]["parcel"]["distanceUnit"];

            q.QuoteDate = data["quotes"][i]["quote"]["date"];

            q.QuoteRate = new Rate();

            q.QuoteRate.Amount = data["quotes"][i]["quote"]["amount"];
            q.QuoteRate.Currency = data["quotes"][i]["quote"]["currency"];
            q.QuoteRate.Estimate = data["quotes"][i]["quote"]["estimate"];
            q.QuoteRate.Provider = data["quotes"][i]["quote"]["provider"];
            q.QuoteRate.Servicelevel = data["quotes"][i]["quote"]["serviceLevel"];
            q.QuoteRate.Image = data["quotes"][i]["quote"]["image"];
            
            this.quotes.push(q);
          }


        }        
    });
  }

  selectQuote(quote) {   
     this.selectedQuote = quote;
     console.log(this.selectedQuote.QuoteRate.Amount);
  }

  onClickBack() {   
    this.selectedQuote = null;
 }

}
