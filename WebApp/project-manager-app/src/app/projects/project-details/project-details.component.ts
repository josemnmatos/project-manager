import { Component, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Project } from '../../shared/project';
import { Subscription } from 'rxjs';
import { ProjectService } from '../../services/project.service';
import { Manager } from '../../shared/manager';
import { Task } from 'src/app/shared/task';

@Component({
  selector: 'app-project-details',
  templateUrl: './project-details.component.html',
  styleUrls: ['./project-details.component.css'],
})
export class ProjectDetailsComponent {
  sub!: Subscription;
  project?: Project;
  selectedTask! : Task;
  

  constructor(
    private projectService: ProjectService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    // get the id from the url
    const id = Number(this.route.snapshot.paramMap.get('id'));
    if (!id) {
      this.router.navigate(['/projects']);
    }

    // load the project
    this.sub = this.projectService.getProjectById(id).subscribe((project) => {
      this.project = project;
      
    });
  }

  selectTask(task: Task) {
    this.selectedTask = task;
    console.log(this.selectedTask);
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
}
