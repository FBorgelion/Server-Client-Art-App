import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../service/product.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [CommonModule, RouterModule, FormsModule],
  templateUrl: './products.component.html',
  styleUrl: './products.component.css'
})
export class ProductsComponent implements OnInit {

  products: any;
  loading = true;
  error = '';

  constructor(private svc: ProductService) { }

  ngOnInit(): void {
    this.svc.getProducts().subscribe({
      next: ps => { this.products = ps; this.loading = false; },
      error: err => { this.error = 'Impossible de charger les produits'; this.loading = false; }
    });
  };

}
