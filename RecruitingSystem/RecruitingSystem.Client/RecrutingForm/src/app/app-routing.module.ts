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
  // { path: 'intro', component: IntroComponent },
  // { path: 'basic', component: BasicInfoComponent },
  // { path: 'education', component: EducationComponent },
  // { path: 'experience', component: ExperienceComponent },
  // { path: 'summary', component: SummaryComponent},
  // { path: 'submitted', component: SubmittedComponent }
  { path: 'candidate', component: CandidateComponent },
  { path: 'job-offers', component: JobOfferComponent },
  { path: 'home', component: HomeComponent },
  { path: 'auth', component: AuthComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
