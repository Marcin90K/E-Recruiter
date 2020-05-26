import { Component, OnInit, NgModule } from '@angular/core';
import { JobPosition } from '../shared/models/job-position';
import { JOBPOSITIONS } from '../shared/models/opened-jobs';
import {FormControl, FormGroup, ReactiveFormsModule, FormsModule} from '@angular/forms';
import {NgSelectModule, NgOption} from '@ng-select/ng-select';
import { CandidateSharingDataService } from '../shared/services/candidate-sharing-data.service';
import { CandidateProfile } from '../shared/models/candidate-profile';


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

  constructor(private candidateDataService: CandidateSharingDataService) {
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
