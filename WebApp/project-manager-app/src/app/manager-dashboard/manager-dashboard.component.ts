import { Component, OnInit } from '@angular/core';
import { ProjectService } from '../services/project.service';
import { TasksService } from '../services/tasks.service';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-manager-dashboard',
  templateUrl: './manager-dashboard.component.html',
  styleUrls: ['./manager-dashboard.component.css']
})
export class ManagerDashboardComponent implements OnInit {

  userEmail = "";


  constructor(
    private projectService: ProjectService,
    private taskService: TasksService,
    private router : Router,
    private auth : AuthService
  ) { }


  ngOnInit(): void {
    this.userEmail = this.auth.getEmail()!;
    console.log(this.userEmail);
  }

}
