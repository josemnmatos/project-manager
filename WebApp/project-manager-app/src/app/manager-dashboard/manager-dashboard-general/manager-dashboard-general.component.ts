import { Component, OnInit } from '@angular/core';
import { Input } from '@angular/core';
import { Manager } from 'src/app/shared/manager';
import { Project } from 'src/app/shared/project';


@Component({
  selector: 'app-manager-dashboard-general',
  templateUrl: './manager-dashboard-general.component.html',
  styleUrls: ['./manager-dashboard-general.component.css']
})
export class ManagerDashboardGeneralComponent implements OnInit{

  @Input() manager!: Manager;


  ngOnInit(): void {



  }


  countTasksForProjects(project:Project, state:number){
    let count = 0;
    project.tasks.forEach(task => {
      if(task.state == state){
        count++;
      }
    });
    return count;
  }

  getPercentage(project:Project){
    
    if(project.tasks.length == 0){
      return 0;
    }
    
    let count = 0;
    project.tasks.forEach(task => {
      if(task.state == 3){
        count++;
      }
    });



    return count/project.tasks.length*100;
  }




}
