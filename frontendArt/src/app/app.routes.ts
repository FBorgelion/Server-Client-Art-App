import { Routes } from '@angular/router';
import { AuthenticationComponent } from './pages/authentication/login/authentication.component';
import { ProductsComponent } from './pages/products/products.component';

export const routes: Routes = [
  { path: "auth/login", component: AuthenticationComponent },
  { path: "product", component: ProductsComponent }
];
