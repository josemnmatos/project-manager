import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent {
  loggedIn: boolean = false;

  constructor(private auth: AuthService) {}

  isLogged() {
    this.loggedIn = this.auth.isAuthenticated();
    return this.loggedIn;
  }

  Logout() {
    this.auth.logout();
    this.loggedIn = false;
  }
}
