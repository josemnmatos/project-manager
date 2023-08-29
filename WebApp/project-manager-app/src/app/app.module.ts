import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProjectsComponent } from './projects/projects.component';
import { HomeComponent } from './home/home.component';
import { TasksComponent } from './projects/tasks/tasks.component';
import { ProjectDetailsComponent } from './projects/project-details/project-details.component';
import { TaskDetailsComponent } from './projects/tasks/task-details.component';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { NavbarComponent } from './navbar/navbar.component';
import { CreateProjectComponent } from './projects/create-project/create-project.component';
import { TaskCreationComponent } from './projects/tasks/task-creation.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ManagerDashboardComponent } from './manager-dashboard/manager-dashboard.component';
import { ManagerDashboardGeneralComponent } from './manager-dashboard/manager-dashboard-general/manager-dashboard-general.component';
import { ManagerDashboardProjectsComponent } from './manager-dashboard/manager-dashboard-projects/manager-dashboard-projects.component';
import { ManagerDashboardStaffComponent } from './manager-dashboard/manager-dashboard-staff/manager-dashboard-staff.component';
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ProfileComponent } from './profile/profile.component';
import { DeveloperDashboardComponent } from './developer-dashboard/developer-dashboard.component';
import { DaysAgoPipe } from './shared/days-ago-pipe';
import { TimelineModule } from 'primeng/timeline';
import { TimeInterval } from 'rxjs/internal/operators/timeInterval';
import { UnauthorizedPageComponent } from './unauthorized-page/unauthorized-page.component';
import { UnauthorizedInterceptorService } from './services/unauthorized-interceptor.service';
import { NotFoundPageComponent } from './not-found-page/not-found-page.component';
import { NotFoundInterceptorService } from './services/not-found-interceptor.service';

@NgModule({
  declarations: [
    AppComponent,
    ProjectsComponent,
    HomeComponent,
    TasksComponent,
    ProjectDetailsComponent,
    TaskDetailsComponent,
    LoginComponent,
    RegisterComponent,
    NavbarComponent,
    CreateProjectComponent,
    TaskCreationComponent,
    ManagerDashboardComponent,
    ManagerDashboardGeneralComponent,
    ManagerDashboardProjectsComponent,
    ManagerDashboardStaffComponent,
    ProfileComponent,
    DeveloperDashboardComponent,
    DaysAgoPipe,
    UnauthorizedPageComponent,
    NotFoundPageComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    NgxChartsModule,
    TimelineModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: UnauthorizedInterceptorService,
      multi: true,
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: NotFoundInterceptorService,
      multi: true,
    }
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
