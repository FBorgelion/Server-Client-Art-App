import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from '../../service/authentication/authentication.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent {

  constructor(private authService: AuthenticationService, private router: Router) { }

  isLoggedIn(): boolean {
    return this.authService.isAuthenticated();  
  }

  login(): void {
    this.router.navigate(['/auth/login']); 
  }

  logout(): void {
    this.authService.logout();  
    this.router.navigate(['/auth/login']);  
  }

}
