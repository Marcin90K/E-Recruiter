import { ConfirmModalComponent } from './shared/components/confirm-modal/confirm-modal.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';


import { NgSelectModule } from '@ng-select/ng-select';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CandidateSharingDataService } from './shared/services/candidate-sharing-data.service';

import { MainTopBarComponent } from './navigations/main-top-bar/main-top-bar.component';
import { HomeComponent } from './home/home.component';
import { CandidateModule } from './candidate/candidate.module';
import { HttpClientModule } from '@angular/common/http';
import { AuthModule } from './auth/auth.module';
import { DatePipe } from '@angular/common';
import { JobOfferModule } from './job-offer/job-offer.module';
import { RecruitmentPanelComponent } from './recruitment-panel/recruitment-panel.component';
import { SubmittedPageComponent } from './shared/submitted-page/submitted-page.component';
import { NgbModalModule } from '@ng-bootstrap/ng-bootstrap';
import { WidgetComponent } from './shared/components/widget/widget.component';
import { AdminPanelComponent } from './admin-panel/admin-panel.component';

@NgModule({
  declarations: [
    AppComponent,
    MainTopBarComponent,
    HomeComponent,
    RecruitmentPanelComponent,
    SubmittedPageComponent,
    ConfirmModalComponent,
    WidgetComponent,
    AdminPanelComponent
  ],
  imports: [
    BrowserModule,
    NgSelectModule,
    FormsModule,
    ReactiveFormsModule,
    AuthModule,
    CandidateModule,
    JobOfferModule,
    HttpClientModule,
    AppRoutingModule,
    NgbModalModule
  ],
  providers: [
    CandidateSharingDataService,
    DatePipe
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
