import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';
import { compileNgModule } from '@angular/compiler';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { LoginResponse } from './login-response';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;
  submitted = false;
  returnUrl!: string;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private auth: AuthService
  ) {}

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
    });
  }

  get f() {
    return this.loginForm.controls;
  }

  onSubmit() {
    this.submitted = true;

    console.log(this.loginForm.value);

    if (this.loginForm.invalid) {
      return;
    }

    this.auth.login(this.loginForm.value).subscribe({
      next: (res) => {
        console.log(res);
        let response : LoginResponse = res as LoginResponse;
        const token = response.token;

        this.auth.processToken(token);

        this.router.navigate(['projects']);
        

      },
      error: (err) => {
        alert(err);
      },
    });
  }
}
