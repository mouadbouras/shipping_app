import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NavigationComponent } from './navigation/navigation.component';
import { GetquoteComponent } from './getquote/getquote.component';
import { AppComponent } from './app.component';
import { MyquotesComponent } from './myquotes/myquotes.component';
import { ShipmentComponent } from './shipment/shipment.component';
import { MyshipmentsComponent } from './myshipments/myshipments.component';
import { LandingComponent } from './landing/landing.component';


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
  }       

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
