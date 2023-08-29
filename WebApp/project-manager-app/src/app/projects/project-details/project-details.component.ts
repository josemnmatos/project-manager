import { Component, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Project } from '../../shared/project';
import { Subscription } from 'rxjs';
import { ProjectService } from '../../services/project.service';
import { Manager } from '../../shared/manager';
import { Task } from 'src/app/shared/task';
import { TasksService } from 'src/app/services/tasks.service';
import { Developer } from 'src/app/shared/developer';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ProfileService } from 'src/app/services/profile.service';

@Component({
  selector: 'app-project-details',
  templateUrl: './project-details.component.html',
  styleUrls: ['./project-details.component.css'],
})
export class ProjectDetailsComponent {
  sub!: Subscription;
  project?: Project;
  selectedTask?: Task;
  selectedTaskNoChanges?: Task;
  developerList?: Developer[];
  tasksToShow?: any[];
  tasks?: any[];

  taskForm!: FormGroup;
  taskCreationForm!: FormGroup;
  taskToUpdate?: Task; // This will hold the task data to be updated

  constructor(
    private formBuilder: FormBuilder,
    private projectService: ProjectService,
    private taskService: TasksService,
    private route: ActivatedRoute,
    private router: Router,
    private profileService: ProfileService
  ) {}

  ngOnInit(): void {
    // Initialize the form with empty values
    this.taskForm = this.formBuilder.group({
      name: ['', Validators.required],
      description: ['', Validators.required],
      state: ['', Validators.required],
      deadline: ['', Validators.required],
      developerId: [0, Validators.required],
    });

    this.taskCreationForm = this.formBuilder.group({
      name: ['', Validators.required],
      description: ['', Validators.required],
      state: ['', Validators.required],
      deadline: ['', Validators.required],
      developerId: [0, Validators.required],
    });

    this.taskForm.get('deadline')?.patchValue(this.formatDate(new Date()));

    // get the id from the url
    const id = Number(this.route.snapshot.paramMap.get('id'));
    if (!id) {
      this.router.navigate(['/projects']);
    }

    // load the project
    this.sub = this.projectService.getProjectById(id).subscribe((project) => {
      this.project = project;
      if (project.tasks.length > 0) {
        this.selectTask(project.tasks[0]);
        this.tasks = project.tasks;
        this.tasksToShow = project.tasks;
      }
    });

    // load the developer list
    this.sub = this.profileService.getDevelopers().subscribe((developers) => {
      this.developerList = developers;
    });
  }

  private formatDate(date: any) {
    const d = new Date(date);
    let month = '' + (d.getMonth() + 1);
    let day = '' + d.getDate();
    const year = d.getFullYear();
    if (month.length < 2) month = '0' + month;
    if (day.length < 2) day = '0' + day;
    return [year, month, day].join('-');
  }

  populateFormWithExistingData() {
    // Assuming you have the existing task data fetched and stored in 'this.taskToUpdate'
    if (this.taskToUpdate) {
      this.taskForm.patchValue({
        name: this.taskToUpdate.name,
        description: this.taskToUpdate.description,
        state: this.taskToUpdate.state,
        deadline: this.formatDate(this.taskToUpdate.deadline),
        developerId: this.taskToUpdate.developerAssignedTo.id,
      });
    }
  }

  selectTask(task: Task) {
    this.selectedTask = task;
    this.taskToUpdate = task;
    this.populateFormWithExistingData();
    console.log(this.selectedTask);
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  formCheckIfAssignedCreation() {
    if (this.taskCreationForm.get('state')?.value == 1) {
      return false;
    }
    return true;
  }

  formCheckIfAssigned() {
    if (this.taskForm.get('state')?.value == 1) {
      return false;
    }
    return true;
  }

  onClickSubmit() {
    if (this.taskForm.valid) {
      // Get the updated form values
      const updatedTask: any = {
        id: this.taskToUpdate?.id, // Assuming you won't change the ID
        ...this.taskForm.value,
      };

      console.log(updatedTask);

      // Call the service to update the task
      this.taskService
        .putTask(this.project!.id, updatedTask)
        .subscribe((res) => {
          console.log(res);
          // Refresh the page
        });

      // reload the page
      window.location.reload();
    } else {
      alert('Please fill all the fields');
    }
  }

  onClickSubmitCreation() {
    if (this.taskCreationForm.valid) {
      // Get the updated form values
      const newTask: any = {
        ...this.taskCreationForm.value,
      };

      console.log(newTask);

      // Call the service to update the task
      this.taskService
        .createTask(this.project!.id, newTask)
        .subscribe((res) => {
          console.log(res);
          // Refresh the page
        });

      // reload the page
      window.location.reload();
    } else {
      alert('Please fill all the fields');
    }
  }

  onClickCancel() {
    // Reset the form
    this.taskForm.reset();
    // refresh the page
  }

  onClickCancelCreation() {
    // Reset the form
    this.taskCreationForm.reset();
    // refresh the page
  }

  setSelectedTaskName(name: string) {
    this.selectedTask!.name = name;
  }

  //filter helper methods
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
