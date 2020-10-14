import { JobOfferService } from './../../shared/services/job-offer.service';
import { Component, OnInit } from '@angular/core';
import { JobOfferVM } from 'src/app/shared/models/job-offer/job-offer-vm';
import { ActivatedRoute, Router } from '@angular/router';
import { DatePipe } from '@angular/common';
import { CandidateSharingDataService } from 'src/app/shared/services/candidate-sharing-data.service';
import { CandidateVM } from 'src/app/shared/models/candidate/candidate-vm';

@Component({
  selector: 'app-job-offer-view',
  templateUrl: './job-offer-view.component.html',
  styleUrls: ['./job-offer-view.component.css']
})
export class JobOfferViewComponent implements OnInit {

  private viewModel: JobOfferVM = {
    id: '',
    jobPosition: {
      id: '',
      name: ''
    },
    description: '',
    dateOfAdding: null,
    dateOfExpiration: null,
    requirements: '',
    owner: null
  };

  private candidate: CandidateVM;

  private jobOfferId: string;
  private dateOfExpiration: string;
  private dateFormat = 'yyyy-MM-dd';

  constructor(private jobOfferService: JobOfferService,
              private candidateDataService: CandidateSharingDataService,
              private activatedRoute: ActivatedRoute,
              private router: Router,
              private datePipe: DatePipe ) {
    this.jobOfferId = this.activatedRoute.snapshot.parent.params['id'];
    console.log(this.jobOfferId);

    this.jobOfferService.getJobOffer(this.jobOfferId).subscribe(
      result => {
        this.viewModel = result;
        this.dateOfExpiration = this.parseDate(this.viewModel.dateOfExpiration);
        console.log(this.viewModel);
      },
      error => console.log(error)
    );
  }

  ngOnInit() {
  }


  apply() {
    this.router.navigate(['submitted']);
  }

  parseDate(date: Date) {
    return this.datePipe.transform(date, this.dateFormat);
  }

}
