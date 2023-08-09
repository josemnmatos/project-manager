import { Component } from '@angular/core';
import { Project, NewProject } from '../../shared/project';
import { ProjectService } from '../../services/project.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-project',
  templateUrl: './create-project.component.html',
  styleUrls: ['./create-project.component.css'],
})
export class CreateProjectComponent {
  constructor(private projectService: ProjectService
            , private router : Router ) {}

  ngOnInit(): void {}

  onClickSubmit(result: any) {
    console.log(result.name);
    console.log(result.budget);

    let project: NewProject = {
      name: result.name,
      budget: result.budget,
      //!!CHANGE THIS PART
      managerId: 1,
    };

    this.sendPostRequest(project);

    //navigate to projects
    this.router.navigateByUrl('/projects');

  }

  sendPostRequest(project: NewProject) {
    this.projectService.postNewProject(project).subscribe((response: any) => {
      console.log(response);
    });
  }
}
