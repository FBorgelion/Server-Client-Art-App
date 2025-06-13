import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../../../service/customer/customer.service';
import { PartnerService } from '../../../service/partner/partner.service';
import { ArtisanService } from '../../../service/artisan/artisan.service';
import { ProductService } from '../../../service/product.service';
import { ReviewsService } from '../../../service/reviews/reviews.service';

@Component({
  selector: 'app-admin-dashboard',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './admin-dashboard.component.html',
  styleUrl: './admin-dashboard.component.css'
})
export class AdminDashboardComponent implements OnInit {

  customers: any[] = [];
  partners: any[] = [];
  artisans: any[] = [];
  customerReviews: any[] = [];

  loadingCustomers = false;
  loadingPartners = false;
  loadingArtisans = false;
  loadingReviews = false;

  // contrôle d'affichage
  showCustomers = false;
  showPartners = false;
  showArtisans = false;

  activeSection: 'customers' | 'partners' | 'artisans' = 'customers';

  //selection produit
  selectedArtisanId: number | null = null;
  selectedArtisanName: string | null = null;
  artisanProducts: any[] = [];
  loadingProducts = false;

  selectedCustomerId: number | null = null;
  selectedCustomerName: string | null = null;


  constructor(private custSvc: CustomerService,
              private artSvc: ArtisanService,
              private partnerSvc: PartnerService,
              private productSvc: ProductService,
              private reviewSvc: ReviewsService
  ) {}

  ngOnInit(): void {
    this.loadAll();
  }

  private loadAll() {
    this.loadCustomers();
    this.loadArtisans();
    this.loadPartners();
  }

  loadCustomers() {
    this.loadingCustomers = true;
    this.custSvc.getCustomers().subscribe(list => {
      this.customers = list;
      this.loadingCustomers = false;
    });
  }

  loadPartners() {
    this.loadingPartners = true;
    this.partnerSvc.getPartners().subscribe(list => {
      this.partners = list;
      this.loadingPartners = false;
    });
  }

  loadArtisans() {
    this.loadingArtisans = true;
    this.artSvc.getArtisans().subscribe(list => {
      this.artisans = list;
      this.loadingArtisans = false;
    })
  }

  selectArtisan(artisan: any) {
    this.selectedArtisanName = artisan.username;
    this.loadArtisanProducts(artisan.artisanId);
  }

  loadArtisanProducts(artisanId: number) {
    this.loadingProducts = true;
    this.productSvc.getProductByArtisan(artisanId)
      .subscribe(prods => {
        this.artisanProducts = prods;
        this.loadingProducts = false;
      });
  }

  deleteArtisanProduct(productId: number) {
    if (!confirm('Delete this product ?')) return;
    this.productSvc.deleteProduct(productId)
      .subscribe({
        next: () => {
          this.artisanProducts = this.artisanProducts.filter(p => p.productId !== productId);
        },
        error: () => alert('Delete failed.')
      });
  }

  select(section: 'customers' | 'partners' | 'artisans') {
    this.activeSection = section;
  }

  deleteCustomer(id: number) {
    if (!confirm('Are you sure you want to delete this customer ?')) return;
    this.custSvc.deleteCustomer(id).subscribe({
      next: () => this.customers = this.customers.filter(c => c.customerId !== id)    });
  }

  deletePartner(id: number) {
    if (!confirm('Are you sure you want to delete this partner ?')) return;
    this.partnerSvc.deletePartner(id).subscribe({
      next: () => this.partners = this.partners.filter(p => p.deliveryPartnerId !== id)    });
  }

  deleteArtisan(id: number) {
    if (!confirm('Are you sure you want to delete this artisan ?')) return;
    this.artSvc.deleteArtisan(id).subscribe({
      next: () => this.artisans = this.artisans.filter(a => a.artisanId !== id)    });
  }

  selectCustomer(c: any) {
    this.selectedCustomerId = c.customerId;
    this.selectedCustomerName = c.username;
    this.loadCustomerReviews(c.customerId);
  }

  loadCustomerReviews(id: number) {
    this.loadingReviews = true;
    this.reviewSvc.getReviewsByCustomer(id)
      .subscribe(revs => {
        this.customerReviews = revs;
        this.loadingReviews = false;
      });
  }

  deleteReview(reviewId: number) {
    if (!confirm('Delete this review ?')) return;
    this.reviewSvc.deleteReview(reviewId).subscribe({
      next: () => {
        this.customerReviews = this.customerReviews.filter(r => r.reviewId !== reviewId);
      },
      error: () => alert('Delete failed.')
    });
  }

}
