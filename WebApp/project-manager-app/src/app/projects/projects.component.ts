import { Component, OnInit } from '@angular/core';
import { Project } from '../shared/project';
import { ProjectService } from '../services/project.service';
import { Task } from '../shared/task';
import { Subscription } from 'rxjs';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.css'],
})
export class ProjectsComponent implements OnInit {
  activeProjects: Project[] = [];
  sub!: Subscription;
  currentUserId = Number(this.auth.getUserId());
  myProjects: Project[] = [];

  constructor(
    private projectService: ProjectService,
    private auth: AuthService
  ) {}

  isManagerOfProject(project: Project) {
    if (project.managerAssignedTo.id == this.currentUserId) {
      return true;
    }
    return false;
  }

  ngOnInit(): void {
    // load projects
    this.sub = this.projectService.getProjects().subscribe((projects) => {
      let received = projects;
      this.activeProjects = received;

      this.activeProjects.forEach((project) => {
        if (this.isManagerOfProject(project)) {
          this.myProjects.push(project);
        }
      });

      // sort by task count descending

      this.myProjects.sort((a, b) => {
        return b.tasks.length - a.tasks.length;
      });
    });
  }

  ngOnChanges(): void {}

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
}
