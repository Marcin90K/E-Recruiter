import { JobOfferSharingDataService } from './../shared/services/job-offer-sharing-data.service';
import { CandidateSharingDataService } from './../shared/services/candidate-sharing-data.service';
import { JobOfferService } from './../shared/services/job-offer.service';
import { Component, Input, OnInit } from '@angular/core';
import { JobOfferVM } from '../shared/models/job-offer/job-offer-vm';
import { JobOfferListVM } from '../shared/models/job-offer/job-offer-list-vm';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-recruitment-panel',
  templateUrl: './recruitment-panel.component.html',
  styleUrls: ['./recruitment-panel.component.css']
})
export class RecruitmentPanelComponent implements OnInit {

  isAdmin = false;


  @Input() title = 'Opened Job Offers';
  private candidateSearchQuery = '';

  jobOffersListVM: JobOfferListVM = {
    jobOffers: null,
    pagination: null
  };

  constructor(private candidateSharingDataService: CandidateSharingDataService,
              private jobOfferService: JobOfferService,
              private routerService: Router,
              private activatedRouteService: ActivatedRoute,
              private jobOfferSharingDataService: JobOfferSharingDataService) {

    this.candidateSharingDataService.getCandidateViewModel().subscribe(
      result => {
        this.isAdmin = result ? false : true;
      }
    );

    this.checkSearchQuery();
  }

  ngOnInit() {
  }

  viewJobOffer(offer: JobOfferVM) {
    this.routerService.navigate(['../job-offers', offer.id, 'view']);
  }

  editJobOffer(offer: JobOfferVM) {
    this.jobOfferSharingDataService.updateJobOfferData(offer);
    this.routerService.navigate(['../job-offers', offer.id, 'edit']);
  }


  checkSearchQuery() {
    this.candidateSearchQuery = this.activatedRouteService.snapshot.params['id'];
    console.log(this.candidateSearchQuery);

    if (this.candidateSearchQuery === '') {
      this.jobOfferService.getJobOffers().subscribe(
        res => this.jobOffersListVM = res,
        error => console.log(error)
      );
    } else {
      this.jobOfferService.getJobOffers(this.candidateSearchQuery).subscribe(
        res => this.jobOffersListVM = res,
        error => console.log(error)
      );
    }
  }

}
