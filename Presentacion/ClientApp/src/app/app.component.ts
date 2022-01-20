import { Component } from '@angular/core';
import { User } from './Elements/models/user';
import { AuthenticationService } from './Elements/services/authentication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';
  currentUser: User;
  constructor(
    private authenticationService: AuthenticationService
  ) {
    this.authenticationService.currentUser.subscribe(
      (x) => (this.currentUser = x)
    );
  }
}
