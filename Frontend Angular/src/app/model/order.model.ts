import { Quote } from "./quote.model";


export class Order extends Quote
{
    OrderDate: Date; 
    TotalPrice: number;
    TrackingNumber : string;
    TrackingURL: string;
    LabelURL : string;
    Eta : Date;
   
}