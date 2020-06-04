import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { CandidateForCreation } from '../models/Candidate/candidate-for-creation';
import { CandidateCreated } from '../models/candidate/candidate-created';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { EducationForManipulation } from '../models/education/education-for-manipulation';
import { ExperienceForManipulation } from '../models/experience/experience-for-manipulation';
import { CandidateVM } from '../models/candidate/candidate-vm';
import { CandidateListVM } from '../models/candidate/candidate-list-vm';
import { CandidateForUpdate } from '../models/candidate/candidate-for-update';
import { CandidateUpdated } from '../models/candidate/candidate-updated';

@Injectable({
  providedIn: 'root'
})
export class CandidateService {

  private baseUrl: string;
  private section = 'candidate';
  private searchParam = 'search';
  private pageNumber = 'pageNumber';
  private pageSize = 'pageSize';

  constructor(private http: HttpClient) {
    this.baseUrl = environment.API_URL + this.section;
   }


  getCandidate(id: string): Observable<CandidateVM> {
    let url = this.baseUrl + '/' + id;
    return this.http.get<CandidateVM>(url);
  }


  getCandidates(search = '' , pageNumber = 1, pageSize = 10): Observable<CandidateListVM> {
    const options = {
      params: new HttpParams().set(this.searchParam, search)
                              .set(this.pageNumber, pageNumber.toString())
                              .set(this.pageSize, pageSize.toString())
    };
    return this.http.get<CandidateListVM>(this.baseUrl, options);
  }


  addCandidate(candidate: CandidateForCreation): Observable<CandidateCreated> {
    candidate.educations = candidate.educations['educationItems'] as EducationForManipulation[];
    candidate.experiences = candidate.experiences['experienceItems'] as ExperienceForManipulation[];

    console.log('Candidate for creation: ' + JSON.stringify(candidate));

    return this.http.post<CandidateCreated>(this.baseUrl, candidate);
  }

  updateCandidate(candidate: CandidateForUpdate): Observable<CandidateUpdated> {
    let url = this.baseUrl + '/' + candidate.id;
    candidate.educations = candidate.educations['educationItems'] as EducationForManipulation[]
    candidate.experiences = candidate.experiences['experienceItems'] as ExperienceForManipulation[];

    console.log('Candidate for update: ' + JSON.stringify(candidate));

    return this.http.put<CandidateUpdated>(url, candidate);
  }

  deleteCandidate(id: string): Observable<{}> {
    let url = this.baseUrl + '/' + id;
    return this.http.delete(url);
  }
}
