import { Component } from '@angular/core';
import { Project } from './project';
import { ProjectService } from './project.service';
import { Task } from './task';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.css']
})
export class ProjectsComponent {
  projects : Project[] = [];
  activeProject : Project | undefined;
  activeProjectId : number | undefined;
  sub! : Subscription;

  constructor(private projectService: ProjectService) {};

  ngOnInit(): void {
    this.sub = this.projectService.getProjects().subscribe({
      next: projects => {
        this.projects = projects;
      }
    });
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  setActiveProject(id: number) : void {
    this.activeProjectId = id;
    this.activeProject = this.projects.find(project => project.id === id);
    console.log(this.activeProject);
  }



}
