import { Component, OnInit } from '@angular/core';
import { CandidateBasicDataForManipulation } from '../../shared/models/candidate-basic-data/candidate-basic-data-for-manipulation';
import { FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { CandidateSharingDataService } from 'src/app/shared/services/candidate-sharing-data.service';

@Component({
  selector: 'app-basic-info',
  templateUrl: './basic-info.component.html',
  styleUrls: ['./basic-info.component.css']
})
export class BasicInfoComponent implements OnInit {

  formBasicInfo: FormGroup;
  model: CandidateBasicDataForManipulation;


  constructor(private formBuilder: FormBuilder,
              private candidateDataService: CandidateSharingDataService) {
    this.formBasicInfo = this.createFormGroup(this.formBuilder);
  }

  ngOnInit() {
  }

  createFormGroup(fb: FormBuilder) {
    return fb.group({
      personBasicData: fb.group({
        firstName: [''],
        lastName: [''],
        dateOfBirth: Date.now(),
        email: [''],
        phoneNumber: 0
      }),
      address: fb.group({
        city: [''],
        street: [''],
        buildingNumber: 0,
        flatNumber: 0,
        zip: '00-000'
      })
    });
  }

  apply() {
    this.model = this.formBasicInfo.value;
    this.candidateDataService.updateCandidateBasicData(this.model);
    console.log(this.model);
  }

}
