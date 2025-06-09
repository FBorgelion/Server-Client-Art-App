import { Routes } from '@angular/router';
import { AuthenticationComponent } from './pages/authentication/login/authentication.component';
import { ProductsComponent } from './pages/products/products.component';
import { UnauthorizeComponent } from './pages/authentication/unauthorize/unauthorize.component';
import { RegisterComponent } from './pages/authentication/register/register.component';
import { ArtisanDashboardComponent } from './pages/dashboard/artisan-dashboard/artisan-dashboard.component';
import { ArtisanProductsComponent } from './pages/dashboard/artisan-dashboard/artisan-products/artisan-products.component';
import { ArtisanOrdersComponent } from './pages/dashboard/artisan-dashboard/artisan-orders/artisan-orders.component';
import { ArtisanProductDetailComponent } from './pages/dashboard/artisan-dashboard/artisan-product-detail/artisan-product-detail.component';
import { ArtisanProfileComponent } from './pages/dashboard/artisan-dashboard/artisan-profile/artisan-profile.component';
import { ArtisanInquiriesComponent } from './pages/dashboard/artisan-dashboard/artisan-inquiries/artisan-inquiries.component';
import { ProductDetailComponent } from './pages/products/product-detail/product-detail.component';
import { DeliveryOrdersComponent } from './pages/dashboard/delivery-partner-dashboard/delivery-orders/delivery-orders.component';
import { DeliveryPartnerDashboardComponent } from './pages/dashboard/delivery-partner-dashboard/delivery-partner-dashboard.component';

export const routes: Routes = [
  { path: "auth/login", component: AuthenticationComponent },
  { path: "auth/register", component: RegisterComponent },
  { path: 'product', component: ProductsComponent },
  { path: 'unauthorized', component: UnauthorizeComponent },
  {
    path: 'artisan/dashboard', component: ArtisanDashboardComponent,
    children: [
      { path: 'products', component: ArtisanProductsComponent },
      { path: 'products/:id/reviews', component: ArtisanProductDetailComponent },
      { path: 'orders', component: ArtisanOrdersComponent },
      { path: 'inquiries', component: ArtisanInquiriesComponent },
      { path: '', redirectTo: 'products', pathMatch: 'full' },
      { path: 'profile', component: ArtisanProfileComponent
      },
    ]
  },
  { path: 'artisan/dashboard/products', component: ArtisanProductsComponent },
  { path: 'artisan/dashboard/orders', component: ArtisanOrdersComponent },
  { path: 'artisan/dashboard/products/:id/reviews', component: ArtisanProductDetailComponent },
  { path: '', redirectTo: 'auth/login', pathMatch: 'full' },
  { path: 'product/:id', component: ProductDetailComponent },
  {
    path: 'partner', component: DeliveryPartnerDashboardComponent,
    children: [
      { path: 'orders', component: DeliveryOrdersComponent, }
    ]
  },
];

//canActivate: [authGuard, roleGuard], data: { roles: ['Admin', 'Customer'] }
