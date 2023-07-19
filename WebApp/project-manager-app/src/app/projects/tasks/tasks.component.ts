import { Component } from '@angular/core';
import { Input } from '@angular/core';
import { Project } from '../project';
import { Task } from '../task';
import { ProjectService } from '../project.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css'],
})
export class TasksComponent {
  project: Project | undefined;
  tasks: Task[] = [];
  activeTask: Task | undefined;
  activeTaskId: number | undefined;
  sub! : Subscription;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private projectService: ProjectService
  ) {}

  ngOnInit(): void {
    //get project id from route
    const routeParams = this.route.snapshot.paramMap;
    const projectIdFromRoute = Number(routeParams.get('id'));

    //get tasks from service
    this.sub = this.projectService
        .getTasksForProject(projectIdFromRoute)
        .subscribe({
          next: (tasks) => {
            this.tasks = tasks;
          },
        });
  }

  ngOnChanges(): void {
    console.log(this.project);
    console.log(this.tasks);
  }

  ngOnDestroy(): void {
    console.log(this.project);
    console.log(this.tasks);
    this.sub.unsubscribe();
  }

  setActiveTask(id: number): void {
    this.activeTaskId = id;
    this.activeTask = this.tasks.find((task) => task.id === id);
    console.log(this.activeTask);
  }


  


}
