import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CandidateRoutingModule } from './candidate-routing.module';
import { BasicInfoComponent } from './basic-info/basic-info.component';
import { EducationComponent } from './education/education.component';
import { ExperienceComponent } from './experience/experience.component';
import { IntroComponent } from './intro/intro.component';
import { SummaryComponent } from './summary/summary.component';
import { SubmittedComponent } from './submitted/submitted.component';
import { CandidateComponent } from './candidate.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { NgSelectModule } from '@ng-select/ng-select';
import { SplitCamelcasePipe } from './pipes/split-camelcase.pipe';

@NgModule({
  declarations: [
    BasicInfoComponent,
    EducationComponent,
    ExperienceComponent,
    IntroComponent,
    SummaryComponent,
    SubmittedComponent,
    CandidateComponent,
    SplitCamelcasePipe
  ],
  imports: [
    NgSelectModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    CandidateRoutingModule
  ]
})
export class CandidateModule { }
