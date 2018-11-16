import { Injectable } from '@angular/core';
import { Shipment } from '../model/shipment.model';
import { Quote } from '../model/quote.model';
import { Order } from '../model/order.model';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class QuoteService {

  private quotes = new Array<Quote>();
  private shipment = new Array<Quote>();
  private orders = new Array<Order>();

  private quotesBh = new BehaviorSubject<any>(this.quotes); 
  private shipmentBh = new BehaviorSubject<any>(this.shipment); 
  private ordersBh = new BehaviorSubject<any>(this.orders); 


  shipmentOB = this.shipmentBh.asObservable();
  quoteOB = this.quotesBh.asObservable();
  ordersOB = this.ordersBh.asObservable();

  constructor() { }

  public addQuote(quote){    
    this.quotes.push(quote);
  }

  public addOrder(order){    
    this.orders.push(order);
  }

  public addShipment(shipment){  
    this.shipment.pop();  
    this.shipment.push(shipment);
  }


}
