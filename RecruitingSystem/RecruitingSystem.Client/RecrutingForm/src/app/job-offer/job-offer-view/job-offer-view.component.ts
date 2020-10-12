import { JobOfferService } from './../../shared/services/job-offer.service';
import { Component, OnInit } from '@angular/core';
import { JobOfferVM } from 'src/app/shared/models/job-offer/job-offer-vm';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-job-offer-view',
  templateUrl: './job-offer-view.component.html',
  styleUrls: ['./job-offer-view.component.css']
})
export class JobOfferViewComponent implements OnInit {

  private viewModel: JobOfferVM;
  private jobOfferId: string;

  constructor(private jobOfferService: JobOfferService,
              private activatedRoute: ActivatedRoute ) {
    this.jobOfferId = this.activatedRoute.snapshot.parent.params['id'];
    console.log(this.jobOfferId);

    this.jobOfferService.getJobOffer(this.jobOfferId).subscribe(
      result => {
        this.viewModel = result;
        console.log(this.viewModel);
      },
      error => console.log(error)
    );
  }

  ngOnInit() {
  }

}
