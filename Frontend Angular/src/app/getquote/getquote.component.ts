import { Component,ElementRef, NgZone, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
/// <reference types="@types/googlemaps" />
import { MapsAPILoader } from '@agm/core';
import { QuoteService } from '../Services/quote.service';
import { Observable } from 'rxjs';
import { Shipment } from '../Model/shipment.model';
import { Parcel } from '../Model/parcel.model';
import { Shipp } from '../Model/shipp.model';

import { HttpClient } from '@angular/common/http'; 

import { HttpHeaders } from '@angular/common/http';

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

  constructor(
    private mapsAPILoader: MapsAPILoader,
    private ngZone: NgZone,
    private quote: QuoteService,
    private http: HttpClient
  ) {

  }
  public shipment : Shipment;
  public latitude: number;
  public longitude: number;
  public searchControl1: FormControl;
  public searchControl2: FormControl;
  public zoom: number;

  public shippment = {
    date: '',
    quantity:0,
    weight:0
  };   
 
  onClickMe() {
    this.shipment = new Shipment();
    this.shipment.From = new Shipp();
    this.shipment.From.Name = this.contentForm1.name;
    this.shipment.From.Street1 = this.contentForm1.street_number + " " + this.contentForm1.route;
    this.shipment.From.State = this.contentForm1.administrative_area_level_1;
    this.shipment.From.City = this.contentForm1.locality;
    this.shipment.From.Country = this.contentForm1.country;
    this.shipment.From.Zip = this.contentForm1.postal_code;

    this.shipment.To = new Shipp();
    this.shipment.To.Name = this.contentForm2.name;
    this.shipment.To.Street1 = this.contentForm2.street_number + this.contentForm1.route;
    this.shipment.To.State = this.contentForm2.administrative_area_level_1;
    this.shipment.To.City = this.contentForm2.locality;
    this.shipment.To.Country = this.contentForm2.country;
    this.shipment.To.Zip = this.contentForm2.postal_code;    

    var parcel = new Parcel();
    parcel.Length =  this.shippment.weight ;
    parcel.Width  = 1;
    parcel.Height = 1;
    parcel.Distance_unit = 'in';
    parcel.Weight = 10;
    parcel.Mass_unit = 'lb' ;

    this.shipment.Parcels = new Array<Parcel>();
    this.shipment.Parcels.push(parcel);
    var name = "bob";
    //console.log(this.shipment);
    var response; 

    console.log(JSON.stringify(this.shipment));

    this.http.post('http://localhost:5000/shipment.json' , JSON.stringify(this.shipment), httpOptions).subscribe(
      data => {
      response = data;
      console.log(data);
    });

  }

  public componentForm = {
    street_number: 'short_name',
    route: 'long_name',
    locality: 'long_name',
    administrative_area_level_1: 'short_name',
    country: 'long_name',
    postal_code: 'short_name'
  };

  public contentForm1 = {
    name :'person1',
    street_number: '',
    route: '',
    locality: '',
    administrative_area_level_1: '',
    country: '',
    postal_code: ''
  };
  
  public contentForm2 = {
    name :'person2',
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


  ngOnInit() {
    this.quote.shipment.subscribe(
      resShipment => this.shipment = resShipment
    );

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

}
