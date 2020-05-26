import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CandidateForCreation } from '../models/Candidate/candidate-for-creation';

@Injectable({
  providedIn: 'root'
})
export class CandidateService {

  constructor(private http: HttpClient) { }

  //addCandidate(candidate: CandidateProfile): Observable< {

  //}
}
