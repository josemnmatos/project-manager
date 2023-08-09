import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { GlobalConstants } from '../shared/global-constants';


@Injectable({
  providedIn: 'root'
})
export class AuthService {

  baseUrl = GlobalConstants.apiURL + 'users';

  constructor( private http : HttpClient) { }


  register(userObj : any){
    return this.http.post(this.baseUrl+"/register", userObj);
  }

  login(loginObj : any){
    return this.http.post(this.baseUrl+"/authenticate", loginObj);
  }

}
