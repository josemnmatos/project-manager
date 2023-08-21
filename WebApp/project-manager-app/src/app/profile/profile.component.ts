import { Component } from '@angular/core';
import { ProfileService } from '../services/profile.service';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from '../shared/user';
import { Subscription } from 'rxjs';
import { OnDestroy } from '@angular/core';
import { OnInit } from '@angular/core';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
})
export class ProfileComponent implements OnInit, OnDestroy {
  constructor(
    private profileService: ProfileService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  userProfile! : User;
  isActiveUser = false;
  subscription!: Subscription;

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
      });
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
