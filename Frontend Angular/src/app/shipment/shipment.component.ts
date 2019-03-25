import { Component, OnInit } from '@angular/core';
import { Quote } from '../model/quote.model';
import { QuoteService } from '../services/quote.service';
import { UserService } from '../services/user.service';
import { Rate } from '../model/rate.model';

import { HttpClient } from '@angular/common/http'; 
import { HttpHeaders } from '@angular/common/http';
import { NgxSpinnerService } from 'ngx-spinner';

import { Shipment } from '../model/shipment.model';
import { Parcel } from '../model/parcel.model';
import { Shipp } from '../model/shipp.model';
import { User } from '../model/user.model';
import { Constants } from '../util/constants.util';
import { Router } from '@angular/router';


const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json'
  }),withCredentials: true
};

@Component({
  selector: 'app-shipment',
  templateUrl: './shipment.component.html',
  styleUrls: ['./shipment.component.css']
})
export class ShipmentComponent implements OnInit {

  public shipment = new Quote();
  
  public selectQuoteError : boolean;
  public selectQuoteErrorText : string;
  public user : User;

  constructor(
              private quoteServcie: QuoteService,
              private http: HttpClient,
              private spinner: NgxSpinnerService,
              private router : Router,
              private userServcie: UserService
              ) { }

  ngOnInit() {
    this.quoteServcie.shipmentOB.subscribe(res => this.shipment = res[0]); 
    //this.userServcie.usersOB.subscribe(u => this.user = u[0]);
    this.userServcie.getUser().subscribe(u => this.user = u);

    this.selectQuoteError = false;        
  }

  public onClickConfirm(){

    this.selectQuoteError = false;
    this.spinner.show();

      this.http.post(Constants.baseUrl+'/transaction.json' ,
                   JSON.stringify({QuoteId:this.shipment.QuoteRate.ShipmentId,UserId:this.user.Id,RateId: this.shipment.QuoteRate.Id}), httpOptions).subscribe(
      data => {
      this.spinner.hide();
      //console.log(data);
      if(data["error"]!= undefined)
      {
        console.log("An Error Happened");
        this.selectQuoteError = true;
        this.selectQuoteErrorText = data["details"][0]["text"];
        console.log(data["details"]);
      }
      if(data["success"]!= undefined)
      {
        console.log("Saved Succesfully");
        console.log(data["success"]);
        this.router.navigateByUrl('/myshipments');
      }       

    });
  }

  public onClickSave(){

    this.selectQuoteError = false;
    this.spinner.show();

    this.http.post(Constants.baseUrl+'/quote.json' ,
    JSON.stringify({QuoteId:this.shipment.QuoteRate.ShipmentId,UserId:this.user.Id,RateId: this.shipment.QuoteRate.Id}), httpOptions).subscribe(
      data => {
        this.spinner.hide();
        console.log(data);
        if(data["error"]!= undefined)
        {
          console.log("An Error Happened");
          console.log(data["details"]["text"]);

          this.selectQuoteError = true;
          this.selectQuoteErrorText = data["details"]["text"];
        }
        if(data["success"]!= undefined)
        {
          console.log("Saved Succesfully");
          console.log(data["success"]);
          this.router.navigateByUrl('/myquotes');

        }        
    });
  }


}
