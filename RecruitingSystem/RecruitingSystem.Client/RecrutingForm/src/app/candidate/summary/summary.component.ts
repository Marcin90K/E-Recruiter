import { Component, OnInit, Renderer2, ViewChild, ElementRef } from '@angular/core';
import { CandidataDataToBeSent } from 'src/app/shared/models/candidate-data-to-be-sent';
import { CandidateForCreation } from 'src/app/shared/models/Candidate/candidate-for-creation';
import { CandidateSharingDataService } from 'src/app/shared/services/candidate-sharing-data.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { CandidateService } from 'src/app/shared/services/candidate.service';
import { CandidateCreated } from 'src/app/shared/models/candidate/candidate-created';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';
import { CandidateVM } from 'src/app/shared/models/candidate/candidate-vm';
import { CandidateForUpdate } from 'src/app/shared/models/candidate/candidate-for-update';
import { CandidateUpdated } from 'src/app/shared/models/candidate/candidate-updated';


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
  candidateUpdated: CandidateUpdated;
  candidateVM: CandidateVM;

  isEditing: boolean;

  isPersonDetailsShown = false;
  isEducationShown = false;
  isExperienceShown = false;

  @ViewChild('details') private detailsSection: ElementRef;
  @ViewChild('education') private educationSection: ElementRef;
  @ViewChild('experience') private experienceSection: ElementRef;

  termsOfPrivacyText = 'I hereby consent to my personal data being processed by ' + this.companyName +
      ' for the purpose of considering my application for the vacancy advertised under reference number (123XX6 etc.)';

  constructor(private candidateDataService: CandidateSharingDataService,
              private routeService: Router,
              private activatedRoute: ActivatedRoute,
              private candidateService: CandidateService,
              private errorHandlerService: ErrorHandlerService,
              private formBuilder: FormBuilder,
              private renderer: Renderer2) {

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

    this.candidateDataService.getCandidateViewModel().subscribe(
      vm => {
        this.candidateVM = vm;
        this.isEditing = this.candidateVM ? true : false;
      }
    );
  }

  ngOnInit() {
    this.candidateDataService.getCandidateBasicData().subscribe(basic =>
      this.candidateProfile.candidateBasicData = basic);
    this.candidateDataService.getCandidateEducationData().subscribe(education =>
      {
        this.candidateProfile.educations = education
      });
    this.candidateDataService.getCandidateExperienceData().subscribe(experience =>
      this.candidateProfile.experiences = experience);

      console.log(this.candidateProfile);
  }

  submit() {
    //if (this.isAgreementChecked) {
      this.sendData();
      this.candidateDataService.clearAll();
      this.routeService.navigate(['../submitted'], { relativeTo: this.activatedRoute });
    //}
    // else {
    //   alert("Please tick Privacy clause");
    // }

  }

  sendData() {
    if (this.isEditing) {
      let candidateForUpdate = this.candidateProfile as CandidateForUpdate;
      candidateForUpdate.id = this.candidateVM.id;
      this.candidateService.updateCandidate(candidateForUpdate).subscribe(
        candidate => this.candidateUpdated = candidate,
        error => this.errorHandlerService.handleHTTPError('Updating candidate', error)
        );
    }
    else {
      this.candidateService.addCandidate(this.candidateProfile).subscribe(
        candidate => this.candidateCreated = candidate,
        error => this.errorHandlerService.handleHTTPError('Adding candidate', error)
      );
    }
  }

  toggleContentSection(el) {
    const element = el as HTMLElement;

    switch(element.id) {
      case 'detailsToggleBtn':
        this.isPersonDetailsShown = !this.isPersonDetailsShown;
        this.toggleClass(this.detailsSection, this.isPersonDetailsShown, 'show');
        break;
      case 'educationToggleBtn':
        this.isEducationShown = !this.isEducationShown;
        this.toggleClass(this.educationSection, this.isEducationShown, 'show');
        break;
      case 'experienceToggleBtn':
        this.isExperienceShown = !this.isExperienceShown;
        this.toggleClass(this.experienceSection, this.isExperienceShown, 'show');
        break;
    }
  }

  toggleClass(element: ElementRef, isShown: boolean, className: string) {
    if (isShown) {
      this.renderer.addClass(element.nativeElement, className);
    }
    else {
      this.renderer.removeClass(element.nativeElement, className);
    }
  }

}
