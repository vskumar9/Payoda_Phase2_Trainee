import { Component, EventEmitter, Output, OnInit, Input } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Product } from '../../Product.component';
import { ProductService } from '../product.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-edit-product',
  standalone: true,
  imports: [CommonModule,  ReactiveFormsModule],
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css']
})
export class EditProductComponent implements OnInit {
  @Input() product?: Product; 
  @Output() productUpdated = new EventEmitter<Product>(); 
  productForm: FormGroup;
  categories = ['Electronics', 'Clothing', 'Groceries', 'Sports', 'Furniture'];

  constructor(
    private fb: FormBuilder,
    private productService: ProductService
  ) {
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

  ngOnInit(): void {
    if (this.product) {
      this.productForm.patchValue(this.product);
    }
  }

  onSubmit(): void {
    if (this.productForm.valid && this.product) {
      const updatedProduct: Product = {
        ...this.productForm.value,
        id: this.product.id,
        tags: this.productForm.value.tags ? this.productForm.value.tags.split(',').map((tag: string) => tag.trim()) : [],
        updatedAt: new Date()
      };

      this.productService.updateProduct(updatedProduct);
      // this.productUpdated.emit(updatedProduct);
    } else {
      console.log('Form is invalid');
    }
  }
}
