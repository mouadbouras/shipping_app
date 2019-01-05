import { Component, OnInit } from '@angular/core';
import { Quote } from '../model/quote.model';
import { QuoteService } from '../services/quote.service';
import { Rate } from '../model/rate.model';

import { HttpClient } from '@angular/common/http'; 
import { HttpHeaders } from '@angular/common/http';
import { NgxSpinnerService } from 'ngx-spinner';

import { Shipment } from '../model/shipment.model';
import { Parcel } from '../model/parcel.model';
import { Shipp } from '../model/shipp.model';
import { Constants } from '../util/constants.util';
import { Router } from '@angular/router';


const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json'
  })
};

@Component({
  selector: 'app-shipment',
  templateUrl: './shipment.component.html',
  styleUrls: ['./shipment.component.css']
})
export class ShipmentComponent implements OnInit {

  private shipment = new Quote();
  
  public selectQuoteError : boolean;
  public selectQuoteErrorText : string;

  constructor(
              private quoteServcie: QuoteService,
              private http: HttpClient,
              private spinner: NgxSpinnerService,
              private router : Router
              ) { }

  ngOnInit() {
    this.quoteServcie.shipmentOB.subscribe(res => this.shipment = res[0]); 
    this.selectQuoteError = false;        
  }

  private onClickConfirm(){

    this.selectQuoteError = false;
    this.spinner.show();

      this.http.post(Constants.baseUrl+'/transaction.json' ,
                   JSON.stringify({QuoteId:this.shipment.QuoteRate.ShipmentId,UserId:1,RateId: this.shipment.QuoteRate.Id}), httpOptions).subscribe(
      data => {
      this.spinner.hide();
      //console.log(data);
      if(data["error"]!= undefined)
      {
        console.log("An Error Happened");
        this.selectQuoteError = true;
        this.selectQuoteErrorText = data["details"];
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

  private onClickSave(){

    this.selectQuoteError = false;
    this.spinner.show();

    this.http.post(Constants.baseUrl+'/quote.json' ,
    JSON.stringify({QuoteId:this.shipment.QuoteRate.ShipmentId,UserId:1,RateId: this.shipment.QuoteRate.Id}), httpOptions).subscribe(
      data => {
        this.spinner.hide();
        //console.log(data);
        if(data["error"]!= undefined)
        {
          console.log("An Error Happened");
          console.log(data["details"]);

          this.selectQuoteError = true;
          this.selectQuoteErrorText = data["details"];
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
