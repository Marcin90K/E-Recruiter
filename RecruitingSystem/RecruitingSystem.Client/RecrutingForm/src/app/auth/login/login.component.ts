import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { LoginBasic } from 'src/app/shared/models/auth/login-basic';
import { CandidateVM } from 'src/app/shared/models/candidate/candidate-vm';
import { CandidateService } from 'src/app/shared/services/candidate.service';
import { BehaviorSubject } from 'rxjs';
import { CandidateSharingDataService } from 'src/app/shared/services/candidate-sharing-data.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  model: LoginBasic;
  candidate: CandidateVM;

  constructor(private formBuilder: FormBuilder,
              private candidateService: CandidateService,
              private candidateSharingData: CandidateSharingDataService,
              private routerService: Router) {
    this.loginForm = this.createFormGroup(this.formBuilder);
  }

  ngOnInit() {
  }

  createFormGroup(fb: FormBuilder) {
    return fb.group({
      username: [''],
      password: ['']
    });
  }

  submit() {
    this.model = this.loginForm.value;
    this.getCandidate(this.model.username);

    this.routerService.navigate(['./candidate', this.model.username, 'basic-info']);
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

}
