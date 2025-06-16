import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { ProductService } from '../../../service/product.service';
import { ReviewsService } from '../../../service/reviews/reviews.service';
import { CommonModule, Location } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AuthenticationService } from '../../../service/authentication/authentication.service';
import { InquiryService } from '../../../service/inquiries/inquiry.service';


@Component({
  selector: 'app-product-detail',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './product-detail.component.html',
  styleUrl: './product-detail.component.css'
})
export class ProductDetailComponent implements OnInit {

  productId!: number;
  product?: any;
  reviews: any[] = [];

  newRating = 5;
  newComment = '';

  showInquiryForm = false;
  inquiryMessage = '';

  constructor(
    private route: ActivatedRoute,
    private productService: ProductService,
    private reviewService: ReviewsService,
    private authSvc: AuthenticationService,
    private inquiryService: InquiryService,
    private location: Location  
  ) { }

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.productId = id;
    this.loadProduct();
    this.loadReviews();
  }

  goBack(): void {
    this.location.back();
  }

  loadProduct() {
    this.productService.getProductById(this.productId)
      .subscribe(p => this.product = p);
  }

  loadReviews() {
    this.reviewService.getReviewsByProduct(this.productId)
      .subscribe(r => this.reviews = r);
  }

  get canReview(): boolean {
    return this.authSvc.isAuthenticated() &&
      this.authSvc.getUserRoles().includes('Customer');
  }

  submitReview() {
    if (!this.newComment.trim()) {
      alert('Merci de saisir un commentaire.');
      return;
    }
    const payload = {
      productId: this.productId,
      rating: this.newRating,
      comment: this.newComment.trim()
    };
    this.reviewService.addReview(payload).subscribe({
      next: () => {
        this.newRating = 5;
        this.newComment = '';
        this.loadReviews();
      },
      error: (err: any) => {
        console.error(err);
        alert('Cannot register your review.');
      }
    });
  }

  submitInquiry(): void {
    const msg = this.inquiryMessage.trim();
    if (!msg) return;
    this.inquiryService
      .addInquiry({ productId: this.productId, message: msg })
      .subscribe({
        next: () => {
          alert('Request send to artisan.');
          this.inquiryMessage = '';
          this.showInquiryForm = false;
        },
        error: (err: any) => {
          console.error(err);
          alert('Cannot send your inquiry.');
        }
      });
  }

}
