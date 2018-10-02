import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { GetquoteComponent } from './getquote/getquote.component';
import { NavigationComponent } from './navigation/navigation.component';
import { AgmCoreModule } from '@agm/core';
import { GetratesComponent } from './getrates/getrates.component';
import { QuoteService } from './Services/quote.service';
import { HttpClientModule } from '@angular/common/http'; 
import { HttpModule } from '@angular/http';



@NgModule({
  declarations: [
    AppComponent,
    GetquoteComponent,
    NavigationComponent,
    GetratesComponent
  ],
  imports: [
    AgmCoreModule.forRoot({
      apiKey: "AIzaSyAbDeKOF_eWUYzt35rgf6Qoj4jYD8hKNQo",
      libraries: ["places"]
    }),
    BrowserModule,
    AppRoutingModule,
    FormsModule, 
    ReactiveFormsModule,
    HttpModule,
    HttpClientModule    
  ],
  providers: [QuoteService],
  bootstrap: [AppComponent]
})
export class AppModule { }
