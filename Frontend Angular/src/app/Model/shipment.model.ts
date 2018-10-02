import { Shipp } from "./shipp.model";
import { Parcel } from "./parcel.model";

export class Shipment {
    From: Shipp; 
    To: Shipp; 
    Parcels: Array<Parcel>; 
}