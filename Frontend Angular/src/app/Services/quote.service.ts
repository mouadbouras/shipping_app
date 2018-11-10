import { Injectable } from '@angular/core';
import { Shipment } from '../model/shipment.model';
import { Quote } from '../model/quote.model';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class QuoteService {

  private quotes = new Array<Quote>();
  private shipment = new Array<Quote>();

  private quotesBh = new BehaviorSubject<any>(this.quotes); 
  private shipmentBh = new BehaviorSubject<any>(this.shipment); 

  shipmentOB = this.shipmentBh.asObservable();
  quoteOB = this.quotesBh.asObservable();

  constructor() { }

  public addQuote(quote){    
    this.quotes.push(quote);
  }

  public addShipment(shipment){  
    this.shipment.pop();  
    this.shipment.push(shipment);
  }


}
