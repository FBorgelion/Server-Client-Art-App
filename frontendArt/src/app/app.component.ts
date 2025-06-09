import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ProductsComponent } from './pages/products/products.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { AuthenticationComponent } from './pages/authentication/login/authentication.component';
import { RegisterComponent } from './pages/authentication/register/register.component';
import { ArtisanDashboardComponent } from './pages/dashboard/artisan-dashboard/artisan-dashboard.component';
import { ArtisanOrdersComponent } from './pages/dashboard/artisan-dashboard/artisan-orders/artisan-orders.component';
import { ArtisanProductsComponent } from './pages/dashboard/artisan-dashboard/artisan-products/artisan-products.component';
import { ArtisanReviewsComponent } from './pages/dashboard/artisan-dashboard/artisan-reviews/artisan-reviews.component';
import { ArtisanProductDetailComponent } from './pages/dashboard/artisan-dashboard/artisan-product-detail/artisan-product-detail.component';
import { ArtisanProfileComponent } from './pages/dashboard/artisan-dashboard/artisan-profile/artisan-profile.component';
import { DeliveryOrdersComponent } from './pages/dashboard/delivery-partner-dashboard/delivery-orders/delivery-orders.component';
import { DeliveryPartnerDashboardComponent } from './pages/dashboard/delivery-partner-dashboard/delivery-partner-dashboard.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    ProductsComponent,
    DashboardComponent,
    AuthenticationComponent,
    RegisterComponent,
    ArtisanDashboardComponent,
    ArtisanOrdersComponent,
    ArtisanProductsComponent,
    ArtisanReviewsComponent,
    ArtisanProductDetailComponent,
    ArtisanProfileComponent,
    DeliveryPartnerDashboardComponent,
    DeliveryOrdersComponent
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'frontendArt';
}
