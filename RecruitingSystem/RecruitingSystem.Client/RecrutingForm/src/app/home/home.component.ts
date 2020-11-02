import { CandidateSharingDataService } from 'src/app/shared/services/candidate-sharing-data.service';
import { Component, OnInit } from '@angular/core';
import { CandidateVM } from '../shared/models/candidate/candidate-vm';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  isLogged: boolean;
  candidateName: string;
  candidateId: string;
  candidateVM: CandidateVM;

  widgetJobOffers = "View job offers available";
  widgetEditProfile = "Edit your profile";
  widgetOffersApplied = "Check offers that you applied";
  jobOffersRedirectLink = "/recruitment-panel";
  editProfileRedirectLink = "/candidate/basic-info";
  appliedJobOffersRedirectLink = '';


  constructor(private candidateSharingService: CandidateSharingDataService) {
    this.candidateSharingService.getCandidateViewModel().subscribe(
      result => {
        this.candidateVM = result;
        this.candidateName = this.candidateVM.candidateBasicData.personBasicData.firstName;
        this.candidateId = this.candidateVM.id;
      },
      error => console.log(error)
    );

    this.isLogged = true; //temp
  }

  ngOnInit() {
  }

}
