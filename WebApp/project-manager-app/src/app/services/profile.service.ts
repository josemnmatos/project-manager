import { Injectable } from '@angular/core';
import { Project, NewProject } from '../shared/project';
import { Task } from '../shared/task';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, catchError, tap } from 'rxjs';
import { GlobalConstants } from '../shared/global-constants';
import { AuthService } from './auth.service';
import { Manager } from '../shared/manager';
import { User } from '../shared/user';
import { Developer } from '../shared/developer';

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

  getDevelopers(): Observable<Developer[]> {
    const headers = this.getHeadersWithToken();

    return this.http
      .get<Developer[]>(this.userUrl + '/developers', { headers })
      .pipe(
        tap((data) => console.log('All: ' + JSON.stringify(data))),
        catchError((err) => {
          console.log(err);
          return [];
        })
      );
  }

  getUserProfile(userId: number): Observable<User> {
    const headers = this.getHeadersWithToken();

    return this.http.get<User>(this.userUrl + '/' + userId, { headers }).pipe(
      tap(),
      catchError((err) => {
        console.log(err);
        return [];
      })
    );
  }

  updateUserProfile(userId: number, user: any): Observable<User> {
    const headers = this.getHeadersWithToken();

    return this.http
      .put<User>(this.userUrl + '/' + userId, user, { headers })
      .pipe(
        tap(),
        catchError((err) => {
          console.log(err);
          return [];
        })
      );
  }

  deleteUser(userId: number): Observable<User> {
    const headers = this.getHeadersWithToken();

    return this.http
      .delete<User>(this.userUrl + '/' + userId, { headers })
      .pipe(
        tap(),
        catchError((err) => {
          console.log(err);
          return [];
        })
      );
  }

  updatePassword(userId: number, password: any): Observable<User> {
    const headers = this.getHeadersWithToken();

    return this.http
      .put<User>(this.userUrl + '/' + userId + '/password', password, {
        headers,
      })
      .pipe(
        tap( 
          (data) => console.log('All: ' + JSON.stringify(data))
        ),
        catchError((err) => {
          console.log(err);
          return [];
        })
      );
  }
}
