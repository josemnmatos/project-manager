import { ActivatedRouteSnapshot, Router, RouterStateSnapshot, UrlTree } from "@angular/router";
import { AuthService } from "./auth.service";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ProfileService } from "./profile.service";

@Injectable({
   providedIn: 'root'
 })
 export class UserExistsGuard {
   constructor(private authService: AuthService, private router: Router,
      private profileService: ProfileService) {}
 
   canActivate(
     route: ActivatedRouteSnapshot,
     state: RouterStateSnapshot
   ): boolean | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
     
      // Get the id from the route
      const id = Number(route.paramMap.get('id'));
      // Get the user from the profile service
      this.profileService.getUserProfile(id).subscribe(user => {
         // If the user is not found, redirect to home page
         console.log(user);
         
         if (!user) {
            this.router.navigate(['/']);
         }
      });
      return true;
   }
 }