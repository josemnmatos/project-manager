import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, catchError, tap } from 'rxjs';
import { Project } from '../shared/project';
import { Task } from '../shared/task';

@Injectable({
  providedIn: 'root',
})
export class TasksService {
  private projectsUrl = 'https://localhost:7136/api/projects';

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
}