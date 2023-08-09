import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProjectsComponent } from './projects/projects.component';
import { HomeComponent } from './home/home.component';
import { ProjectDetailsComponent } from './projects/project-details/project-details.component';
import { TasksComponent } from './projects/tasks/tasks.component';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { TaskDetailsComponent } from './projects/tasks/task-details.component';
import { AuthGuard } from './services/auth-guard.service';
import { ManagerDashboardComponent } from './manager-dashboard/manager-dashboard.component';
import { ManagerGuard } from './services/manager-guard.service';



const routes: Routes = [
  { path:"", component: HomeComponent },
  { path:"projects", component: ProjectsComponent, canActivate: [AuthGuard] },
  { path:"projects/:id", component: ProjectDetailsComponent, canActivate: [AuthGuard]},
  { path:"projects/:id/tasks", component: TasksComponent, canActivate: [AuthGuard]},
  { path:"projects/:projectid/tasks/:taskid", component: TaskDetailsComponent, canActivate: [AuthGuard]},
  { path:"dashboard/manager", component:ManagerDashboardComponent, canActivate: [ManagerGuard]},
  //insert here

  
  { path:"login", component: LoginComponent },
  { path:"register", component: RegisterComponent },
  { path:"**", redirectTo: "/", pathMatch: "full" }


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
