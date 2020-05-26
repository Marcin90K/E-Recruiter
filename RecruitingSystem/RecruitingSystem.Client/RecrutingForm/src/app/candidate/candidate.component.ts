import { Component, OnInit, NgModule } from '@angular/core';
import { JobPosition } from '../shared/models/job-position';
import { JOBPOSITIONS } from '../shared/models/opened-jobs';
import {FormControl, FormGroup, ReactiveFormsModule, FormsModule} from '@angular/forms';
import {NgSelectModule, NgOption} from '@ng-select/ng-select';
import { CandidateSharingDataService } from '../shared/services/candidate-sharing-data.service';
import { CandidateForCreation } from '../shared/models/Candidate/candidate-for-creation';


@Component({
  selector: 'app-candidate',
  templateUrl: './candidate.component.html',
  styleUrls: ['./candidate.component.css']
})
export class CandidateComponent implements OnInit {

  candidateData: CandidateForCreation;
  jobPositionApplied: JobPosition;
  salary: number;
  additionalNotes: string;
  personalDataProccedingAgreed: boolean;
  jobsAvailable: JobPosition[];

  constructor(private candidateDataService: CandidateSharingDataService) {
    this.jobPositionApplied = {
      id: 0, name: ''
    }
    this.candidateData = {} as CandidateForCreation;
  }

  ngOnInit() {
    this.jobsAvailable = JOBPOSITIONS;
    this.candidateDataService.getCandidateBasicData().subscribe(res => {
      this.candidateData.candidateBasicData = Object.assign({}, res);
    });
  }

  submit() {
     console.log("test");
     console.log(this.candidateData.candidateBasicData);
  }

}
