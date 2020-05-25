import { Component, OnInit } from '@angular/core';
import { JobPosition } from 'src/app/models/job-position';
import { JOBPOSITIONS } from 'src/app/models/opened-jobs';
import { JobBasicInfo } from 'src/app/models/basic-job-info';
import { CandidateDataService } from 'src/app/services/candidate-data.service';

@Component({
  selector: 'app-intro',
  templateUrl: './intro.component.html',
  styleUrls: ['./intro.component.css']
})
export class IntroComponent implements OnInit {

  jobsAvailable: JobPosition[];
  model: JobBasicInfo;

  constructor(private candidateDataServive: CandidateDataService) {
    this.model = {
      jobPositionAppliedId: 0,
      expectedSalary: 0
    };
  }

  ngOnInit() {
    this.jobsAvailable = JOBPOSITIONS;
  }

  apply() {
    this.candidateDataServive.updateJobBasicInfo(this.model);
    console.log(this.model);
  }

}
