import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../../../service/product.service';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-artisan-products',
  standalone: true,
  imports: [CommonModule, RouterModule, FormsModule],
  templateUrl: './artisan-products.component.html',
  styleUrl: './artisan-products.component.css'
})
export class ArtisanProductsComponent implements OnInit {

  products: any;
  editingProduct: any;
  newProduct: any = null;
  constructor(private productService : ProductService, private router: Router) {
  
  }

  ngOnInit(): void {
    this.loadProducts();
  }

  loadProducts() {
    this.productService.getArtisanProducts().subscribe(ps => this.products = ps);
  }

  onEditProduct(p: any) {
    // clone pour ne pas modifier la liste directement
    this.editingProduct = { ...p };
    this.newProduct = null;
  }

  startAdd() {
    this.newProduct = {
      Title: '',
      Description: '',
      Price: 0,
      Stock: 0,
      Images: ''
    };
    this.editingProduct = null;
  }
  saveAdd() {
    this.productService.addProduct(this.newProduct)
      .subscribe(() => {
        this.loadProducts();
        this.newProduct = null;
      });
  }

  onDeleteProduct(id: number) {
    if (!confirm('Do you really want to delete this product ?')) {
      return;
    }
    console.log('[ArtisanProducts] deleting product', id);
    this.productService.deleteProduct(id).subscribe({
      next: () => {
        console.log('[ArtisanProducts] delete successful');
        this.loadProducts();
      },
      error: (err: any) => {
        console.error('[ArtisanProducts] delete failed', err);
        alert(`Impossible de supprimer le produit. (${err.status} : ${err.statusText})`);
      }
    });
  }

  saveEdit() {
    if (!this.editingProduct) return;
    this.productService
      .updateProduct(this.editingProduct.productId, this.editingProduct)
      .subscribe({
        next: () => {
          this.loadProducts();
          this.editingProduct = null;
        },
        error: (err: any) => {
          console.error(err);
          alert('Error while updating');
        }
      });
  }

  cancelEdit() {
    this.editingProduct = null;
  }

}
