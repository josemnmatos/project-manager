import { Component, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Project } from '../../shared/project';
import { Task } from '../../shared/task';
import { Subscription } from 'rxjs';
import { ProjectService } from '../../services/project.service';

@Component({
  selector: 'app-task-details',
  templateUrl: './task-details.component.html',
  styleUrls: ['./task-details.component.css'],
})
export class TaskDetailsComponent {
  @Input() task: Task | undefined;
  sub!: Subscription;
  projectId!: number;
  daysToDeadline!: number;

  constructor(
    private projectService: ProjectService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    // get the id from the url
    const projectid = Number(this.route.snapshot.paramMap.get('projectid'));
    this.projectId = projectid;
    const taskid = Number(this.route.snapshot.paramMap.get('taskid'));

    //load task
    this.sub = this.projectService
      .getTaskById(projectid, taskid)
      .subscribe((task) => {
        this.task = task;
        console.log(this.task.deadline);
        this.daysToDeadline = this.getDaysToDeadline(this.task!.deadline);
      });

    //this.daysToDeadline = this.getDaysToDeadline(this.task!.deadline);
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  getTaskStateString(state: number) {
    switch (state) {
      case 1:
        return 'Not Assigned';
      case 2:
        return 'In Progress';
      case 3:
        return 'Done';
    }
    return 'Not Assigned';
  }

  getDaysToDeadline(deadline: Date) {
    let today = new Date();
    let deadlineDate = new Date(deadline);
    let diff = deadlineDate.getTime() - today.getTime();
    let days = Math.ceil(diff / (1000 * 3600 * 24));
    console.log(days);

    return days;
  }
}
