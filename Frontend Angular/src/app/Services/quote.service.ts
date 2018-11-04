import { Injectable } from '@angular/core';
import { Shipment } from '../Model/shipment.model';
import { Quote } from '../Model/quote.model';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class QuoteService {

  private quotes = new Array<Quote>();

  private quotesBh = new BehaviorSubject<any>(this.quotes); 
  private shipmentBh = new BehaviorSubject<any>([]); 

  shipment = this.shipmentBh.asObservable();
  quote = this.quotesBh.asObservable();

  constructor() { }

  public addQuote(quote){    
    this.quotes.push(quote);
  }


}
