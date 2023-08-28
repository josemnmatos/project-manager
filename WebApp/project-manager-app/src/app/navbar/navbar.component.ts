import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent {
  loggedIn: boolean = false;

  userId = this.getCurrentUserId();



  constructor(private auth: AuthService,
              private router: Router 
              ) {}

  isLogged() {
    this.loggedIn = this.auth.isAuthenticated();
    return this.loggedIn;
  }

  Logout() {
    this.auth.logout();
    this.loggedIn = false;
  }

  getCurrentUserId() {
    return this.auth.getUserId();
  }


  isManager() {
    return this.auth.isManager();
  }

  isDeveloper() {
    return this.auth.isDeveloper();
  }

  GoToDashboard() {
    if (this.auth.isManager()) {
      this.router.navigate(['dashboard/manager']);
    } else if (this.auth.isDeveloper()) {
      this.router.navigate(['dashboard/developer']);
    } else {
      this.router.navigate(['']);
    }
  }
}
