import { JobOfferService } from './../../shared/services/job-offer.service';
import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { JobPositionVM } from '../../shared/models/job-position/job-position-vm';
import { RecruiterVM } from '../../shared/models/recruiter/recruiter-vm';
import { JOBPOSITIONS } from '../../shared/models/opened-jobs';
import { JobOfferForCreation } from '../../shared/models/job-offer/job-offer-for-creation';
import { RecruiterService } from '../../shared/services/recruiter.service';
import { RecruiterListVM } from '../../shared/models/recruiter/recruiter-list-vm';
import { JobOfferVM } from '../../shared/models/job-offer/job-offer-vm';
import { JobOfferForUpdate } from '../../shared/models/job-offer/job-offer-for-update';

@Component({
  selector: 'app-form-edit',
  templateUrl: './form-edit.component.html',
  styleUrls: ['./form-edit.component.css']
})
export class FormEditComponent implements OnInit {

  jobOfferForm: FormGroup;

  viewModel: JobOfferForUpdate;

  //@Input() jobOfferId: string;
  jobOfferId = '7e56b414-411b-4fee-ba42-2eba50bfec6f';

  jobPositions: JobPositionVM[];
  owners: RecruiterVM[];
  ownerLabels: string[] = [];
  description: string;
  requirements: string[] = [];


  constructor(private formBuilder: FormBuilder,
              private recruiterService: RecruiterService,
              private jobOfferService: JobOfferService) {
    this.jobOfferService.getJobOffer(this.jobOfferId).subscribe(
      vm => {
        vm ? this.viewModel = this.convertModelFromDBToUpdate(vm) : null;
        //this.jobOfferForm = this.createFormGroup(this.formBuilder);
      },
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
    //this.jobOfferForm = this.createFormGroup(this.formBuilder);
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

    return modelResult = {
      dateOfExpiration: model.dateOfExpiration,
      description: model.description,
      jobPositionId: model.jobPosition.id,
      ownerId: model.owner.id,
      requirements: model.requirements
    };

    //return modelResult;
  }

}

