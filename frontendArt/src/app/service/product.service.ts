import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private svc: HttpClient) { }

  getProducts() {
    return this.svc.get("https://localhost:7041/api/Product");
  }

}
