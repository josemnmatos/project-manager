import { Component } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent {
  accountType: string = 'manager';

  changeAccountType() {
    if (this.accountType == 'manager') {
      this.accountType = 'developer';
    } else {
      this.accountType = 'manager';
    }
  }

}
