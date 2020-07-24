import { Component, OnInit } from '@angular/core';
import { JobPositionVM } from 'src/app/shared/models/job-position/job-position-vm';
import { JOBPOSITIONS } from 'src/app/shared/models/opened-jobs';
import { JobBasicInfo } from 'src/app/shared/models/basic-job-info';
import { CandidateSharingDataService } from 'src/app/shared/services/candidate-sharing-data.service';
import { CandidateVM } from 'src/app/shared/models/candidate/candidate-vm';
import { CandidateListVM } from 'src/app/shared/models/candidate/candidate-list-vm';
import { CandidateService } from 'src/app/shared/services/candidate.service';

@Component({
  selector: 'app-intro',
  templateUrl: './intro.component.html',
  styleUrls: ['./intro.component.css']
})
export class IntroComponent implements OnInit {

  jobsAvailable: JobPositionVM[];
  model: JobBasicInfo;

  candidateTest: CandidateVM;
  candidatesTest: CandidateListVM;
  candidateTestString: string;
  candidatesTestString: string;

  constructor(private candidateDataServive: CandidateSharingDataService,
              private candidateService: CandidateService) {
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
