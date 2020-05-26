import { Component, OnInit } from '@angular/core';
import { JobPosition } from 'src/app/shared/models/job-position';
import { JOBPOSITIONS } from 'src/app/shared/models/opened-jobs';
import { JobBasicInfo } from 'src/app/shared/models/basic-job-info';
import { CandidateSharingDataService } from 'src/app/shared/services/candidate-sharing-data.service';

@Component({
  selector: 'app-intro',
  templateUrl: './intro.component.html',
  styleUrls: ['./intro.component.css']
})
export class IntroComponent implements OnInit {

  jobsAvailable: JobPosition[];
  model: JobBasicInfo;

  constructor(private candidateDataServive: CandidateSharingDataService) {
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
