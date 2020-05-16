import { Component, OnInit } from '@angular/core';
import { CandidateBasicData } from '../../models/candidate-basic-data';
import { FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { CandidateDataService } from 'src/app/services/candidate-data.service';

@Component({
  selector: 'app-basic-info',
  templateUrl: './basic-info.component.html',
  styleUrls: ['./basic-info.component.css']
})
export class BasicInfoComponent implements OnInit {

  formBasicInfo: FormGroup;
  model: CandidateBasicData;


  constructor(private formBuilder: FormBuilder,
              private candidateDataService: CandidateDataService) {
    this.formBasicInfo = this.createFormGroup(this.formBuilder);
  }

  ngOnInit() {
  }

  createFormGroup(fb: FormBuilder) {
    return fb.group({
      firstName: [''],
      lastName: [''],
      dateOfBirth: Date.now(),
      address: fb.group({
        city: [''],
        street: [''],
        buildingNumber: 0,
        flatNumber: 0,
        zip: '00-000'
      }),
      email: [''],
      phone: 0
    });
  }

  apply() {
    this.model = this.formBasicInfo.value;
    this.candidateDataService.updateCandidateBasicData(this.model);
    console.log(this.model);
  }

}
