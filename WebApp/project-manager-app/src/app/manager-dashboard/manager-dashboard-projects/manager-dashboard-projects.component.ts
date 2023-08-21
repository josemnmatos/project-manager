import { Component, OnDestroy, OnInit } from '@angular/core';
import { Input } from '@angular/core';
import { Manager } from 'src/app/shared/manager';
import { Project } from 'src/app/shared/project';
import { Subscription } from 'rxjs';
import { Developer } from 'src/app/shared/developer';
import { FormBuilder, Validators } from '@angular/forms';
import { ProjectService } from 'src/app/services/project.service';

@Component({
  selector: 'app-manager-dashboard-projects',
  templateUrl: './manager-dashboard-projects.component.html',
  styleUrls: ['./manager-dashboard-projects.component.css'],
})
export class ManagerDashboardProjectsComponent implements OnInit {
  @Input() manager!: Manager;
  selectedProject!: Project;
  allProjects?: Project[];
  projectCreationForm!: any;
  developerData!: any[];
  chartData!: any[];

  constructor(
    private fb: FormBuilder,
    private projectService: ProjectService
  ) {}

  colors = [
    { name: 'Not Assigned', value: '#DA292E' },
    { name: 'Pending', value: '#F4BD61' },
    { name: 'Completed', value: '#2FB380' },
  ];

  ngOnInit(): void {
    this.projectCreationForm = this.fb.group({
      name: ['', Validators.required],
      budget: ['', Validators.required],
      managerId: [, [Validators.required]],
    });

    this.allProjects = this.manager.projects as Project[];
    console.log(this.allProjects);
  }

  onSubmit() {
    this.projectCreationForm.controls['managerId'].setValue(this.manager.id);
    console.log(this.projectCreationForm.value);
    if (this.projectCreationForm.valid) {
      this.projectService
        .createProject(this.projectCreationForm.value)
        .subscribe(
          (res: any) => {
            console.log(res);
            this.projectCreationForm.reset();
          },
          (err:any) => {
            console.log(err);
          }
        );
    }
  }

  // convenience getter for easy access to form fields
  get f() {
    return this.projectCreationForm.controls;
  }

  setSelectedProject(project: Project) {
    this.selectedProject = project;
    this.chartData = this.processProjectData(project);
    this.developerData = this.processDeveloperData(project);
    console.log(this.chartData);
    console.log(this.developerData);
  }

  processProjectData(project: Project) {
    let data = [
      { name: 'Not Assigned', value: this.getNotAssignedTasks(project).length },
      { name: 'Pending', value: this.getPendingTasks(project).length },
      { name: 'Completed', value: this.getCompletedTasks(project).length },
    ];
    return data;
  }

  getNotAssignedTasks(project: Project) {
    let notAssignedTasks = project.tasks.filter((task) => task.state == 1);
    return notAssignedTasks;
  }

  getPendingTasks(project: Project) {
    let pendingTasks = project.tasks.filter((task) => task.state == 2);
    return pendingTasks;
  }

  getCompletedTasks(project: Project) {
    let completedTasks = project.tasks.filter((task) => task.state == 3);
    return completedTasks;
  }

  processDeveloperData(project: Project) {
    let data: any = [];
    project.tasks.forEach((task) => {
      if (task.developerAssignedTo) {
        if (data.find((d: any) => d.name == task.developerAssignedTo.firstName))
          return;

        data.push({
          name: task.developerAssignedTo.firstName,
          series: this.getTaskByDevelopersCount(
            project,
            task.developerAssignedTo
          ),
        });
      }
    });
    return data;
  }

  getTaskByDevelopersCount(project: Project, developer: Developer) {
    let data: any = [
      { name: 'Pending', value: 0 },
      { name: 'Completed', value: 0 },
    ];

    project.tasks.forEach((task) => {
      if (task.developerAssignedTo.id == developer.id) {
        if (task.state == 2) {
          data[0].value++;
        } else if (task.state == 3) {
          data[1].value++;
        }
      }
    });

    return data;
  }
}
