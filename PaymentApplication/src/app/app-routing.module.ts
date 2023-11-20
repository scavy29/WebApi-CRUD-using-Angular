import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PayComponent } from './pay/pay.component';


const routes: Routes = [
  {path:"" , component:PayComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
