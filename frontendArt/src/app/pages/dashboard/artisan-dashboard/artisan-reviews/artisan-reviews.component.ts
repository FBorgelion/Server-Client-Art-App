import { Component, OnInit } from '@angular/core';
import { ReviewsService } from '../../../../service/reviews/reviews.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-artisan-reviews',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './artisan-reviews.component.html',
  styleUrl: './artisan-reviews.component.css'
})
export class ArtisanReviewsComponent {

  reviews: any[] = [];
  constructor(private reviewService: ReviewsService) { }
 

  
}
