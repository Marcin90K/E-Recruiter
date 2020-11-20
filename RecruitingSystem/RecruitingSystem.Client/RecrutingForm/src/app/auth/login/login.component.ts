import { RecruiterVM } from 'src/app/shared/models/recruiter/recruiter-vm';
import { Component, Input, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { CandidateVM } from 'src/app/shared/models/candidate/candidate-vm';
import { CandidateService } from 'src/app/shared/services/candidate.service';
import { CandidateSharingDataService } from 'src/app/shared/services/candidate-sharing-data.service';
import { Router } from '@angular/router';
import { RecruiterService } from 'src/app/shared/services/recruiter.service';
import { LoginWithEmployee } from 'src/app/shared/models/auth/login-with-employee';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  model: LoginWithEmployee;
  candidate: CandidateVM;
  recruiter: RecruiterVM;

  isCandidate = false;

  constructor(private formBuilder: FormBuilder,
              private candidateService: CandidateService,
              private candidateSharingData: CandidateSharingDataService,
              private recruiterService: RecruiterService,
              private routerService: Router) {
    this.loginForm = this.createFormGroup(this.formBuilder);
  }

  ngOnInit() {
  }

  createFormGroup(fb: FormBuilder) {
    return fb.group({
      isEmployee: false,
      username: [''],
      password: ['']
    });
  }

  submit() {
    this.model = this.loginForm.value;

    if (!this.model.isEmployee) {
      this.getCandidate(this.model.username);
      this.routerService.navigate(['./candidate', this.model.username, 'basic-info']);
    }
    else {
      this.getRecruiter(this.model.username);
      this.routerService.navigate(['./admin-panel']);
    }

  }

  getCandidate(id: string) {
    this.candidateService.getCandidate(id).subscribe(
      candidate => {
        this.candidateSharingData.updateCandidateViewModel(candidate);
        console.log(candidate);
      },
      error => {
        console.log(error);
      });
  }

  getRecruiter(id: string) {
    this.recruiterService.getRecruiter(id).subscribe(
      recruiter => {
        this.recruiter = recruiter;
      },
      error => console.log(error)
    )
  }

}
