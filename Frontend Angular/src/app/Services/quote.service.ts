import { Injectable } from '@angular/core';
import { Shipment } from '../Model/shipment.model';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class QuoteService {

  private shipmentBh = new BehaviorSubject<any>([]); 

  shipment = this.shipmentBh.asObservable();

  constructor() { }


}
