import { Component, OnChanges, OnDestroy, OnInit } from '@angular/core';
import { ProjectService } from '../services/project.service';
import { TasksService } from '../services/tasks.service';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { DashboardService } from '../services/dashboard.service';
import { Project } from '../shared/project';
import { Manager } from '../shared/manager';

@Component({
  selector: 'app-manager-dashboard',
  templateUrl: './manager-dashboard.component.html',
  styleUrls: ['./manager-dashboard.component.css'],
})
export class ManagerDashboardComponent implements OnInit, OnDestroy, OnChanges {
  sub!: any;
  manager!: Manager;
  tab: string = 'projects';

  generalTab: boolean = false;
  projectsTab: boolean = true;
  staffTab: boolean = false;



  constructor(
    private dashboardService: DashboardService,
    private router: Router,
    private auth: AuthService
  ) {}

  ngOnInit(): void {
    let id = this.auth.getUserId()!;

    this.sub = this.dashboardService
      .getManagerDashboard(id)
      .subscribe((data) => {
        this.manager = data;
        console.log(this.manager);
      });
  }


  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  ngOnChanges() {
    console.log(this.generalTab);
    console.log(this.projectsTab);
    console.log(this.staffTab);

  }

  setGeneralTab() {
    this.generalTab = true;
    this.projectsTab = false;
    this.staffTab = false;
  }

  setProjectsTab() {
    this.generalTab = false;
    this.projectsTab = true;
    this.staffTab = false;
  }

  setStaffTab() {
    this.generalTab = false;
    this.projectsTab = false;
    this.staffTab = true;
  }
}
