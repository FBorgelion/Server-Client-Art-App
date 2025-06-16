import { Component } from '@angular/core';
import {FormControl,FormGroup,Validators,ReactiveFormsModule} from '@angular/forms';
import { CommonModule } from '@angular/common';
import { AuthenticationService } from '../../../service/authentication/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {

  registerForm: FormGroup;

  isLoading = false;
  errorMessage = '';

  constructor(private authService: AuthenticationService, private router: Router) {
    this.registerForm = new FormGroup({
      username: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required, Validators.minLength(3)]),
      role: new FormControl('', [Validators.required])
    });
  }

  register() {
    if (this.registerForm.invalid) {
      this.errorMessage = 'Please fill all fields and select a role.';
      return;
    }

    this.isLoading = true;
    this.errorMessage = '';

    const { username, email, password, role } = this.registerForm.value;
    this.authService.register(username, email, password, role)
      .subscribe({
        next: () => {
          this.isLoading = false;
          this.router.navigate(['/auth/login']);
        },
        error: err => {
          this.isLoading = false;
          this.errorMessage = err?.error?.message || 'Registration failed. Please fill both fields and ensure you password follow the right poilicy';
        }
      });
  }
}
