import { JobOfferService } from './../../shared/services/job-offer.service';
import { Component, OnInit } from '@angular/core';
import { JobOfferVM } from 'src/app/shared/models/job-offer/job-offer-vm';
import { ActivatedRoute } from '@angular/router';
import { DatePipe } from '@angular/common';

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

  private jobOfferId: string;
  private dateOfExpiration: string;
  private dateFormat = 'yyyy-MM-dd';

  constructor(private jobOfferService: JobOfferService,
              private activatedRoute: ActivatedRoute,
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

  }

  parseDate(date: Date) {
    return this.datePipe.transform(date, this.dateFormat);
  }

}
