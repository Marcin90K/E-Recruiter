import { JobOfferService } from './../shared/services/job-offer.service';
import { Component, OnInit } from '@angular/core';
import { JobOfferVM } from '../shared/models/job-offer/job-offer-vm';
import { JobOfferListVM } from '../shared/models/job-offer/job-offer-list-vm';
import { Router } from '@angular/router';

@Component({
  selector: 'app-recruitment-panel',
  templateUrl: './recruitment-panel.component.html',
  styleUrls: ['./recruitment-panel.component.css']
})
export class RecruitmentPanelComponent implements OnInit {

  isAdmin = false;

  jobOffersListVM: JobOfferListVM = {
    jobOffers: null,
    pagination: null
  };

  constructor(private jobOfferService: JobOfferService,
              private routerService: Router) {
    this.jobOfferService.getJobOffers().subscribe(
      res => this.jobOffersListVM = res,
      error => console.log(error)
    );
  }

  ngOnInit() {
  }

  apply(offer: JobOfferVM) {
    this.routerService.navigate(['../job-offers', offer.id, 'view']);
  }

}
