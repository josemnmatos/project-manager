import { Injectable } from '@angular/core';
import { Project, NewProject } from '../shared/project';
import { Task } from '../shared/task';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, catchError, tap } from 'rxjs';
import { GlobalConstants } from '../shared/global-constants';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root',
})
export class ProjectService {
  private projectsUrl = GlobalConstants.apiURL + 'projects';

  private individualProjectUrl = GlobalConstants.apiURL + 'projects/';

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

  getProjects(): Observable<Project[]> {
    const headers = this.getHeadersWithToken();

    return this.http.get<Project[]>(this.projectsUrl, { headers }).pipe(
      tap((data) => console.log('All: ' + JSON.stringify(data))),
      catchError((err) => {
        console.log(err);
        return [];
      })
    );
  }

  getProjectById(projectId: number): Observable<Project> {
    const headers = this.getHeadersWithToken();

    return this.http
      .get<Project>(this.projectsUrl + '/' + projectId, { headers })
      .pipe(
        tap((data) => console.log('All: ' + JSON.stringify(data))),
        catchError((err) => {
          console.log(err);
          return [];
        })
      );
  }

  getTasksForProject(projectId: number): Observable<Task[]> {
    return this.http
      .get<Task[]>(
        this.buildUrlTaskString(this.individualProjectUrl, projectId)
      )
      .pipe(
        tap((data) => console.log('All: ' + JSON.stringify(data))),
        catchError((err) => {
          console.log(err);
          return [];
        })
      );
  }

  getTaskById(projectId: number, taskId: number): Observable<Task> {
    return this.http
      .get<Task>(
        this.buildUrlTaskString(this.individualProjectUrl, projectId) +
          '/' +
          taskId
      )
      .pipe(
        tap((data) => console.log('All: ' + JSON.stringify(data))),
        catchError((err) => {
          console.log(err);
          return [];
        })
      );
  }

  buildUrlTaskString(individualProjectUrl: string, projectId: number) {
    return individualProjectUrl + projectId + '/tasks';
  }

  createProject(project: NewProject): any {
    return this.http.post(this.projectsUrl, project);
  }
}
