import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, catchError, tap } from 'rxjs';
import { Project } from '../shared/project';
import { Task } from '../shared/task';
import { GlobalConstants } from '../shared/global-constants';
import { AuthService } from './auth.service';
import { ProfileService } from './profile.service';

@Injectable({
  providedIn: 'root',
})
export class TasksService {
  private projectsUrl = GlobalConstants.apiURL + 'projects';

  constructor(private http: HttpClient, private auth: ProfileService) {}

  getProjects(): Observable<Project[]> {
    return this.http.get<Project[]>(this.projectsUrl).pipe(
      tap((data) => console.log('All: ' + JSON.stringify(data))),
      catchError((err) => {
        console.log(err);
        return [];
      })
    );
  }

  createTask(projectId: number, task: any): Observable<any> {
    const headers = this.auth.getHeadersWithToken();

    return this.http.post<Task>(
      this.projectsUrl + '/' + projectId + '/tasks',
      task,
      { headers }
    );
  }

  putTask(projectId: number, task: any): Observable<any> {
    const headers = this.auth.getHeadersWithToken();


    console.log(task);

    return this.http.put<Task>(
      this.buildUrlTaskString(this.projectsUrl, projectId, task.id),
      task,
      { headers }
    );
  }

  setTaskState(
    projectId: number,
    taskId: number,
    state: number
  ): Observable<any> {
    const headers = this.auth.getHeadersWithToken();


    let convertedState = "";

    switch (state) {
      case 1:
        convertedState = "NotAssigned";
        break;
      case 2:
        convertedState = "AssignedWaitingCompletion";
        break;
      case 3:
        convertedState = "Completed";
        break;
    }


    let body = {
      state: convertedState,
    };

    console.log(body);

    return this.http.post<any>(
      this.buildUrlTaskString(this.projectsUrl, projectId, taskId) + '/state',
      body,
      { headers }
    );
  }

  buildUrlTaskString(
    projectsUrl: string,
    projectId: number,
    taskId: number
  ): string {
    return projectsUrl + '/' + projectId + '/tasks/' + taskId;
  }
}
