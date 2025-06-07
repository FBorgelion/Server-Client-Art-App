import { Routes } from '@angular/router';
import { AuthenticationComponent } from './pages/authentication/login/authentication.component';
import { ProductsComponent } from './pages/products/products.component';
import { authGuard } from './guards/auth/auth.guard';
import { roleGuard } from './guards/role/role.guard';
import { UnauthorizeComponent } from './pages/authentication/unauthorize/unauthorize.component';
import { RegisterComponent } from './pages/authentication/register/register.component';

export const routes: Routes = [
  { path: "auth/login", component: AuthenticationComponent },
  { path: "auth/register", component: RegisterComponent },
  { path: 'product', component: ProductsComponent, canActivate: [authGuard, roleGuard], data: { roles: ['Admin', 'Customer'] } },
  { path: 'unauthorized', component: UnauthorizeComponent }
];
