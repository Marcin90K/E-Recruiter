import { Injectable } from '@angular/core';
import { Subject, Observable, BehaviorSubject } from 'rxjs';
import { EducationForManipulation } from '../models/education/education-for-manipulation';
import { ExperienceForManipulation } from '../models/experience/experience-for-manipulation';
import { JobBasicInfo } from '../models/basic-job-info';
import { CandidateBasicDataForManipulation } from '../models/candidate-basic-data/candidate-basic-data-for-manipulation';

@Injectable({
  providedIn: 'root'
})
export class CandidateSharingDataService {

  private jobBasicInfo = new BehaviorSubject<JobBasicInfo>(null);
  private candidateBasicData = new BehaviorSubject<CandidateBasicDataForManipulation>(null);
  private candidateEducationData = new BehaviorSubject<EducationForManipulation[]>([]);
  private candidateExperienceData = new BehaviorSubject<ExperienceForManipulation[]>([]);

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
  updateCandidateBasicData(basicData: CandidateBasicDataForManipulation) {
    // const basicData = this.candidateBasicData;
    this.candidateBasicData.next(basicData);
  }

  // Gets current candidate's basic data
  getCandidateBasicData(): Observable<CandidateBasicDataForManipulation> {
    return this.candidateBasicData.asObservable();
  }


  // Adds candidate education data single item
  addCandidateEducationDataItem(educationItem: EducationForManipulation) {
    const educationItemCollection = this.candidateEducationData.getValue();
    educationItemCollection.push(educationItem);
    this.candidateEducationData.next(educationItemCollection);
  }

  // Updates candidate education data after submitting changes
  updateCandidateEducationData(educationData: EducationForManipulation[]) {
    this.candidateEducationData.next(educationData);
  }

  // Gets current candidate's education data
  getCandidateEducationData(): Observable<EducationForManipulation[]> {
    return this.candidateEducationData.asObservable();
  }


  // Updates candidate experience data after submitting changes
  updateCandidateExperienceData(experienceData: ExperienceForManipulation[]) {
    this.candidateExperienceData.next(experienceData);
  }

  // Gets current candidate's education data
  getCandidateExperienceData(): Observable<ExperienceForManipulation[]> {
    return this.candidateExperienceData.asObservable();
  }



}
