import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormArray } from '@angular/forms';
import { CandidateEducation } from 'src/app/shared/models/candidate-education';
import { CandidateSharingDataService } from 'src/app/shared/services/candidate-sharing-data.service';

@Component({
  selector: 'app-education',
  templateUrl: './education.component.html',
  styleUrls: ['./education.component.css']
})
export class EducationComponent implements OnInit {

  formEducationWrapper: FormGroup;
  formEducationItem: FormGroup;
  model: CandidateEducation[];

  constructor(private formBuilder: FormBuilder,
              private candidateDataService: CandidateSharingDataService) {
    this.formEducationWrapper = this.createFormEducationWrapper(this.formBuilder);
    this.model = {} as CandidateEducation[];
   }

  ngOnInit() {
  }

  createFormGroup(fb: FormBuilder) {
    return fb.group({
      schoolName: [''],
      startDate: Date.now(),
      endDate: Date.now(),
      courseName: ['']
    });
  }

  createFormEducationWrapper(fb: FormBuilder) {
    return fb.group({
      educationItems: fb.array([
         this.createFormGroup(fb)
      ])
    });
  }


  addEducationItem() {
    const educationItems = this.formEducationWrapper.controls.educationItems as FormArray;
    const educationItemsLength = educationItems.length;
    educationItems.insert(educationItemsLength, this.createFormGroup(this.formBuilder));
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
