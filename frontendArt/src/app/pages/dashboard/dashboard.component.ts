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

  goToDashboard(): void {
    if (!this.isLoggedIn()) {
      this.login();
      return;
    }

    const role = this.authService.getUserRoles();
    switch (role) {
      case 'Artisan':
        this.router.navigate(['/artisan/dashboard']);
        break;
      case 'Customer':
        this.router.navigate(['/customer/dashboard']);
        break;
      case 'DeliveryPartner':
        this.router.navigate(['/partner']);
        break;
      case 'Admin':
        this.router.navigate(['/admin/users']);
        break;
      default:
        // fallback générique
        this.router.navigate(['/']);
        break;
    }
  }

}
