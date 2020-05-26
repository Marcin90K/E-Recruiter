import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormArray } from '@angular/forms';
import { ExperienceForManipulation } from 'src/app/shared/models/experience/experience-for-manipulation';
import { CandidateSharingDataService } from 'src/app/shared/services/candidate-sharing-data.service';

@Component({
  selector: 'app-experience',
  templateUrl: './experience.component.html',
  styleUrls: ['./experience.component.css']
})
export class ExperienceComponent implements OnInit {

  formExperienceWrapper: FormGroup;
  formExperienceItem: FormGroup;
  model: ExperienceForManipulation[];

  constructor(private formBuilder: FormBuilder,
              private candidateDataService: CandidateSharingDataService) {
    this.formExperienceWrapper = this.createFormExperienceWrapper(this.formBuilder);
    this.model = {} as ExperienceForManipulation[];
  }

  ngOnInit() {
  }

  createFormGroup(fb: FormBuilder) {
    return fb.group({
      companyName: [''],
      startDate: Date.now(),
      endDate: Date.now(),
      jobTitle: [''],
      duties: ['']
    });
  }

  createFormExperienceWrapper(fb: FormBuilder) {
    return fb.group({
      experienceItems: fb.array([
        this.createFormGroup(fb)
      ])
    });
  }

  addExperienceItem() {
    const experienceItems = this.formExperienceWrapper.controls.experienceItems as FormArray;
    const experienceItemsLenth = experienceItems.length;
    experienceItems.insert(experienceItemsLenth, this.createFormGroup(this.formBuilder));
  }

  removeExperienceItem(i) {
    const experienceItems = this.formExperienceWrapper.controls.experienceItems as FormArray;
    experienceItems.removeAt(i);
  }

  apply() {
    this.model = this.formExperienceWrapper.value;
    this.candidateDataService.updateCandidateExperienceData(this.model);
    console.log(this.model);
  }
}
