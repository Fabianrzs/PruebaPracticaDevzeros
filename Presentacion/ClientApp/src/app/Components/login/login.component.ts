import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { first } from 'rxjs/operators';
import { User } from 'src/app/Elements/models/user';
import { AuthenticationService } from 'src/app/Elements/services/authentication.service';
import { AlertModalComponent } from '../alert-modal/alert-modal.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  userForm: FormGroup;
  returnUrl: String = "";
  user: User;
  submitted: boolean;
  loading: boolean;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthenticationService,
    private modalService: NgbModal
  ) {
    this.user = new User();
    if (this.authenticationService.currentUserValue) {
      this.router.navigate([""]);
    }
  }

  ngOnInit(): void {
    this.userForm = this.formBuilder.group({
      userName: ['', Validators.required],
      password: ['', Validators.required]
    });
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '';
  }
  
  get form() {
    return this.userForm.controls;
  }

  onSubmit() {
    this.submitted = true;
    if (this.userForm.invalid) {
      return;
    }
    this.user = this.userForm.value;
    this.loading = true;
    this.authenticationService.login(this.user.userName, this.user.password).pipe(first()).subscribe((data) => {
          this.router.navigate(["books"]);
        },(error) => {
          const modalRef = this.modalService.open(AlertModalComponent);
          modalRef.componentInstance.title = "Acceso Denegado";
          modalRef.componentInstance.message = "Usuario o Contraseña Erroneas";
          this.loading = false;
        }
      );
  }
}

