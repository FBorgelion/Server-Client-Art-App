import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-artisan-dashboard',
  standalone: true,
  imports: [CommonModule, RouterModule, FormsModule],
  templateUrl: './artisan-dashboard.component.html',
  styleUrl: './artisan-dashboard.component.css'
})
export class ArtisanDashboardComponent {

}
