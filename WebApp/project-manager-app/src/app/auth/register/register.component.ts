import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../auth.service';
import { MustMatch } from './must-match.validator';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  accountType: string = 'manager';
  registerForm! : FormGroup;
  submitted = false;

  constructor(private auth: AuthService, private fb: FormBuilder) {}

  ngOnInit(): void {
    this.registerForm = this.fb.group(
      {
        firstName: ['', Validators.required],
        lastName: ['', Validators.required],
        email: ['', [Validators.required, Validators.email]],
        password: ['', [Validators.required, Validators.minLength(6)]],
        confirmedPassword: ['', Validators.required],
        role: ['manager', Validators.required],
      }
    );
  }

  // convenience getter for easy access to form fields
  get f() {
    return this.registerForm.controls;
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

  onReset() {
    this.submitted = false;
    this.registerForm.reset();
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
}
