import { Component, OnDestroy, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { DashboardService } from '../services/dashboard.service';
import { Subscription } from 'rxjs';
import { Developer } from '../shared/developer';
import { DaysAgoPipe } from '../shared/days-ago-pipe';
import { Task } from '../shared/task';
import { TasksService } from '../services/tasks.service';

@Component({
  selector: 'app-developer-dashboard',
  templateUrl: './developer-dashboard.component.html',
  styleUrls: ['./developer-dashboard.component.css'],
})
export class DeveloperDashboardComponent implements OnInit, OnDestroy {
  sub!: Subscription;
  developer?: Developer;
  tasks?: any[];
  taskTimeline?: any[];
  activeTasks?: any[];
  selectedTask?: Task;
  tasksToShow?: any[];

  constructor(
    private auth: AuthService,
    private dashboardService: DashboardService,
    private taskService: TasksService
  ) {}

  ngOnInit(): void {
    //get the current user id
    const userId = this.auth.getUserId();
    //get the user data
    if (userId) {
      this.sub = this.dashboardService
        .getDeveloperDashboard(userId)
        .subscribe((data) => {
          this.developer = data;
          this.tasks = data.tasks;
          this.tasksToShow = data.tasks;

          //get the active tasks only( not expired)
          this.activeTasks = this.tasks?.filter((task) => {
            return !this.taskExpired(task);
          });

          console.log(this.tasks);
          console.log(this.activeTasks);

          console.log(data);
        });
    }
  }

  setTaskState(task: any, state: number) {
    const projectId = task.projectAssociatedTo.id;
    const taskId = task.id;

    let updatedTask = task;
    updatedTask.state = state;

    //add developerId to updatedTask
    updatedTask = {
      ...updatedTask,
      developerId: this.developer?.id,
    };

    this.taskService.putTask(projectId, updatedTask).subscribe((data) => {
      console.log(data);
    });
  }

  taskExpired(task: any) {
    // datettime for now

    const currentDate = new Date();
    const deadlineDate = new Date(task.deadline);
    const timeDiff = deadlineDate.getTime() - currentDate.getTime();

    console.log(currentDate);
    console.log(deadlineDate);

    console.log(timeDiff);

    return timeDiff < 0;
  }

  selectTask(task: Task) {
    this.selectedTask = task;
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  myStateSelectHandler(event: any) {
    console.log(event);
    let tasks = this.tasks!;
    switch (event) {
      case 'all':
        this.showAllTasks();
        break;
      case 'notStarted':
        this.showNotStartedTasks();
        break;
      case 'pending':
        this.showPendingTasks();
        break;
      case 'completed':
        this.showCompletedTasks();
        break;
    }
  }

  showAllTasks() {
    this.tasksToShow = this.tasks;
  }

  showNotStartedTasks() {
    this.tasksToShow = this.tasks?.filter((task) => {
      return task.state == 1;
    });
  }

  showPendingTasks() {
    this.tasksToShow = this.tasks?.filter((task) => {
      return task.state == 2;
    });
  }

  showCompletedTasks() {
    this.tasksToShow = this.tasks?.filter((task) => {
      return task.state == 3;
    });
  }

  sortByDeadline() {
    let tasks = this.tasksToShow!;

    return tasks.sort((a, b) => {
      return new Date(a.deadline).getTime() - new Date(b.deadline).getTime();
    });
  }

  sortByName() {
    let tasks = this.tasksToShow!;
    console.log(tasks);
    return tasks.sort((a, b) => {
      return a.name.localeCompare(b.name);
    });
  }

  sortByProjectName() {
    let tasks = this.tasksToShow!;
    return tasks.sort((a, b) => {
      return a.projectAssociatedTo.name.localeCompare(
        b.projectAssociatedTo.name
      );
    });
  }

  mySelectHandler(event: any) {
    console.log(event);
    let tasks = this.tasks!;
    switch (event) {
      case 'deadline':
        this.tasksToShow = this.sortByDeadline();
        break;
      case 'name':
        this.tasksToShow = this.sortByName();
        break;
      case 'projectName':
        this.tasksToShow = this.sortByProjectName();
        break;
    }
  }
}
