import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormArray } from '@angular/forms';
import { EducationForManipulation } from 'src/app/shared/models/education/education-for-manipulation';
import { CandidateSharingDataService } from 'src/app/shared/services/candidate-sharing-data.service';
import { EducationVM } from 'src/app/shared/models/education/education-vm';

@Component({
  selector: 'app-education',
  templateUrl: './education.component.html',
  styleUrls: ['./education.component.css']
})
export class EducationComponent implements OnInit {

  formEducationWrapper: FormGroup;
  formEducationItem: FormGroup;
  model: EducationForManipulation[];
  private viewModel: EducationVM[];

  constructor(private formBuilder: FormBuilder,
              private candidateDataService: CandidateSharingDataService) {

    this.model = {} as EducationForManipulation[];
    this.candidateDataService.getCandidateViewModel().subscribe(
      vm => {
        this.viewModel = vm ? vm.educations : null;
        if (this.viewModel) {
          this.formEducationWrapper = this.createFormEducationWrapper(this.formBuilder, this.viewModel[0]);
          this.fillExistingData();
        }
        else {
          this.formEducationWrapper = this.createFormEducationWrapper(this.formBuilder, null);
        }
      }
    )
   }

  ngOnInit() {
  }

  createFormGroup(fb: FormBuilder, vm: EducationVM) {
      return fb.group({
        schoolName: [vm ? vm.schoolName : ''],
        startDate: [vm ? vm.startDate : new Date(Date.now())],
        endDate: [vm ? vm.endDate : new Date(Date.now())],
        courseName: [vm ? vm.courseName : '']
      });
  }

  createFormEducationWrapper(fb: FormBuilder, vm: EducationVM) {
    let formGroup = {} as FormGroup;

    formGroup = fb.group({
      educationItems: fb.array([
        this.createFormGroup(fb, vm)
      ])
    });

    return formGroup;
  }

  fillExistingData() {
    const educationItems = this.formEducationWrapper.controls.educationItems as FormArray;
    if (this.viewModel) {
      for (let i = 1; i < this.viewModel.length; i++) {
        educationItems.insert(i, this.createFormGroup(this.formBuilder, this.viewModel[i]));
      }
    }
  }


  addEducationItem() {
    const educationItems = this.formEducationWrapper.controls.educationItems as FormArray;
    const educationItemsLength = educationItems.length;
    educationItems.insert(educationItemsLength, this.createFormGroup(this.formBuilder, null));
  }

  removeEducationItem(i) {
    const educationItems = this.formEducationWrapper.controls.educationItems as FormArray;
    educationItems.removeAt(i);
  }

  apply() {
    this.model = this.formEducationWrapper.value;
    this.candidateDataService.updateCandidateEducationData(this.model);
    console.log(this.model);
  }

}
