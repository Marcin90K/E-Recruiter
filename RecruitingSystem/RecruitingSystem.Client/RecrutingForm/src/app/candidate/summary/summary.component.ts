import { Component, OnInit } from '@angular/core';
import { CandidataDataToBeSent } from 'src/app/shared/models/candidate-data-to-be-sent';
import { CandidateForCreation } from 'src/app/shared/models/Candidate/candidate-for-creation';
import { CandidateSharingDataService } from 'src/app/shared/services/candidate-sharing-data.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { CandidateService } from 'src/app/shared/services/candidate.service';
import { CandidateCreated } from 'src/app/shared/models/candidate/candidate-created';


@Component({
  selector: 'app-summary',
  templateUrl: './summary.component.html',
  styleUrls: ['./summary.component.css']
})

export class SummaryComponent implements OnInit {

  companyName = 'IT Corporation';
  candidateProfile: CandidateForCreation;
  candidateDataToBeSent: CandidataDataToBeSent;
  formSummary: FormGroup;
  objectKeys = Object.keys;
  objectValues = Object.values;
  isAgreementChecked = false;
  additionalNotes: '';

  candidateCreated: CandidateCreated;

  termsOfPrivacyText = 'I hereby consent to my personal data being processed by ' + this.companyName +
      ' for the purpose of considering my application for the vacancy advertised under reference number (123XX6 etc.)';

  constructor(private candidateDataService: CandidateSharingDataService,
              private routeService: Router,
              private activatedRoute: ActivatedRoute,
              private candidateService: CandidateService,
              private formBuilder: FormBuilder) {
                this.candidateProfile = {
                  //id: '',
                  //jobPosition: null,
                  candidateBasicData: null,
                  educations: null,
                  experiences: null
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
      this.candidateProfile.candidateBasicData = basic);
    this.candidateDataService.getCandidateEducationData().subscribe(education =>
      this.candidateProfile.educations = education);
    this.candidateDataService.getCandidateExperienceData().subscribe(experience =>
      this.candidateProfile.experiences = experience);

      console.log(this.candidateProfile);
  }



  // submit() {
  //   if (this.isAgreementChecked) {
  //     this.candidateDataToBeSent.candidateProfile = this.candidateProfile;
  //     this.candidateDataToBeSent.additionalNotes = this.additionalNotes;
  //     console.log(this.candidateDataToBeSent);
  //     this.routeService.navigate(['../submitted'], { relativeTo: this.activatedRoute });
  //   }
  //   else {
  //     alert("Please tick Privacy clause");
  //   }

  submit() {
    if (this.isAgreementChecked) {
      //this.candidateProfile = this.candidateProfile;
      console.log(this.candidateProfile);
      this.candidateService.addCandidate(this.candidateProfile).subscribe(
        candidate => this.candidateCreated = candidate
      );
      console.log('Candidate has been created: ' + this.candidateCreated );
      this.routeService.navigate(['../submitted'], { relativeTo: this.activatedRoute });
    }
    else {
      alert("Please tick Privacy clause");
    }

  }


}
