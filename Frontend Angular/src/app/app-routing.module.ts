import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NavigationComponent } from './navigation/navigation.component';
import { GetquoteComponent } from './getquote/getquote.component';
import { AppComponent } from './app.component';
import { MyquotesComponent } from './myquotes/myquotes.component';


const routes: Routes = [
  {
    path:"quote",
    component:GetquoteComponent
  },
  {
    path:"myquotes",
    component:MyquotesComponent
  }  

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
