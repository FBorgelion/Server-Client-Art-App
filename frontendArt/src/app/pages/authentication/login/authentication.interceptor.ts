import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HttpInterceptorFn } from '@angular/common/http';

export const authenticationInterceptor: HttpInterceptorFn = (req, next) => {

  const token = sessionStorage.getItem("jwt");
  const authenticationReq = req.clone({

    setHeaders: {
      Authorization: `Bearer ${token}`
    }

  });

  return next(authenticationReq);

}
