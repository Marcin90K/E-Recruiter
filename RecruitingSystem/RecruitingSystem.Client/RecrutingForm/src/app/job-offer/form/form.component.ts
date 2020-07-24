import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { JobPositionVM } from 'src/app/shared/models/job-position/job-position-vm';
import { RecruiterVM } from 'src/app/shared/models/recruiter/recruiter-vm';
import { JOBPOSITIONS } from 'src/app/shared/models/opened-jobs';
import { JobOfferForCreation } from 'src/app/shared/models/job-offer/job-offer-for-creation';

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
  description: string;
  requirements: string[] = [];

  constructor(private formBuilder: FormBuilder) {
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

}
