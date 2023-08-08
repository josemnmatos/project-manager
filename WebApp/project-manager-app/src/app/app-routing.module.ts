import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProjectsComponent } from './projects/projects.component';
import { HomeComponent } from './home/home.component';
import { ProjectDetailsComponent } from './projects/project-details.component';
import { TasksComponent } from './projects/tasks/tasks.component';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { TaskDetailsComponent } from './projects/tasks/task-details.component';



const routes: Routes = [
  { path:"", component: HomeComponent },
  { path:"projects", component: ProjectsComponent },
  { path:"projects/:id", component: ProjectDetailsComponent},
  { path:"projects/:id/tasks", component: TasksComponent},
  { path:"projects/:projectid/tasks/:taskid", component: TaskDetailsComponent},

  //insert here

  
  { path:"login", component: LoginComponent },
  { path:"register", component: RegisterComponent },
  { path:"**", redirectTo: "", pathMatch: "full" }


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
