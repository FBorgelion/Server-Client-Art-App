import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { ProductService } from '../../../service/product.service';
import { ReviewsService } from '../../../service/reviews/reviews.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-product-detail',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './product-detail.component.html',
  styleUrl: './product-detail.component.css'
})
export class ProductDetailComponent implements OnInit {
  productId!: number;
  product?: any;
  reviews: any[] = [];

  constructor(
    private route: ActivatedRoute,
    private productService: ProductService,
    private reviewService: ReviewsService
  ) { }

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.productId = id;
    this.loadProduct();
    this.loadReviews();
  }

  loadProduct() {
    this.productService.getProductById(this.productId)
      .subscribe(p => this.product = p);
  }

  loadReviews() {
    this.reviewService.getReviewsByProduct(this.productId)
      .subscribe(r => this.reviews = r);
  }
}
