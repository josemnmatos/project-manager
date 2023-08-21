import { Injectable } from '@angular/core';
import { Project, NewProject } from '../shared/project';
import { Task } from '../shared/task';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, catchError, tap } from 'rxjs';
import { GlobalConstants } from '../shared/global-constants';
import { AuthService } from './auth.service';
import { Manager } from '../shared/manager';

@Injectable({
  providedIn: 'root',
})
export class DashboardService {
  private managerDashboardUrl = GlobalConstants.apiURL + 'manager/dashboard';

  private developerDashboardUrl =
    GlobalConstants.apiURL + 'developer/dashboard';

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

  getAllUsers() {
    const headers = this.getHeadersWithToken();
    return this.http
      .get<any[]>(this.managerDashboardUrl+'/staff', { headers })
      .pipe(
        tap(),
        catchError((err) => {
          console.log(err);
          return [];
        })
      );
  }

  getManagerDashboard(userId: string): Observable<Manager> {
    const headers = this.getHeadersWithToken();

    return this.http
      .get<Manager>(this.managerDashboardUrl + '/' + userId, { headers })
      .pipe(
        tap(),
        catchError((err) => {
          console.log(err);
          return [];
        })
      );
  }
}
