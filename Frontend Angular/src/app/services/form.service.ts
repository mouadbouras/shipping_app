import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Shipment } from '../model/shipment.model';


@Injectable({
  providedIn: 'root'
})
export class FormService {

  private formShipment = new Shipment();

  private formShipmentBh = new BehaviorSubject<any>(this.formShipment); 


  formShipmentOB = this.formShipmentBh.asObservable();

  constructor() { }

  public addShipment(shipment){  
    this.formShipment = shipment;
    // this.formShipment.pop();  
    // this.formShipment.push(shipment);
  }

}
