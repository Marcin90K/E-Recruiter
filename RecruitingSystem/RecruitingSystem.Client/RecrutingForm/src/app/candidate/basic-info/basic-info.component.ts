import { Component, OnInit } from '@angular/core';
import { CandidateBasicDataForManipulation } from '../../shared/models/candidate-basic-data/candidate-basic-data-for-manipulation';
import { FormGroup, FormBuilder } from '@angular/forms';
import { CandidateSharingDataService } from 'src/app/shared/services/candidate-sharing-data.service';
import { Router, ActivatedRoute } from '@angular/router';
import { CandidateBasicDataVM } from 'src/app/shared/models/candidate-basic-data/candidate-basic-data-vm';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-basic-info',
  templateUrl: './basic-info.component.html',
  styleUrls: ['./basic-info.component.css']
})
export class BasicInfoComponent implements OnInit {

  formBasicInfo: FormGroup;
  model: CandidateBasicDataForManipulation;
  viewModel: CandidateBasicDataVM;
  private dateFormat = 'yyyy-MM-dd';

  constructor(private formBuilder: FormBuilder,
              private candidateDataService: CandidateSharingDataService,
              private router: Router,
              private activatedRoute: ActivatedRoute,
              private datePipe: DatePipe) {

    this.candidateDataService.getCandidateViewModel().subscribe(
      vm => {
        this.viewModel = vm ? vm.candidateBasicData : null
        this.formBasicInfo = this.createFormGroup(this.formBuilder);
      }
    );
  }

  ngOnInit() {}

  createFormGroup(fb: FormBuilder) {
    let pb = this.viewModel ? this.viewModel.personBasicData : null;
    let addr = this.viewModel ? this.viewModel.address : null;

    return fb.group({
      personBasicData: fb.group({
        firstName: [pb ? pb.firstName : ''],
        lastName: [pb ? pb.lastName : ''],
        dateOfBirth: [pb ? this.parseDate(pb.dateOfBirth) : null],
        email: [pb ? pb.email : ''],
        phoneNumber: [pb ? pb.phoneNumber : 0]
      }),
      address: fb.group({
        city: [addr ? addr.city : ''],
        street: [addr ? addr.street : ''],
        buildingNumber: [addr ? addr.buildingNumber : 0],
        flatNumber: [addr ? addr.flatNumber : 0],
        zip: [addr ? addr.zip : '00-000']
      })
    });
  }

  apply() {
    this.model = this.formBasicInfo.value;
    this.candidateDataService.updateCandidateBasicData(this.model);
    console.log(this.model);
  }



  parseDate(date: Date): string {
    return this.datePipe.transform(date, this.dateFormat);
  }

}
