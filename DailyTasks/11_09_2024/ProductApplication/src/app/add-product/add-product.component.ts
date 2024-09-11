import { Component, EventEmitter, Output } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Product } from '../../Product.component';
import { ProductService } from '../product.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-add-product',
  standalone: true,
  imports: [CommonModule, FormsModule,  ReactiveFormsModule],

  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent {
  @Output() productAdded = new EventEmitter<Product>();

  productForm: FormGroup;
  categories = ['Electronics', 'Clothing', 'Groceries', 'Sports', 'Furniture'];

  constructor(private fb: FormBuilder, private productService: ProductService) {
    this.productForm = this.fb.group({
      name: ['', Validators.required],
      description: [''],
      price: [0, [Validators.required, Validators.min(0.01)]],
      inStock: [0, [Validators.required, Validators.min(0)]],
      category: ['', Validators.required],
      tags: [''],
      image: ['']
    });
  }

  onSubmit(): void {
    if (this.productForm.valid) {
      const newProduct: Product = {
        id: Math.random().toString(36).substr(2, 9),
        ...this.productForm.value,
        tags: this.productForm.value.tags ? this.productForm.value.tags.split(',').map((tag: string) => tag.trim()) : [],
        createdAt: new Date(),
        updatedAt: new Date()
      };

      // this.productService.addProduct(newProduct);
      console.log('Product added:', newProduct);
      this.productAdded.emit(newProduct);  
      this.productForm.reset();
    } else {
      console.log('Form is invalid');
    }
  }
}
