import { Component, OnInit } from '@angular/core';
import { Product } from '../../Product.component';
import { ProductService } from '../product.service';
import { AddProductComponent } from '../add-product/add-product.component';
import { EditProductComponent } from '../edit-product/edit-product.component';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-product-list',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    AddProductComponent,
    EditProductComponent,
  ],
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css'],
})
export class ProductListComponent implements OnInit {
  categories = ['Electronics', 'Clothing', 'Groceries', 'Sports', 'Furniture'];
  selectedCategory = 'All';
  filteredProducts: Product[] = [];
  selectedProduct?: Product;
  userRole: 'admin' | 'user' = 'user';
  
  CartProducts:Product[] = [];
  BuyProducts:Product[] = [];


  constructor(private productService: ProductService) {}

  ngOnInit(): void {
    this.userRole = 'admin';
    this.filteredProducts = this.productService.getProducts();
  }

  getUserRole(): 'admin' | 'user' {
    return this.userRole;
  }

  logout(): void {
    if (this.userRole === 'user') this.userRole = 'admin';
    else this.userRole = 'user';
  }

  filterByCategory(category: string): void {
    this.selectedCategory = category;
    if (this.selectedCategory === 'All') {
      this.filteredProducts = this.productService.getProducts();
    } else {
      this.filteredProducts = this.productService
        .getProducts()
        .filter((product) => product.category === category);
    }
  }

  get noProducts(): boolean {
    return this.filteredProducts.length === 0;
  }

  addToCart(product: Product): void {
    this.CartProducts.push(product);
    console.log('Added to cart:', product);
  }

  Buy(product: any) {
    this.BuyProducts.push(product);
    console.log('Added to Order:', product);
  }

  numberVal: number | undefined = 0;
  Remove(product: any) {
    let val = confirm(`Remove ${product.name} from cart`);
    if (val) {
      this.numberVal = this.CartProducts!.indexOf(product);
      if (this.numberVal !== -1) {
        this.CartProducts?.splice(this.numberVal, 1);
      } else {
        console.log(`Watch not found in cart`);
      }
      console.log('After:', this.CartProducts);
    }
  }


  onProductAdded(newProduct: Product): void {
    this.productService.addProduct(newProduct);
    this.filterByCategory(this.selectedCategory);
  }

  onEditProduct(product: Product): void {
    this.selectedProduct = product;
  }

  onProductUpdated(updatedProduct: Product): void {
    const index = this.filteredProducts.findIndex(
      (product) => product.id === updatedProduct.id
    );
    if (index > -1) {
      this.filteredProducts[index] = updatedProduct;
    }
    this.selectedProduct = undefined; // Hide the edit form
  }

  isAdmin(): boolean {
    return this.userRole === 'admin';
  }

  isUser(): boolean {
    return this.userRole === 'user';
  }
}
