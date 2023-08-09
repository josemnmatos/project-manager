import { Component, OnInit } from '@angular/core';
import { Project } from '../shared/project';
import { ProjectService } from '../services/project.service';
import { Task } from '../shared/task';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.css'],
})
export class ProjectsComponent implements OnInit {
  activeProjects: Project[] = [];
  sub!: Subscription;

  constructor(private projectService: ProjectService) {}

  ngOnInit(): void {
    // load projects
    this.sub = this.projectService.getProjects().subscribe((projects) => {
      let received = projects;
      this.activeProjects = received;
      // sort by task count descending

      this.activeProjects.sort((a, b) => {
        return b.tasks.length - a.tasks.length;
      });
    });
  }

  ngOnChanges(): void {}

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
}
