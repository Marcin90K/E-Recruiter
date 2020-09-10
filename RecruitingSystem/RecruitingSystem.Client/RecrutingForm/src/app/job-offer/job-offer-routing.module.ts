import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { JobOfferComponent } from './job-offer.component';
import { FormComponent } from './form/form.component';

const jobOfferChildRoutes: Routes = [
  { path: 'form', component: FormComponent }
];

const routes: Routes = [
  { path: 'job-offers', component: JobOfferComponent,
    children: jobOfferChildRoutes}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class JobOfferRoutingModule { }