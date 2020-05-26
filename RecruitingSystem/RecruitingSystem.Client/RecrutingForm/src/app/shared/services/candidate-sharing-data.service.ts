import { Injectable } from '@angular/core';
import { CandidateBasicData } from '../models/candidate-basic-data';
import { Subject, Observable, BehaviorSubject } from 'rxjs';
import { CandidateEducation } from '../models/candidate-education';
import { CandidateExperience } from '../models/candidate-experience';
import { JobBasicInfo } from '../models/basic-job-info';

@Injectable({
  providedIn: 'root'
})
export class CandidateSharingDataService {

  private jobBasicInfo = new BehaviorSubject<JobBasicInfo>(null);
  private candidateBasicData = new BehaviorSubject<CandidateBasicData>(null);
  private candidateEducationData = new BehaviorSubject<CandidateEducation[]>([]);
  private candidateExperienceData = new BehaviorSubject<CandidateExperience[]>([]);

  constructor() { }

  // Updates basic job data after submitting changes within intro page
  updateJobBasicInfo(jobData: JobBasicInfo) {
    this.jobBasicInfo.next(jobData);
  }

  // Gets current basic job data within any other component
  getJobBasicInfo(): Observable<JobBasicInfo> {
    return this.jobBasicInfo.asObservable();
  }


  // Updates candidate basic data after submitting changes
  updateCandidateBasicData(basicData: CandidateBasicData) {
    // const basicData = this.candidateBasicData;
    this.candidateBasicData.next(basicData);
  }

  // Gets current candidate's basic data
  getCandidateBasicData(): Observable<CandidateBasicData> {
    return this.candidateBasicData.asObservable();
  }


  // Adds candidate education data single item
  addCandidateEducationDataItem(educationItem: CandidateEducation) {
    const educationItemCollection = this.candidateEducationData.getValue();
    educationItemCollection.push(educationItem);
    this.candidateEducationData.next(educationItemCollection);
  }

  // Updates candidate education data after submitting changes
  updateCandidateEducationData(educationData: CandidateEducation[]) {
    this.candidateEducationData.next(educationData);
  }

  // Gets current candidate's education data
  getCandidateEducationData(): Observable<CandidateEducation[]> {
    return this.candidateEducationData.asObservable();
  }


  // Updates candidate experience data after submitting changes
  updateCandidateExperienceData(experienceData: CandidateExperience[]) {
    this.candidateExperienceData.next(experienceData);
  }

  // Gets current candidate's education data
  getCandidateExperienceData(): Observable<CandidateExperience[]> {
    return this.candidateExperienceData.asObservable();
  }



}
