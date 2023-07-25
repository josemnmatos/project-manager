import { Injectable } from '@angular/core';
import { Project, NewProject } from './project';
import { Task } from './task';
import { HttpClient } from '@angular/common/http';
import { Observable, catchError, tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ProjectService {
  private projectsUrl = 'https://localhost:7136/api/projects';

  private individualProjectUrl = 'https://localhost:7136/api/projects/';

  private tasksForProjectUrl = 'https://localhost:7136/api/projects/';

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
