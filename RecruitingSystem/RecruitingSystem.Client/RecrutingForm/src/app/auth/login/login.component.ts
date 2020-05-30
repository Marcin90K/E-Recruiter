import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { LoginBasic } from 'src/app/shared/models/auth/login-basic';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  model: LoginBasic;

  constructor(private formBuilder: FormBuilder) {
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
    console.log(this.model);
  }

}
