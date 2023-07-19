import { Component, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Project } from './project';
import { Task } from './task';
import { Subscription } from 'rxjs';
import { ProjectService } from './project.service';

@Component({
  selector: 'app-project-details',
  templateUrl: './project-details.component.html',
  styleUrls: ['./project-details.component.css'],
})
export class ProjectDetailsComponent {
  @Input() project: Project | undefined;
  tasks: Task[] = [];
  taskNumber: number = 0;
  sub!: Subscription;

  constructor(
    private projectService: ProjectService
  ) {}

  ngOnInit(): void {
    if (this.project) {
      this.sub = this.projectService
        .getTasksForProject(this.project.id)
        .subscribe({
          next: (tasks) => {
            this.tasks = tasks;
          },
        });
    }

    this.taskNumber = this.tasks.length;
  }

  ngOnChanges(): void {
    //update tasks when project changes
      if (this.project) {
        this.sub = this.projectService
          .getTasksForProject(this.project.id)
          .subscribe({
            next: (tasks) => {
              this.tasks = tasks;
            },
          });
      }

    this.taskNumber = this.tasks.length;
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
}
