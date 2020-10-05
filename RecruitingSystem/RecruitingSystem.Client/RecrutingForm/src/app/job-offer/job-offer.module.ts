import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { JobOfferRoutingModule } from './job-offer-routing.module';
import { JobOfferComponent } from './job-offer.component';
import { FormComponent } from './form/form.component';
import { NgSelectModule } from '@ng-select/ng-select';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FormEditComponent } from './form-edit/form-edit.component';

@NgModule({
  declarations: [JobOfferComponent, FormComponent, FormEditComponent],
  imports: [
    CommonModule,
    NgSelectModule,
    FormsModule,
    ReactiveFormsModule,
    JobOfferRoutingModule
  ]
})
export class JobOfferModule { }
