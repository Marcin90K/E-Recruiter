import { AdminPanelComponent } from './admin-panel/admin-panel.component';
import { RecruitmentPanelComponent } from './recruitment-panel/recruitment-panel.component';
import { HomeComponent } from './home/home.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BasicInfoComponent } from './candidate/basic-info/basic-info.component';
import { EducationComponent } from './candidate/education/education.component';
import { ExperienceComponent } from './candidate/experience/experience.component';
import { SummaryComponent } from './candidate/summary/summary.component';
import { IntroComponent } from './candidate/intro/intro.component';
import { SubmittedComponent } from './candidate/submitted/submitted.component';
import { CandidateComponent } from './candidate/candidate.component';
import { AuthComponent } from './auth/auth.component';
import { JobOfferComponent } from './job-offer/job-offer.component';

const routes: Routes = [
  { path: 'candidate', component: CandidateComponent },
  { path: 'job-offers', component: JobOfferComponent },
  { path: 'recruitment-panel', component: RecruitmentPanelComponent },
  { path: 'recruitment-panel/:id', component: RecruitmentPanelComponent },
  { path: 'submitted', component: SubmittedComponent},
  { path: 'home', component: HomeComponent },
  { path: 'admin-panel', component: AdminPanelComponent },
  { path: 'auth', component: AuthComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
