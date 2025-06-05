import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../service/product.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './products.component.html',
  styleUrl: './products.component.css'
})
export class ProductsComponent implements OnInit {

  products: any;

  constructor(private svc: ProductService) { }

  ngOnInit(): void {
    this.svc.getProducts().subscribe(response => {

      this.products = response;

    });
  }

}
