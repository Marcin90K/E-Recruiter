import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { JobPositionVM } from 'src/app/shared/models/job-position/job-position-vm';
import { RecruiterVM } from 'src/app/shared/models/recruiter/recruiter-vm';
import { JOBPOSITIONS } from 'src/app/shared/models/opened-jobs';
import { JobOfferForCreation } from 'src/app/shared/models/job-offer/job-offer-for-creation';
import { RecruiterService } from 'src/app/shared/services/recruiter.service';
import { RecruiterListVM } from 'src/app/shared/models/recruiter/recruiter-list-vm';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {

  jobOfferForm: FormGroup;
  model: JobOfferForCreation;

  jobPositions: JobPositionVM[];
  owners: RecruiterVM[];
  ownerLabels: string[] = [];
  description: string;
  requirements: string[] = [];

  constructor(private formBuilder: FormBuilder,
              private recruiterService: RecruiterService) {
    this.jobOfferForm = this.createFormGroup(this.formBuilder);
    this.model = {
      jobPosition: null,
      description: '',
      requirements: '',
      owner: null,
      dateOfExpiration: null
    };
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
    // this.owners = this.fillRecruitersFullnames(this.owners);
  }


  createFormGroup(fb: FormBuilder) {
    return fb.group({
      jobPositions: [null],
      owner: [null],
      description: [''],
      requirements: [null],
      dateOfExpiration: [null]
    });
  }


  apply() {
    console.log(this.requirements);
    this.model = this.jobOfferForm.value;
    this.model.requirements = this.requirements.join('\n');
    console.log(this.model.requirements);
    console.log(this.model);
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

}
