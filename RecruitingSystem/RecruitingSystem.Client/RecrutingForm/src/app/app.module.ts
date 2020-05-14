import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CandidateDataComponent } from './candidate-data/candidate-data.component';
import { BasicInfoComponent } from './candidate-data/basic-info/basic-info.component';
import { EducationComponent } from './candidate-data/education/education.component';
import { ExperienceComponent } from './candidate-data/experience/experience.component';

import { NgSelectModule } from '@ng-select/ng-select';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CandidateDataService } from './services/candidate-data.service';
import { IntroComponent } from './candidate-data/intro/intro.component';
import { SummaryComponent } from './candidate-data/summary/summary.component';
import { BasicInfoFormComponent } from './candidate-data/basic-info/basic-info-form/basic-info-form.component';
import { SubmittedComponent } from './shared/submitted/submitted.component';
import { MainTopBarComponent } from './navigations/main-top-bar/main-top-bar.component';


@NgModule({
  declarations: [
    AppComponent,
    CandidateDataComponent,
    BasicInfoComponent,
    EducationComponent,
    ExperienceComponent,
    IntroComponent,
    SummaryComponent,
    BasicInfoFormComponent,
    SubmittedComponent,
    MainTopBarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgSelectModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [CandidateDataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
