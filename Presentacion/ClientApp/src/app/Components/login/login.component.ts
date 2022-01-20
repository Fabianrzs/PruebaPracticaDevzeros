import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs/operators';
import { User } from 'src/app/Elements/models/user';
import { AuthenticationService } from 'src/app/Elements/services/authentication.services';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  userForm: FormGroup;
  returnUrl: String = "";
  user: User;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthenticationService,
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
  
  get f() {
    return this.userForm.controls;
  }

  onSubmit() {
    alert('Submit')
    if (this.userForm.invalid) {
      return;
    }
    this.user = this.userForm.value;
    alert(JSON.stringify(this.user))
    
    this.authenticationService.login(this.user.userName, this.user.password).pipe(first()).subscribe((data) => {
          this.router.navigate(["/consultar-libros"]);
        },(error) => {
          /*const modalRef = this.modalService.open(AlertModalComponent);
          modalRef.componentInstance.title = "Acceso Denegado";
          modalRef.componentInstance.message = "Usuario o Contraseña Erroneas";
          this.loading = false;*/
        }
      );
  }
}
