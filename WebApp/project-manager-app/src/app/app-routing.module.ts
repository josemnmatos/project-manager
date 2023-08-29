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
import { ManagerDashboardGeneralComponent } from './manager-dashboard/manager-dashboard-general/manager-dashboard-general.component';
import { ManagerDashboardStaffComponent } from './manager-dashboard/manager-dashboard-staff/manager-dashboard-staff.component';
import { ManagerDashboardProjectsComponent } from './manager-dashboard/manager-dashboard-projects/manager-dashboard-projects.component';
import { ProfileComponent } from './profile/profile.component';
import { DeveloperGuard } from './services/developer-guard.service';
import { DeveloperDashboardComponent } from './developer-dashboard/developer-dashboard.component';
import { UserExistsGuard } from './services/user-exists-guard.service';
import { UnauthorizedPageComponent } from './unauthorized-page/unauthorized-page.component';
import { NotFoundPageComponent } from './not-found-page/not-found-page.component';



const routes: Routes = [
  { path:"", component: HomeComponent },
  { path:"projects", component: ProjectsComponent, canActivate: [AuthGuard, ManagerGuard] },
  { path:"projects/:id", component: ProjectDetailsComponent, canActivate: [AuthGuard, ManagerGuard]},
  { path:"projects/:id/tasks", component: TasksComponent, canActivate: [AuthGuard, ManagerGuard]},
  { path:"projects/:projectid/tasks/:taskid", component: TaskDetailsComponent, canActivate: [AuthGuard, ManagerGuard]},
  { path:"dashboard/manager", component:ManagerDashboardComponent,children:
  [
    {
      path:'general',component:ManagerDashboardGeneralComponent
    },
    {
      path:'projects',component:ManagerDashboardProjectsComponent
    },
    {
      path:'staff',component:ManagerDashboardStaffComponent
    },

  ], canActivate: [AuthGuard,ManagerGuard]},

  { path:"dashboard/developer", component:DeveloperDashboardComponent,canActivate: [AuthGuard, DeveloperGuard]},

  { path:"user/profile/:id", component: ProfileComponent, canActivate: [AuthGuard, UserExistsGuard] },
  
  {path : "unauthorized", component: UnauthorizedPageComponent},

  {path : "notfound", component: NotFoundPageComponent},
  
  
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
