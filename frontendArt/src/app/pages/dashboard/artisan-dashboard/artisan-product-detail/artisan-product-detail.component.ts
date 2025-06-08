import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from '../../../../service/product.service';
import { ReviewsService } from '../../../../service/reviews/reviews.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-artisan-product-detail',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './artisan-product-detail.component.html',
  styleUrl: './artisan-product-detail.component.css'
})
export class ArtisanProductDetailComponent implements OnInit {

  product: any;
  reviews: any;
  loading = true;

  constructor(
    private route: ActivatedRoute,
    private productService: ProductService,
    private reviewService: ReviewsService
  ) { }

  ngOnInit() {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.productService.getProductById(id)
      .subscribe(p => this.product = p);

    this.reviewService.getReviewsByProduct(id)
      .subscribe(r => {
        this.reviews = r;
        this.loading = false;
      });
  }

}
