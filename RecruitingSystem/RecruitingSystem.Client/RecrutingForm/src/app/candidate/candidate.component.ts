import { Component, OnInit, NgModule } from '@angular/core';
import { JobPosition } from '../models/job-position';
import { JOBPOSITIONS } from '../models/opened-jobs';
import {FormControl, FormGroup, ReactiveFormsModule, FormsModule} from '@angular/forms';
import {NgSelectModule, NgOption} from '@ng-select/ng-select';
import { CandidateDataService } from '../services/candidate-data.service';
import { CandidateProfile } from '../models/candidate-profile';


@Component({
  selector: 'app-candidate',
  templateUrl: './candidate.component.html',
  styleUrls: ['./candidate.component.css']
})
export class CandidateComponent implements OnInit {

  candidateData: CandidateProfile;
  jobPositionApplied: JobPosition;
  salary: number;
  additionalNotes: string;
  personalDataProccedingAgreed: boolean;
  jobsAvailable: JobPosition[];

  constructor(private candidateDataService: CandidateDataService) {
    this.jobPositionApplied = {
      id: 0, name: ''
    }
    this.candidateData = {} as CandidateProfile;
  }

  ngOnInit() {
    this.jobsAvailable = JOBPOSITIONS;
    this.candidateDataService.getCandidateBasicData().subscribe(res => {
      this.candidateData.basicInfo = Object.assign({}, res);
    });
  }

  submit() {
     console.log("test");
     console.log(this.candidateData.basicInfo);
  }

}
