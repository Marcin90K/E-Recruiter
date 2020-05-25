import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { IntroComponent } from './intro/intro.component';
import { BasicInfoComponent } from './basic-info/basic-info.component';
import { EducationComponent } from './education/education.component';
import { ExperienceComponent } from './experience/experience.component';
import { SummaryComponent } from './summary/summary.component';
import { SubmittedComponent } from './submitted/submitted.component';
import { CandidateComponent } from './candidate.component';

const routes: Routes = [
  { path: 'candidate', component: CandidateComponent,
    children: [
      { path: 'intro', component: IntroComponent },
      { path: 'basic-info', component: BasicInfoComponent },
      { path: 'education', component: EducationComponent },
      { path: 'experience', component: ExperienceComponent },
      { path: 'summary', component: SummaryComponent},
      { path: 'submitted', component: SubmittedComponent },
      { path: '', redirectTo: '/intro', pathMatch: 'full' }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CandidateRoutingModule { }
