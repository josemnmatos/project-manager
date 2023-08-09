import { Component, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Project } from './project';
import { Subscription } from 'rxjs';
import { ProjectService } from './project.service';
import { Manager } from '../shared/manager';

@Component({
  selector: 'app-project-details',
  templateUrl: './project-details.component.html',
  styleUrls: ['./project-details.component.css'],
})
export class ProjectDetailsComponent {
  sub!: Subscription;
  project?: Project;
  

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

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
}
