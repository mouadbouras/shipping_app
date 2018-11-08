import { Component,ElementRef, NgZone, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
/// <reference types="@types/googlemaps" />
import { MapsAPILoader } from '@agm/core';
import { QuoteService } from '../Services/quote.service';
import { Observable } from 'rxjs';
import { Shipment } from '../Model/shipment.model';
import { Parcel } from '../Model/parcel.model';
import { Shipp } from '../Model/shipp.model';
import { Rate } from '../Model/rate.model';
import { NgxSpinnerService } from 'ngx-spinner';
import {Router} from '@angular/router';


import { HttpClient } from '@angular/common/http'; 
import { HttpHeaders } from '@angular/common/http';
import { Location } from '@angular/common';
import { Quote } from '../Model/quote.model';


const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json'
  })
};

@Component({
  selector: 'app-getquote',
  templateUrl: './getquote.component.html',
  styleUrls: ['./getquote.component.css']
})

export class GetquoteComponent implements OnInit {

  //public baseUrl = "http://shipping-co.azurewebsites.net" ; 
  public baseUrl = "http://localhost:5000" ; 
  public shipment : Shipment;
  public latitude: number;
  public longitude: number;
  public searchControl1: FormControl;
  public searchControl2: FormControl;
  public zoom: number;
  public rates : Array<Rate>;

  public showError : boolean;
  public showQuote : boolean;
  public quoteError : string;

  public shippment = {
    Length: "",
    width:"",
    height:"",
    weight:""
  };   

  public componentForm = {
    street_number: 'short_name',
    route: 'long_name',
    locality: 'long_name',
    administrative_area_level_1: 'short_name',
    country: 'long_name',
    postal_code: 'short_name'
  };

  public contentForm1 = {
    name :'',
    company :'',
    street_number: '',
    route: '',
    locality: '',
    administrative_area_level_1: '',
    country: '',
    postal_code: ''
  };

  public contentForm2 = {
    name :'',
    company :'',
    street_number: '',
    route: '',
    locality: '',
    administrative_area_level_1: '',
    country: '',
    postal_code: ''
  };  

  @ViewChild("search1")
  public searchElementRef1: ElementRef;
  @ViewChild("search2")
  public searchElementRef2: ElementRef;

  constructor(
    private router : Router,
    private mapsAPILoader: MapsAPILoader,
    private ngZone: NgZone,
    private quote: QuoteService,
    private http: HttpClient,
    private spinner: NgxSpinnerService
  ) {

  }

  ngOnInit() {

    this.quote.shipmentOB.subscribe(
      resShipment => this.shipment = resShipment
    );

    this.rates = new Array<Rate>(); 
    var r = new Rate();

    r.Image = "https://d37j7wop4pf4r7.cloudfront.net/sites/default/files/images/news/usps_big_logo_link.png";
    r.Amount = 30;
    r.Currency = "USD";
    r.Estimate = "2 days 3 nights";
    r.Provider = "USPS";
    r.Servicelevel = "priority";

    this.rates.push(r);

    this.showError = false;
    this.showQuote = false;
    this.quoteError= "" ;

    // var q = new Quote();
    // q.From = new Shipp();
    // q.From = this.shipment.From;
    // q.To = new Shipp();
    // q.To = this.shipment.To;
    // q.QuoteParcel = null;
    // q.QuoteRate = r;
    // q.QuoteDate = new Date();
    // this.quote.addQuote(q);
    // this.quote.addShipment(q);

    //this.showQuote=true;

    this.loadMapsAutocomplete();
  }

  private loadMapsAutocomplete(){
    //set google maps defaults
    this.zoom = 4;
    this.latitude = 39.8282;
    this.longitude = -98.5795;

    //create search FormControl
    this.searchControl1 = new FormControl();
    this.searchControl2 = new FormControl();

    //set current position
    this.setCurrentPosition();

    //load Places Autocomplete
    this.mapsAPILoader.load().then(() => {
      let autocomplete = new google.maps.places.Autocomplete(this.searchElementRef1.nativeElement, {
        types: ["address"]
      });
      autocomplete.addListener("place_changed", () => {
        this.ngZone.run(() => {
          //get the place result
          let place: google.maps.places.PlaceResult = autocomplete.getPlace();       

          for (var i = 0; i < place.address_components.length; i++) {
              var addressType = place.address_components[i].types[0];
              if (this.componentForm[addressType]) {
                var val = place.address_components[i][this.componentForm[addressType]];
                this.contentForm1[addressType] = val;
              }   
            }

          //verify result
          if (place.geometry === undefined || place.geometry === null) {
            return;
          }

          //set latitude, longitude and zoom
          this.latitude = place.geometry.location.lat();
          this.longitude = place.geometry.location.lng();
          this.zoom = 12;
        });
      });
    });

    //load Places Autocomplete
    this.mapsAPILoader.load().then(() => {
      let autocomplete = new google.maps.places.Autocomplete(this.searchElementRef2.nativeElement, {
        types: ["address"]
      });
      autocomplete.addListener("place_changed", () => {
        this.ngZone.run(() => {
          //get the place result
          let place: google.maps.places.PlaceResult = autocomplete.getPlace();

          for (var i = 0; i < place.address_components.length; i++) {
            var addressType = place.address_components[i].types[0];
            if (this.componentForm[addressType]) {
              var val = place.address_components[i][this.componentForm[addressType]];
              this.contentForm2[addressType] = val;
            }   
          }

          //verify result
          if (place.geometry === undefined || place.geometry === null) {
            return;
          }

          //set latitude, longitude and zoom
          this.latitude = place.geometry.location.lat();
          this.longitude = place.geometry.location.lng();
          this.zoom = 12;
        });
      });
    });
  }

  private setCurrentPosition() {
    if ("geolocation" in navigator) {
      navigator.geolocation.getCurrentPosition((position) => {
        this.latitude = position.coords.latitude;
        this.longitude = position.coords.longitude;
        this.zoom = 12;
      });
    }
  }

  private onClickAdd(rate){
    var quote = new Quote();
    quote.From = this.shipment.From;
    quote.To = this.shipment.To;
    quote.QuoteParcel = this.shipment.Parcels[0];
    quote.QuoteRate = rate;
    quote.QuoteDate = new Date();
    this.quote.addShipment(quote);
    
    this.router.navigateByUrl('/shipment');
  }

  onClickBack() {
    // this.showError = false;
    // this.showQuote = false;
    // this.quoteError= "" ;
    // this.loadMapsAutocomplete();

    // this.router.navigateByUrl('/RefrshComponent', {skipLocationChange: true}).then(()=>
    // this.router.navigate(["Your actualComponent"]));

    location.reload();
  }

  onClickMe() {

    this.showError = false;
    this.showQuote = false;
    this.quoteError= "" ;
    this.spinner.show();

    this.shipment = new Shipment();
    
    this.shipment.From = new Shipp();
    this.shipment.From.Name = this.contentForm1.name;
    this.shipment.From.Company = this.contentForm1.company;
    this.shipment.From.StreetNumber = this.contentForm1.street_number;
    this.shipment.From.Street1 =  this.contentForm1.route;
    this.shipment.From.State = this.contentForm1.administrative_area_level_1;
    this.shipment.From.City = this.contentForm1.locality;
    this.shipment.From.Country = this.contentForm1.country;
    this.shipment.From.Zip = this.contentForm1.postal_code;

    this.shipment.To = new Shipp();
    this.shipment.To.Name = this.contentForm2.name;
    this.shipment.To.Company = this.contentForm2.company;
    this.shipment.To.StreetNumber = this.contentForm2.street_number;
    this.shipment.To.Street1 = this.contentForm2.route ;
    this.shipment.To.State = this.contentForm2.administrative_area_level_1;
    this.shipment.To.City = this.contentForm2.locality;
    this.shipment.To.Country = this.contentForm2.country;
    this.shipment.To.Zip = this.contentForm2.postal_code;    

    var parcel = new Parcel();
    parcel.Length =  Number(this.shippment.Length) ;
    parcel.Width  =  Number(this.shippment.width);
    parcel.Height =  Number(this.shippment.height);
    parcel.Distance_unit = 'in';
    parcel.Weight =  Number(this.shippment.weight);
    parcel.Mass_unit = 'lb' ;

    this.shipment.Parcels = new Array<Parcel>();
    this.shipment.Parcels.push(parcel);
    var name = "bob";
    //console.log(this.shipment);
    var response; 

    console.log(JSON.stringify(this.shipment));

    this.http.post(this.baseUrl+'/shipment.json' ,
                   JSON.stringify(this.shipment), httpOptions).subscribe(
      data => {

      this.spinner.hide();

      response = data;
      //console.log(data);
      if(data["error"]!= undefined)
      {
        this.showError = true;
        this.quoteError = "An error happened, please try again.";
        console.log("An Error Happened");
        console.log(data["details"]);
      }

      console.log(data[0]);
      this.rates = new Array<Rate>();
      for (var i =0 ; i < 50 ; i++ ){
        if(data[i] == undefined){
          break;
        }
        var r = new Rate();
        r.Id = data[i]["objectId"];
        r.Image = data[i]["providerImage75"];
        r.Amount = data[i]["amount"];
        r.Currency= data[i]["currency"];
        r.Estimate= data[i]["estimatedDays"];
        r.Provider= data[i]["provider"];
        r.Servicelevel= data[i]["servicelevel"]["name"];
        this.rates.push(r);
        this.rates.sort(function(a, b) {
          if (a.Amount < b.Amount)
            return -1;
          if (a.Amount > b.Amount)
            return 1;
          return 0;
        });
      }

      if(data[0] == undefined){
        this.showError = true;
        this.quoteError = "No results found, please try again.";
      }
      else{
        this.showQuote = true;
      }

    });

  }  

}
