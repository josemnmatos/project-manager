import { Injectable } from '@angular/core';
import { Project, NewProject } from '../shared/project';
import { Task } from '../shared/task';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, catchError, tap } from 'rxjs';
import { GlobalConstants } from '../shared/global-constants';
import { AuthService } from './auth.service';
import { Manager } from '../shared/manager';
import { User } from '../shared/user';

@Injectable({
  providedIn: 'root',
})
export class ProfileService {
  private userUrl = GlobalConstants.apiURL + 'users';

  constructor(private http: HttpClient, private auth: AuthService) {}

  getHeadersWithToken(): HttpHeaders {
    const token = this.auth.getToken();
    if (token) {
      return new HttpHeaders({
        Authorization: `Bearer ${token}`,
      });
    }
    return new HttpHeaders({});
  }


  getUserProfile(userId: number): Observable<User> {
    const headers = this.getHeadersWithToken();

    return this.http
      .get<User>(this.userUrl + '/' + userId, { headers })
      .pipe(
        tap(),
        catchError((err) => {
          console.log(err);
          return [];
        })
      );
  }
}
