import { Component, OnInit } from '@angular/core';
import { Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { of } from 'rxjs';
import { AuthService } from 'src/app/services/auth.service';
import { DashboardService } from 'src/app/services/dashboard.service';
import { Developer } from 'src/app/shared/developer';
import { Manager } from 'src/app/shared/manager';
import { Project } from 'src/app/shared/project';

@Component({
  selector: 'app-manager-dashboard-staff',
  templateUrl: './manager-dashboard-staff.component.html',
  styleUrls: ['./manager-dashboard-staff.component.css'],
})
export class ManagerDashboardStaffComponent implements OnInit {
  @Input() manager!: Manager;
  selectedProject!: Project | null;
  selectedRole!: string;
  staffInfoList!: any[];
  developerInfoList!: any[];
  managerInfoList!: any[];
  allUserInfoList!: any[];
  registerForm!: FormGroup;
  submitted: boolean = false;
  accountType: string = 'manager';

  constructor(private ds: DashboardService, 
              private fb: FormBuilder,
              private auth: AuthService) {}

  rolesName = ['All roles', 'Manager', 'Developer'];

  ngOnInit(): void {
    this.registerForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmedPassword: ['', Validators.required],
      role: ['manager', Validators.required],
    });

    //get all users from auth service
    this.ds.getAllUsers().subscribe((users) => {
      console.log(users);
      //sort users to their roles list
      this.developerInfoList = users.filter(
        (user) => user.role === 'developer'
      );
      this.managerInfoList = users.filter((user) => user.role === 'manager');

      //staff list is all users
      this.allUserInfoList = users;
      this.staffInfoList = this.allUserInfoList;
    });
  }

  onSubmit() {
    this.submitted = true;
    console.log(this.registerForm.value);

    if (this.registerForm.valid) {
      this.auth.register(this.registerForm.value).subscribe(
        (res) => {
          console.log(res);
          this.registerForm.reset();
        },
        (err) => {
          console.log(err);
        }
      );
    } else {
      alert('Please fill all the fields');

    }

  }

  changeAccountType() {
    if (this.accountType == 'manager') {
      this.accountType = 'developer';
      this.registerForm.controls['role'].setValue('developer');
    } else {
      this.accountType = 'manager';
      this.registerForm.controls['role'].setValue('manager');
    }
  }

  setSelectedProject(project: Project | null) {
    this.selectedProject = project;
    console.log(this.selectedProject);
    this.staffInfoList = this.staffInfoList;
  }

  setSelectedRole(role: string) {
    this.selectedRole = role;
    console.log(this.selectedRole);
    if (role === 'All roles') {
      this.staffInfoList = this.allUserInfoList;
    } else if (role === 'Manager') {
      this.staffInfoList = this.managerInfoList;
    } else {
      this.staffInfoList = this.developerInfoList;
    }
    console.log(this.staffInfoList);
  }

  getAllDevelopersFromProject(project: Project) {
    let developers: Developer[] = [];
    project.tasks?.forEach((t) => {
      if (!(t.developerAssignedTo.id in developers)) {
        developers.push(t.developerAssignedTo);
      }
    });

    return developers;
  }
}
