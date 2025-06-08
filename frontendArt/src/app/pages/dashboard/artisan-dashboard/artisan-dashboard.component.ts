import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-artisan-dashboard',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './artisan-dashboard.component.html',
  styleUrl: './artisan-dashboard.component.css'
})
export class ArtisanDashboardComponent {

}
