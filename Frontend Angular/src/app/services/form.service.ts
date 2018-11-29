import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Shipment } from '../model/shipment.model';
import { Shipp } from '../model/shipp.model';
import { Parcel } from '../model/parcel.model';



@Injectable({
  providedIn: 'root'
})
export class FormService {

  private formShipment = new Shipment();

  private formShipmentBh = new BehaviorSubject<any>(this.formShipment); 


  formShipmentOB = this.formShipmentBh.asObservable();

  constructor() { 
    this.formShipment.From = new Shipp();
    this.formShipment.To = new Shipp();
    this.formShipment.Parcels = new Array<Parcel>();    
    this.formShipment.Parcels.push(new Parcel());

  }

  public addShipment(shipment){  
    this.formShipment = shipment;
    // this.formShipment.pop();  
    // this.formShipment.push(shipment);
  }

}
