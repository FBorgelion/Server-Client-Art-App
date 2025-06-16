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
  selectedFile?: File;

  constructor(private productService : ProductService, private router: Router) {
  
  }

  ngOnInit(): void {
    this.loadProducts();
  }

  loadProducts() {
    this.productService.getArtisanProducts().subscribe(ps => this.products = ps);
  }

  onEditProduct(p: any) {
    this.editingProduct = { ...p };
    this.newProduct = null;
  }

  startAdd() {
    this.newProduct = {
      title: '',
      description: '',
      price: 0,
      stock: 0,
      images: ''   
    };
    this.editingProduct = null;
  }

  saveAdd() {
    if (!this.newProduct) return;
    this.productService
      .addProduct(this.newProduct)
      .subscribe(() => {
        this.loadProducts();
        this.newProduct = null;
      }, err => {
        console.error(err);
        alert('Cannot create product.');
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
        alert(`Cannot delete product. (${err.status} : ${err.statusText})`);
      }
    });
  }

  saveEdit() {
    if (!this.editingProduct) return;
    this.productService
      .updateProduct(this.editingProduct.productId, this.editingProduct)
      .subscribe(() => {
        this.loadProducts();
        this.editingProduct = null;
      }, err => {
        console.error(err);
        alert('Cannot update product.');
      });
  }

  cancelEdit() {
    this.editingProduct = null;
    this.newProduct = null;
  }

  onFileSelected(event: Event) {
    const input = event.target as HTMLInputElement;
    if (input.files && input.files.length > 0) {
      this.selectedFile = input.files[0];
    }
  }

}
