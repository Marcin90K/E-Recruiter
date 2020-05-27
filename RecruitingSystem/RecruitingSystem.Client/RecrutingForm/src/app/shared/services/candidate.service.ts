import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CandidateForCreation } from '../models/Candidate/candidate-for-creation';
import { CandidateCreated } from '../models/candidate/candidate-created';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { EducationForManipulation } from '../models/education/education-for-manipulation';
import { ExperienceForManipulation } from '../models/experience/experience-for-manipulation';
import { catchError } from 'rxjs/operators';
import { ErrorHandlerService } from './error-handler.service';

@Injectable({
  providedIn: 'root'
})
export class CandidateService {

  private baseUrl: string;
  private section = 'candidate';

  constructor(private http: HttpClient) {
    this.baseUrl = environment.API_URL + this.section;
   }

  addCandidate(candidate: CandidateForCreation): Observable<CandidateCreated> {
    candidate.educations = candidate.educations['educationItems'] as EducationForManipulation[];
    candidate.experiences = candidate.experiences['experienceItems'] as ExperienceForManipulation[];

    console.log('Candidate for sending: ' + JSON.stringify(candidate));

    return this.http.post<CandidateCreated>(this.baseUrl, candidate);
  }
}
