import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { ReactiveFormsModule, FormControl, FormBuilder, Validators, FormGroup } from '@angular/forms';
import { AccountService } from '../../services/account.service';
import { CommonModule } from '@angular/common';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-signup-form',
  imports: [
    CommonModule,
    MatButtonModule,
    MatCardModule,
    MatSelectModule,
    MatInputModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    RouterLink
  ],
  templateUrl: './signup-form.component.html',
  styleUrl: './signup-form.component.css'
})
export class SignupFormComponent {

  result : boolean | null = null;
  errorMessage: string = "";
  constructor(private accountService: AccountService, private router: Router) {}

  registerForm = new FormGroup({
    firstName: new FormControl('', Validators.required),
    lastName: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required),
    email: new FormControl('', Validators.required),
    phoneNumber: new FormControl('', Validators.required),
  })

  async onSubmit() {
    this.accountService.register({ 
      firstName: this.registerForm.value.firstName!, 
      lastName: this.registerForm.value.lastName!, 
      password: this.registerForm.value.password!, 
      email: this.registerForm.value.email!, 
      phone: this.registerForm.value.phoneNumber!, 
      role: "customer", 
      token: ""  
    }).subscribe(result => {
        this.result = result;
        if (this.result === true) {
          this.errorMessage = "";
          this.router.navigate(["/login"]);
        } 
        else
          this.errorMessage = "This email address is already in use.";
    });


  }
}
