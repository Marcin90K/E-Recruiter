import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CandidateForCreation } from '../models/Candidate/candidate-for-creation';
import { CandidateCreated } from '../models/candidate/candidate-created';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

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
    return this.http.post<CandidateCreated>(this.baseUrl, candidate);
  }
}
