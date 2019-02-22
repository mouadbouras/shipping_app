import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NavigationComponent } from './navigation/navigation.component';
import { GetquoteComponent } from './getquote/getquote.component';
import { AppComponent } from './app.component';
import { MyquotesComponent } from './myquotes/myquotes.component';
import { ShipmentComponent } from './shipment/shipment.component';
import { MyshipmentsComponent } from './myshipments/myshipments.component';
import { LandingComponent } from './landing/landing.component';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';


const routes: Routes = [
  {
    path:"",
    component:LandingComponent
  },
  {
    path:"quote",
    component:GetquoteComponent
  },
  {
    path:"myquotes",
    component:MyquotesComponent
  },
  {
    path:"shipment",
    component:ShipmentComponent
  },
  {
    path:"myshipments",
    component:MyshipmentsComponent
  },
  {
    path:"login",
    component:LoginComponent
  },
  {
    path:"signup",
    component:SignupComponent
  }       


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
