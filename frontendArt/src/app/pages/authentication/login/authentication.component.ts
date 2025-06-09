import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { AuthenticationService } from '../../../service/authentication/authentication.service';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { jwtDecode } from 'jwt-decode';

interface JwtPayload {
  'http://schemas.microsoft.com/ws/2008/06/identity/claims/role': string;
}


@Component({
  selector: 'app-authentication',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './authentication.component.html',
  styleUrl: './authentication.component.css'
})
export class AuthenticationComponent {

  loginForm: FormGroup;

  constructor(private authService: AuthenticationService, private router: Router) {
    this.loginForm = new FormGroup({
      username: new FormControl("", [Validators.required,]),
      password: new FormControl("", [Validators.required,])
    })
  }

  login() {
    this.authService.Login(this.loginForm.value.username, this.loginForm.value.password)
      .subscribe(response => {
        console.log("response", response);
        if (response.token) {
          sessionStorage.setItem("jwt", response.token);
          const decoded = jwtDecode<JwtPayload>(response.token);
          const role = decoded['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];

          // Redirection selon le rôle
          if (role === 'Artisan') {
            this.router.navigate(['/artisan/dashboard']);
          } else if (role === 'Customer') {
            this.router.navigate(['/client/dashboard']);
          } else if (role === 'DeliveryPartner') {
            this.router.navigate(['/partner']);
          } else {
            this.router.navigate(['/']);
          }
        }
        error: () => alert('Connection failed.')
      })
  }

}
