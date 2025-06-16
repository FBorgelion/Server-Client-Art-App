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
import { AdminDashboardComponent } from './pages/dashboard/admin-dashboard/admin-dashboard.component';
import { CustomerDashboardComponent } from './pages/dashboard/customer-dashboard/customer-dashboard.component';
import { authGuard } from './guards/auth/auth.guard';
import { roleGuard } from './guards/role/role.guard';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { FinancialReportComponent } from './pages/dashboard/artisan-dashboard/financial-report/financial-report.component';

export const routes: Routes = [
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },

  { path: 'dashboard', component: DashboardComponent, canActivate: [authGuard] },

  { path: "auth/login", component: AuthenticationComponent },

  { path: "auth/register", component: RegisterComponent },

  { path: 'product', component: ProductsComponent },

  { path: 'product/:id', component: ProductDetailComponent },

  { path: 'unauthorized', component: UnauthorizeComponent },

  { path: 'admin/users', component: AdminDashboardComponent, canActivate: [authGuard, roleGuard], data: { roles: ['Admin'] } },

  { path: 'customer/dashboard', component: CustomerDashboardComponent, canActivate: [authGuard, roleGuard], data: { roles: ['Admin', 'Customer'] } },

  {
    path: 'artisan/dashboard', component: ArtisanDashboardComponent, canActivate: [authGuard, roleGuard], data: { roles: ['Artisan', 'Admin'] },
    children: [
      { path: '', redirectTo: 'products', pathMatch: 'full' },
      { path: 'products', component: ArtisanProductsComponent },
      { path: 'products/:id/reviews', component: ArtisanProductDetailComponent },
      { path: 'orders', component: ArtisanOrdersComponent },
      { path: 'inquiries', component: ArtisanInquiriesComponent },
      { path: 'report', component: FinancialReportComponent },
      { path: 'profile', component: ArtisanProfileComponent },
    ]
  },

  {
    path: 'partner', component: DeliveryPartnerDashboardComponent, canActivate: [authGuard, roleGuard], data: { roles: ['DeliveryPartner', 'Admin'] },
    children: [
      { path: '', redirectTo: 'orders', pathMatch: 'full' },
      { path: 'orders', component: DeliveryOrdersComponent },
    ]
  },
];

//canActivate: [authGuard, roleGuard], data: { roles: ['Admin', 'Customer'] }
