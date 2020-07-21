import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { JobOfferRoutingModule } from './job-offer-routing.module';
import { JobOfferComponent } from './job-offer.component';
import { FormComponent } from './form/form.component';

@NgModule({
  declarations: [JobOfferComponent, FormComponent],
  imports: [
    CommonModule,
    JobOfferRoutingModule
  ]
})
export class JobOfferModule { }
