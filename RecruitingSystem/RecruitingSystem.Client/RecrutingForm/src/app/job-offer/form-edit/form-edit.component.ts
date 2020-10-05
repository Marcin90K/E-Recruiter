import { JobOfferService } from './../../shared/services/job-offer.service';
import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { JobPositionVM } from 'src/app/shared/models/job-position/job-position-vm';
import { RecruiterVM } from 'src/app/shared/models/recruiter/recruiter-vm';
import { JOBPOSITIONS } from 'src/app/shared/models/opened-jobs';
import { JobOfferForCreation } from 'src/app/shared/models/job-offer/job-offer-for-creation';
import { RecruiterService } from 'src/app/shared/services/recruiter.service';
import { RecruiterListVM } from 'src/app/shared/models/recruiter/recruiter-list-vm';
import { JobOfferVM } from 'src/app/shared/models/job-offer/job-offer-vm';
import { JobOfferForUpdate } from 'src/app/shared/models/job-offer/job-offer-for-update';

@Component({
  selector: 'app-form-edit',
  templateUrl: './form-edit.component.html',
  styleUrls: ['./form-edit.component.css']
})
export class FormEditComponent implements OnInit {

  jobOfferForm: FormGroup;

  viewModel: JobOfferForUpdate;

  @Input() jobOfferId: string;
  //jobOfferId = '';

  jobPositions: JobPositionVM[];
  owners: RecruiterVM[];
  ownerLabels: string[] = [];
  description: string;
  requirements: string[] = [];


  constructor(private formBuilder: FormBuilder,
              private recruiterService: RecruiterService,
              private jobOfferService: JobOfferService) {
    this.jobOfferService.getJobOffer(this.jobOfferId).subscribe(
      vm => vm ? this.viewModel = this.convertModelFromDBToUpdate(vm) : null,
      error => console.log(error)
    );

    this.jobOfferForm = this.createFormGroup(this.formBuilder);
  }

  ngOnInit() {
    this.jobPositions = JOBPOSITIONS;
    this.recruiterService.getRecruiters().subscribe(
      rec => {
        this.owners = this.owners = this.fillOwnersFullnames(rec.recruiters);
        console.log(rec);
      },
      error => console.log(error)
    );
  }


  createFormGroup(fb: FormBuilder) {
    return fb.group({
      jobPositionId: [this.viewModel ? this.viewModel.jobPositionId : ''],
      ownerId: [this.viewModel ? this.viewModel.ownerId : ''],
      description: [this.viewModel ? this.viewModel.description : ''],
      requirements: [this.viewModel ? this.viewModel.requirements : null],
      dateOfExpiration: [this.viewModel ? this.viewModel.dateOfExpiration : null]
    });
  }


  apply() {
    this.viewModel = this.jobOfferForm.value;
    this.viewModel.requirements = this.requirements.join('\n');
    this.jobOfferService.addJobOffer(this.viewModel).subscribe(
      result => console.log("Job offer updated: " + result.id),
      error => console.log(error)
    );
  }



  addRequirement(el) {
    const req = el.value.toString();
    if (req) {
      console.log(req);
      this.requirements.push(req);
      el.value = null;
    }
  }

  removeRequirement(i: number) {
    this.requirements.splice(i, 1);
  }

  fillOwnersFullnames(owners: RecruiterVM[]) {
    for (let owner of owners) {
      owner.fullName = owner.employee.personBasicData.firstName +
        ' ' + owner.employee.personBasicData.lastName;
    }
    return owners;
  }

  convertModelFromDBToUpdate(model: JobOfferVM): JobOfferForUpdate {
    let modelResult: JobOfferForUpdate;

    modelResult.dateOfExpiration = model.dateOfExpiration;
    modelResult.description = model.description;
    modelResult.jobPositionId = model.jobPosition.id;
    modelResult.ownerId = model.owner.id;
    modelResult.requirements = model.requirements;

    return modelResult;
  }

}

