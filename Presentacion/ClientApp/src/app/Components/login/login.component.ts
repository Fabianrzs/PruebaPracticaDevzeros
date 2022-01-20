import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { User } from 'oidc-client';
import { AuthenticationService } from 'src/app/Elements/services/authentication.services';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  returnUrl: String;
  submitted: boolean;
  user: User;

  constructor(
  ) { }

  ngOnInit() {
  }

}
