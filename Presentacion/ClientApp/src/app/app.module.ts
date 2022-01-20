import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule as reactivo} from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { CounterComponent } from './Pag/counter/counter.component';
import { NavMenuComponent } from './Pag/nav-menu/nav-menu.component';
import { HomeComponent } from './Pag/home/home.component';
import { LoginComponent } from './Components/login/login.component';
import { FetchDataComponent } from './Pag/fetch-data/fetch-data.component';
import { ConsultBooksComponent } from './Components/consult-books/consult-books.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AuthGuard } from './Elements/services/auth.guarda';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    LoginComponent,
    ConsultBooksComponent,
  ],
  imports: [
    reactivo,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: ConsultBooksComponent, pathMatch: 'full', canActivate: [AuthGuard] },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'books', component: ConsultBooksComponent },
    ]),
    NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
