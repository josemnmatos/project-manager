import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { GlobalConstants } from '../shared/global-constants';
import jwt_decode from 'jwt-decode';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  baseUrl = GlobalConstants.apiURL + 'users';

  constructor(private http: HttpClient) {}

  private tokenKey = 'token';

  private roleKey = 'role';

  private emailKey = 'email';

  register(userObj: any) {
    return this.http.post(this.baseUrl + '/register', userObj);
  }

  login(loginObj: any) {
    return this.http.post(this.baseUrl + '/authenticate', loginObj);
  }

  logout() {
    this.removeToken();
    this.removeRole();
    this.removeEmail();
  }

  setToken(token: string) {
    localStorage.setItem(this.tokenKey, token);
  }

  getToken() {
    return localStorage.getItem(this.tokenKey);
  }

  removeToken() {
    localStorage.removeItem(this.tokenKey);
  }

  setRole(newRole: string) {
    localStorage.setItem(this.roleKey, newRole);
  }

  getRole() {
    return localStorage.getItem(this.roleKey);
  }

  removeRole() {
    localStorage.removeItem(this.roleKey);
  }

  setEmail(newEmail: string) {
    localStorage.setItem(this.emailKey, newEmail);
  }

  getEmail() {
    return localStorage.getItem(this.emailKey);
  }

  removeEmail() {
    localStorage.removeItem(this.emailKey);
  }

  processToken(token: string) {
    const decodedToken: any = jwt_decode(token);
    const decodedRole =
      decodedToken[
        'http://schemas.microsoft.com/ws/2008/06/identity/claims/role'
      ];
    const decodedEmail =
      decodedToken[
        'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress'
      ];

    this.setToken(token);
    this.setRole(decodedRole);
    this.setEmail(decodedEmail);
  }

  getDecodedToken() {
    try {
      console.log(this.getToken());

      if (this.getToken() == null) {
        return null;
      } else {
        const token = this.getToken();
        return jwt_decode(token as string);
      }
    } catch (Error) {
      return null;
    }
  }

  isAuthenticated() {
    const token = this.getDecodedToken();
    if (token) {
      console.log(token);
      // verify token later

      return true;
    } else {
      return false;
    }
  }

  isManager() {
    return this.getRole() === 'manager';
  }

  isDeveloper() {
    return this.getRole() === 'developer';
  }
}
