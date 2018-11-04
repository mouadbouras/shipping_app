import { Shipp } from "./shipp.model";
import { Parcel } from "./parcel.model";
import { Rate } from "./rate.model";


export class Quote 
{
    From: Shipp; 
    To: Shipp; 
    Parcels: Parcel; 
    QuoteDate: Date; 
    QuoteRate: Rate;
}