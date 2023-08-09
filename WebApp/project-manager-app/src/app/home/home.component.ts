import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  //inject auth service

  constructor(
    private auth: AuthService
  ){}


  isLogged() {
    return this.auth.isAuthenticated();
  }

}
