import { Component, OnInit } from '@angular/core';
import { CandidataDataToBeSent } from 'src/app/models/candidate-data-to-be-sent';
import { CandidateProfile } from 'src/app/models/candidate-profile';
import { CandidateDataService } from 'src/app/services/candidate-data.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';


@Component({
  selector: 'app-summary',
  templateUrl: './summary.component.html',
  styleUrls: ['./summary.component.css']
})

export class SummaryComponent implements OnInit {

  companyName = 'IT Corporation';
  candidateProfile: CandidateProfile;
  candidateDataToBeSent: CandidataDataToBeSent;
  formSummary: FormGroup;
  objectKeys = Object.keys;
  objectValues = Object.values;
  isAgreementChecked = false;
  additionalNotes: '';



  termsOfPrivacyText = 'I hereby consent to my personal data being processed by ' + this.companyName +
      ' for the purpose of considering my application for the vacancy advertised under reference number (123XX6 etc.)';

  constructor(private candidateDataService: CandidateDataService,
              private routeService: Router,
              private formBuilder: FormBuilder) {
                this.candidateProfile = {
                  id: '',
                  //jobPosition: null,
                  basicInfo: null,
                  educationInfo: null,
                  candidateExperience: null
                };
                this.candidateDataToBeSent = {
                  candidateProfile: this.candidateProfile,
                  additionalNotes: '',
                };
              }

  ngOnInit() {
    // this.candidateDataService.getJobBasicInfo().subscribe(job =>
    //   this.candidateProfile.jobPosition = job);
    this.candidateDataService.getCandidateBasicData().subscribe(basic =>
      this.candidateProfile.basicInfo = basic);
    this.candidateDataService.getCandidateEducationData().subscribe(education =>
      this.candidateProfile.educationInfo = education);
    this.candidateDataService.getCandidateExperienceData().subscribe(experience =>
      this.candidateProfile.candidateExperience = experience);

      console.log(this.candidateProfile);
  }



  submit() {
    if (this.isAgreementChecked) {
      this.candidateDataToBeSent.candidateProfile = this.candidateProfile;
      this.candidateDataToBeSent.additionalNotes = this.additionalNotes;
      console.log(this.candidateDataToBeSent);
      this.routeService.navigate(['/submitted']);
    }
    else {
      alert("Please tick Privacy clause");
    }

  }


}
