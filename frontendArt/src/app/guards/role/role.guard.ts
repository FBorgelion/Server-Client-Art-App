import { CanActivateFn } from '@angular/router';
import { AuthenticationService } from '../../service/authentication/authentication.service';
import { Router } from '@angular/router';
import { inject } from '@angular/core';

export const roleGuard: CanActivateFn = (route, state) => {
  const authenticationService = inject(AuthenticationService);
  const router = inject(Router);

  const allowedRoles = route.data['roles'] as string[];

  if (!authenticationService.isAuthenticated()) {
    router.navigate(['/auth/login']);
    return false;
  }

  const userRole = authenticationService.getUserRoles();

  if (allowedRoles.includes(userRole)) {
    return true;
  } else {

    router.navigate(['/unauthorized']);
    return false;
  }
};
