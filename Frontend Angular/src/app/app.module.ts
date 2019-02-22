import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule} from '@angular/forms';

import { HttpClientModule ,HTTP_INTERCEPTORS} from '@angular/common/http'; 
import { HttpModule } from '@angular/http';
import { AgmCoreModule } from '@agm/core';

import { NgxSpinnerModule } from 'ngx-spinner';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { QuoteService } from './services/quote.service';
import { FormService } from './services/form.service';
import { UserService } from './services/user.service';
import { AlertService } from './services/alert.service';
import { AuthenticationService } from './services/authentication.service';


import { MyquotesComponent } from './myquotes/myquotes.component';
import { ShipmentComponent } from './shipment/shipment.component';
import { MyshipmentsComponent } from './myshipments/myshipments.component';
import { FormshipmentComponent } from './formshipment/formshipment.component';
import { LandingComponent } from './landing/landing.component';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { GetquoteComponent } from './getquote/getquote.component';
import { NavigationComponent } from './navigation/navigation.component';
import { GetratesComponent } from './getrates/getrates.component';

import { BasicAuthInterceptor } from './util/basic-auth.util';
import { AlertComponent } from './alert/alert.component';



@NgModule({
  declarations: [
    AppComponent,
    GetquoteComponent,
    NavigationComponent,
    GetratesComponent,
    MyquotesComponent,
    ShipmentComponent,
    MyshipmentsComponent,
    FormshipmentComponent,
    LandingComponent,
    LoginComponent,
    SignupComponent,
    AlertComponent,
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
    HttpClientModule,
    NgxSpinnerModule    
  ],
  providers: [
                QuoteService, FormService,UserService,AlertService,AuthenticationService,
                { provide: HTTP_INTERCEPTORS, useClass: BasicAuthInterceptor, multi: true }
              ],
  bootstrap: [AppComponent]
})
export class AppModule { }
