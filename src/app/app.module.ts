import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { GetquoteComponent } from './getquote/getquote.component';
import { NavigationComponent } from './navigation/navigation.component';
import { AgmCoreModule } from '@agm/core';


@NgModule({
  declarations: [
    AppComponent,
    GetquoteComponent,
    NavigationComponent
  ],
  imports: [
    AgmCoreModule.forRoot({
      apiKey: "AIzaSyAbDeKOF_eWUYzt35rgf6Qoj4jYD8hKNQo",
      libraries: ["places"]
    }),
    BrowserModule,
    AppRoutingModule,
    FormsModule, ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
