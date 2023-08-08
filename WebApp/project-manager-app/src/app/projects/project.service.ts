import { Injectable } from '@angular/core';
import { Project, NewProject } from './project';
import { Task } from './task';
import { HttpClient } from '@angular/common/http';
import { Observable, catchError, tap } from 'rxjs';
import { GlobalConstants } from '../shared/global-constants';

@Injectable({
  providedIn: 'root',
})
export class ProjectService {
  private projectsUrl = GlobalConstants.apiURL + 'projects';

  private individualProjectUrl = GlobalConstants.apiURL + 'projects/';

  constructor(private http: HttpClient) {}

  getProjects(): Observable<Project[]> {
    return this.http.get<Project[]>(this.projectsUrl).pipe(
      tap((data) => console.log('All: ' + JSON.stringify(data))),
      catchError((err) => {
        console.log(err);
        return [];
      })
    );
  }

  getProjectById(projectId: number): Observable<Project> {
    return this.http.get<Project>(this.projectsUrl + '/' + projectId).pipe(
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
        this.buildUrlTaskString(this.individualProjectUrl, projectId) + '/' + taskId
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

  postNewProject(project: NewProject): any {
    return this.http.post(this.projectsUrl, project).pipe(
      tap((data) => console.log('All: ' + JSON.stringify(data))),
      catchError((err) => {
        console.log(err);
        return [];
      })
    );
  }
}
