import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';

import {FormControl, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';
import { AccountService } from '../../services/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-form',
  imports: [
    MatButtonModule,
    MatCardModule,
    MatSelectModule,
    MatInputModule,
    MatFormFieldModule,
    ReactiveFormsModule

  ],
  templateUrl: './login-form.component.html',
  styleUrl: './login-form.component.css'
})
export class LoginFormComponent {

  errorMessage: string = "";

  constructor(private accountService: AccountService, private router: Router) {}

  form = new FormGroup({
    firstName: new FormControl('', Validators.required),
    lastName: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required),
    email: new FormControl('', Validators.required),
    phoneNumber: new FormControl('', Validators.required),
  })

  onSubmit() {
    this.accountService.login(
      this.form.value.email!,
      this.form.value.password!
    ).subscribe(result => {
        // this.result = result;
        console.log(result);
        if (result === true) {
          // this.errorMessage = "";
          this.router.navigate(["/products/all"]);
        } 
        else
          this.errorMessage = "Email or password is incorrect.";
    });
  }
}
