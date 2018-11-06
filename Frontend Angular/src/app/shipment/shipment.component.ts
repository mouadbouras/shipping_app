import { Component, OnInit } from '@angular/core';
import { Quote } from '../Model/quote.model';
import { QuoteService } from '../Services/quote.service';



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
    console.log(this.shipment);
  }

}
