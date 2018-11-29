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
  selector: 'app-myshipments',
  templateUrl: './myshipments.component.html',
  styleUrls: ['./myshipments.component.css']
})
export class MyshipmentsComponent implements OnInit {

  private orders = new Array<Order>();
  private selectedOrder : Order;

  constructor(
    private quoteServcie: QuoteService,
    private http: HttpClient,
    private spinner: NgxSpinnerService) { }

  ngOnInit() {
    this.spinner.show();
    this.quoteServcie.ordersOB.subscribe(res => this.orders = res);

    this.http.post(Constants.baseUrl+'/transaction.json' ,
    JSON.stringify({UserId:1}), httpOptions).subscribe(
      data => {
        this.spinner.hide();

        this.orders = new Array<Order>();

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

          for(var i in data["orders"]){
            console.log(data["orders"][i]);
            var o = new Order();

            o.From = new Shipp(); 
            o.From.Name = data["orders"][i]["from"]["name"];
            o.From.Company = data["orders"][i]["from"]["company"];                
            o.From.StreetNumber = data["orders"][i]["from"]["streetNumber"];    
            o.From.Street1 =data["orders"][i]["from"]["streetAddress"];    
            o.From.City = data["orders"][i]["from"]["city"];    
            o.From.State = data["orders"][i]["from"]["province"];    
            o.From.Zip = data["orders"][i]["from"]["postalCode"];    
            o.From.Country = data["orders"][i]["from"]["country"];    
            
            o.To = new Shipp();            
            o.To.Name = data["orders"][i]["to"]["name"];
            o.To.Company = data["orders"][i]["to"]["company"];             
            o.To.StreetNumber = data["orders"][i]["to"]["streetNumber"];    
            o.To.Street1 =data["orders"][i]["to"]["streetAddress"];    
            o.To.City = data["orders"][i]["to"]["city"];    
            o.To.State = data["orders"][i]["to"]["province"];    
            o.To.Zip = data["orders"][i]["to"]["postalCode"];    
            o.To.Country = data["orders"][i]["to"]["country"];   

            o.QuoteParcel = new Parcel();
            o.QuoteParcel.Height = data["orders"][i]["parcel"]["height"];
            o.QuoteParcel.Width = data["orders"][i]["parcel"]["width"];
            o.QuoteParcel.Length = data["orders"][i]["parcel"]["length"];
            o.QuoteParcel.Weight = data["orders"][i]["parcel"]["weight"];
            o.QuoteParcel.Mass_unit = data["orders"][i]["parcel"]["massUnit"];
            o.QuoteParcel.Distance_unit = data["orders"][i]["parcel"]["distanceUnit"];

            o.QuoteDate = data["orders"][i]["order"]["date"];

            o.QuoteRate = new Rate();

            o.QuoteRate.Amount = data["orders"][i]["order"]["amount"];
            o.QuoteRate.Currency = data["orders"][i]["order"]["currency"];
            o.QuoteRate.Estimate = data["orders"][i]["order"]["estimate"];
            o.QuoteRate.Provider = data["orders"][i]["order"]["provider"];
            o.QuoteRate.Servicelevel = data["orders"][i]["order"]["serviceLevel"];
            o.QuoteRate.Image = data["orders"][i]["order"]["image"];
            
            o.LabelURL = data["orders"][i]["order"]["labelUrl"];
            o.TrackingNumber = data["orders"][i]["order"]["trackingNumber"];
            o.TrackingURL = data["orders"][i]["order"]["trackingUrl"];                
            
            this.orders.push(o);
          }


        }        
    });
  }

selectOrder(order) {   
   this.selectedOrder = order;
   console.log(this.selectedOrder.QuoteRate.Amount);
}

onClickBack() {   
  this.selectedOrder = null;
}


}
