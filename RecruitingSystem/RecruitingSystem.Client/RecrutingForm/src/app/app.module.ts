import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';


import { NgSelectModule } from '@ng-select/ng-select';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CandidateDataService } from './services/candidate-data.service';

import { MainTopBarComponent } from './navigations/main-top-bar/main-top-bar.component';
import { HomeComponent } from './home/home.component';
import { CandidateModule } from './candidate/candidate.module';


@NgModule({
  declarations: [
    AppComponent,
    MainTopBarComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    NgSelectModule,
    FormsModule,
    ReactiveFormsModule,
    CandidateModule,
    AppRoutingModule,
  ],
  providers: [CandidateDataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
