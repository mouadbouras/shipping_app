import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NavigationComponent } from './navigation/navigation.component';
import { GetquoteComponent } from './getquote/getquote.component';
import { AppComponent } from './app.component';


const routes: Routes = [
  {
    path:"quote",
    component:GetquoteComponent
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
