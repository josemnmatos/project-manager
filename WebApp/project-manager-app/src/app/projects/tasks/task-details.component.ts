import { Component, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Project } from '../project';
import { Task } from '../task';
import { Subscription } from 'rxjs';
import { ProjectService } from '../project.service';

@Component({
  selector: 'app-task-details',
  templateUrl: './task-details.component.html',
  styleUrls: ['./task-details.component.css']
})
export class TaskDetailsComponent {
  @Input() task: Task | undefined;
  sub!: Subscription;

  constructor(
    private projectService: ProjectService
  ) {}

  getTaskStateString(state: number){
    switch(state){
      case 1:
        return "Not Assigned";
      case 2:
        return "In Progress";
      case 3:
        return "Done";
    }

    return "Not Assigned";

  }



}
