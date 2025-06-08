import { Routes } from '@angular/router';
import { AuthenticationComponent } from './pages/authentication/login/authentication.component';
import { ProductsComponent } from './pages/products/products.component';
import { authGuard } from './guards/auth/auth.guard';
import { roleGuard } from './guards/role/role.guard';
import { UnauthorizeComponent } from './pages/authentication/unauthorize/unauthorize.component';
import { RegisterComponent } from './pages/authentication/register/register.component';
import { ArtisanDashboardComponent } from './pages/dashboard/artisan-dashboard/artisan-dashboard.component';
import { ArtisanProductsComponent } from './pages/dashboard/artisan-dashboard/artisan-products/artisan-products.component';
import { ArtisanOrdersComponent } from './pages/dashboard/artisan-dashboard/artisan-orders/artisan-orders.component';
import { ArtisanProductDetailComponent } from './pages/dashboard/artisan-dashboard/artisan-product-detail/artisan-product-detail.component';

export const routes: Routes = [
  { path: "auth/login", component: AuthenticationComponent },
  { path: "auth/register", component: RegisterComponent },
  { path: 'product', component: ProductsComponent, canActivate: [authGuard, roleGuard], data: { roles: ['Admin', 'Customer'] } },
  { path: 'unauthorized', component: UnauthorizeComponent },
  { path: '', redirectTo: 'artisan/dashboard', pathMatch: 'full' },
  {
    path: 'artisan/dashboard',
    component: ArtisanDashboardComponent,
    children: [
      { path: 'products', component: ArtisanProductsComponent },
      { path: 'products/:id/reviews', component: ArtisanProductDetailComponent },
      { path: 'orders', component: ArtisanOrdersComponent },
      { path: '', redirectTo: 'products', pathMatch: 'full' }
    ]
  },
  { path: 'artisan/dashboard/products', component: ArtisanProductsComponent },
  { path: 'artisan/dashboard/orders', component: ArtisanOrdersComponent },
  { path: 'artisan/dashboard/products/:id/reviews', component: ArtisanProductDetailComponent },
];
