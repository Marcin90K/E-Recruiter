import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormArray } from '@angular/forms';
import { ExperienceForManipulation } from 'src/app/shared/models/experience/experience-for-manipulation';
import { CandidateSharingDataService } from 'src/app/shared/services/candidate-sharing-data.service';
import { ExperienceVM } from 'src/app/shared/models/experience/experience-vm';

@Component({
  selector: 'app-experience',
  templateUrl: './experience.component.html',
  styleUrls: ['./experience.component.css']
})
export class ExperienceComponent implements OnInit {

  formExperienceWrapper: FormGroup;
  formExperienceItem: FormGroup;
  model: ExperienceForManipulation[];
  viewModel: ExperienceVM[];

  constructor(private formBuilder: FormBuilder,
              private candidateDataService: CandidateSharingDataService) {

    this.candidateDataService.getCandidateViewModel().subscribe(
      vm => {
        this.viewModel = vm ? vm.experiences : null;
        if (this.viewModel) {
          this.formExperienceWrapper = this.createFormExperienceWrapper(this.formBuilder, this.viewModel[0]);
          this.fillExistingData();
        }
        else {
          this.formExperienceWrapper = this.createFormExperienceWrapper(this.formBuilder, null);
        }

      }
    )

    this.model = {} as ExperienceForManipulation[];
  }

  ngOnInit() {
  }

  createFormGroup(fb: FormBuilder, vm: ExperienceVM) {
    return fb.group({
      companyName: [vm ? vm.companyName : ''],
      startDate: [vm ? vm.startDate : new Date(Date.now().toLocaleString())],
      endDate: [vm ? vm.endDate : new Date(Date.now().toLocaleString())],
      jobTitle: [vm ? vm.jobTitle : ''],
      duties: [vm ? vm.duties : '']
    });
  }

  createFormExperienceWrapper(fb: FormBuilder, vm: ExperienceVM) {
    return fb.group({
      experienceItems: fb.array([
        this.createFormGroup(fb, vm)
      ])
    });
  }

  fillExistingData() {
    const experienceItems = this.formExperienceWrapper.controls.experienceItems as FormArray;
    if (this.viewModel) {
      for (let i = 1; i < this.viewModel.length; i++) {
        experienceItems.insert(i, this.createFormGroup(this.formBuilder, this.viewModel[i]));
      }
    }
  }

  addExperienceItem() {
    const experienceItems = this.formExperienceWrapper.controls.experienceItems as FormArray;
    const experienceItemsLenth = experienceItems.length;
    experienceItems.insert(experienceItemsLenth, this.createFormGroup(this.formBuilder, null));
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
