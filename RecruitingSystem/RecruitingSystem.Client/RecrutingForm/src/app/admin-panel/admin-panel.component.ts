import { CandidateVM } from './../shared/models/candidate/candidate-vm';
import { CandidateSharingDataService } from './../shared/services/candidate-sharing-data.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.css']
})
export class AdminPanelComponent implements OnInit {

  candidateVM: CandidateVM;

  widgetAddJobOffer = "Add job offer";
  widgetJobOffers = "View job offers";
  widgetViewCandidates = "View candidates";
  addJobOfferRedirectLink = "/job-offers/form";
  jobOffersRedirectLink = "/recruitment-panel";
  viewCandidatesRedirectLink = "";

  constructor(private candidateSharingDataService: CandidateSharingDataService) {
    // this.candidateSharingDataService.getCandidateViewModel().subscribe(
    //   result => this.candidateVM = result,
    //   error => console.log(error)
    // );
   }

  ngOnInit() {
  }

}
