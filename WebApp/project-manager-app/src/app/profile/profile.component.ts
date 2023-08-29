import { Component } from '@angular/core';
import { ProfileService } from '../services/profile.service';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from '../shared/user';
import { Subscription } from 'rxjs';
import { OnDestroy } from '@angular/core';
import { OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
})
export class ProfileComponent implements OnInit, OnDestroy {
  constructor(
    private profileService: ProfileService,
    private router: Router,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private auth : AuthService

  ) {}

  editProfileForm = this.fb.group({
    firstName: [''],
    lastName: [''],
    email: [''],
  });

  changePasswordForm = this.fb.group({
    currentPassword: [''],
    newPassword: [''],
    confirmNewPassword: [''],
  });

  userProfile!: User;
  isActiveUser = false;
  subscription!: Subscription;

  loadEditProfileForm() {
    this.editProfileForm.get('firstName')?.setValue(this.userProfile.firstName);
    this.editProfileForm.get('lastName')?.setValue(this.userProfile.lastName);
    this.editProfileForm.get('email')?.setValue(this.userProfile.email);
  }

  ngOnInit(): void {
    //get the user id from the url
    const id = Number(this.route.snapshot.paramMap.get('id'));

    //get the user profile
    this.subscription = this.profileService
      .getUserProfile(id)
      .subscribe((user: User) => {
        this.userProfile = user;
        console.log(this.userProfile);
        //check if the user is the active user
        let activeUserId = Number(localStorage.getItem('id'));
        if (activeUserId === user.id) {
          this.isActiveUser = true;
        }

        this.loadEditProfileForm();
      });
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  onSubmitEdit() {
    let user = {
      firstName: this.editProfileForm.get('firstName')?.value,
      lastName: this.editProfileForm.get('lastName')?.value,
      email: this.editProfileForm.get('email')?.value,
    };

    this.profileService.updateUserProfile(this.userProfile.id,user).subscribe((user: User) => {
      this.userProfile = user;
      console.log(this.userProfile);
      this.loadEditProfileForm();
    });

    //reload the page
    window.location.reload();




  }

  onSubmitChangePassword() {

    let password = {
      oldPassword: this.changePasswordForm.get('currentPassword')?.value,
      newPassword: this.changePasswordForm.get('newPassword')?.value,
    };

    console.log(password);

    this.profileService.updatePassword(this.userProfile.id,password).subscribe((user: User) => {
      this.userProfile = user;
      console.log(this.userProfile);
      this.loadEditProfileForm();
    }

    );

    //window.location.reload();
  }

  onDelete() {

    //delete the user from the profile
    let activeUserId = this.userProfile.id;

    this.profileService.deleteUser(activeUserId).subscribe((user: User) => {
      console.log("User deleted");

      if(activeUserId === Number(localStorage.getItem('id'))){
        //logout
        this.auth.logout();
      }else{
        //navigate to dashboard
        this.router.navigate(['/dashboard/manager']);
      }


    });

    
    

  }
}
