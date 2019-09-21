import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BasicInfoComponent } from './candidate-data/basic-info/basic-info.component';
import { EducationComponent } from './candidate-data/education/education.component';
import { ExperienceComponent } from './candidate-data/experience/experience.component';
import { SummaryComponent } from './candidate-data/summary/summary.component';
import { IntroComponent } from './candidate-data/intro/intro.component';
import { SubmittedComponent } from './shared/submitted/submitted.component';

const routes: Routes = [
  { path: 'intro', component: IntroComponent },
  { path: 'basic', component: BasicInfoComponent },
  { path: 'education', component: EducationComponent },
  { path: 'experience', component: ExperienceComponent },
  { path: 'summary', component: SummaryComponent},
  { path: 'submitted', component: SubmittedComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
