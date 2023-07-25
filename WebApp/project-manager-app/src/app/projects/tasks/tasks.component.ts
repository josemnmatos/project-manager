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
  project?: Project;
  sub!: Subscription;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private projectService: ProjectService
  ) {}

  ngOnInit(): void {
    //get project id from route
    const id = Number(this.route.snapshot.paramMap.get('id'));
    if (!id) {
      this.router.navigate(['/projects']);
    }

    // load the project
    this.sub = this.projectService.getProjectById(id).subscribe((project) => {
      this.project = project;
    });

    // load the tasks
    this.sub = this.projectService.getTasksForProject(id).subscribe((tasks) => {
      this.project!.tasks = tasks;
    });
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
}
