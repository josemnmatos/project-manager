import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard {
  constructor(private authService: AuthService, private router: Router) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): boolean | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
    if (this.authService.isAuthenticated()) {
      // User is authenticated
      //check if token is still valid
      if (this.authService.tokenExpired(this.authService.getToken()!)) {
        // Token is expired, redirect to login page
        this.authService.logout();
        alert('Your session has expired, please login again.');
        return this.router.navigate(['/login']);
      }
      return true;
    } else {
      // User is not authenticated, redirect to login page
      return this.router.navigate(['/login']);
    }
  }
}