import { Injectable } from '@angular/core';
import { Product } from '../Product.component';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
   private products: Product[] = [
    {
      id: '12345',
      name: 'Sample Product',
      image: '/public/Fitness Bike.jfif',
      price: 29.99,
      inStock: 0,
      createdAt: new Date(),
      updatedAt: new Date(),
      description: 'A great product for everyday use',
      category: 'Electronics',
      tags: ['gadget', 'tech'],
    },
    {
      id: '67890',
      name: 'Smart TV',
      image: '/public/Smart TV.jfif',
      price: 999.99,
      inStock: 4,
      createdAt: new Date('2022-01-01'),
      updatedAt: new Date('2022-01-15'),
      description: 'A high-definition TV for an immersive experience',
      category: 'Electronics',
      tags: ['tv', 'entertainment'],
    },
    {
      id: '11111',
      name: 'Fitness Tracker',
      image: '/public/Fitness Tracker.jfif',
      price: 79.99,
      inStock: 6,
      createdAt: new Date('2020-06-01'),
      updatedAt: new Date('2020-06-15'),
      description: 'A wearable device to track your fitness goals',
      category: 'Sports',
      tags: ['fitness', 'health'],
    },
    {
      id: '22222',
      name: 'Gaming Laptop',
      image: '/public/Gaming Laptop.jfif',
      price: 1499.99,
      inStock: 7,
      createdAt: new Date('2021-11-01'),
      updatedAt: new Date('2021-11-15'),
      description: 'A high-performance laptop for gaming enthusiasts',
      category: 'Electronics',
      tags: ['gaming', 'laptop'],
    },
    {
      id: '33333',
      name: 'Wireless Headphones',
      image: '/public/Wireless Headphones.jfif',
      price: 99.99,
      inStock: 9,
      createdAt: new Date('2020-03-01'),
      updatedAt: new Date('2020-03-15'),
      description: 'A pair of wireless headphones for music lovers',
      category: 'Electronics',
      tags: ['headphones', 'music'],
    },
    {
      id: '44444',
      name: 'Smartwatch',
      image: '/public/Smartwatch.jfif',
      price: 199.99,
      inStock: 1,
      createdAt: new Date('2021-05-01'),
      updatedAt: new Date('2021-05-15'),
      description:
        'A wearable device to track your fitness and receive notifications',
      category: 'Electronics',
      tags: ['smartwatch', 'fitness'],
    },
    {
      id: '55555',
      name: 'Gaming Console',
      image: '/public/Gaming Console.jfif',
      price: 399.99,
      inStock: 6,
      createdAt: new Date('2020-11-01'),
      updatedAt: new Date('2020-11-15'),
      description: 'A gaming console for an immersive gaming experience',
      category: 'Electronics',
      tags: ['gaming', 'console'],
    },
    {
      id: '66666',
      name: 'Fitness Bike',
      image: '/public/Fitness Bike.jfif',
      price: 499.99,
      inStock: 5,
      createdAt: new Date('2021-02-01'),
      updatedAt: new Date('2021-02-15'),
      description: 'A fitness bike for a low-impact workout',
      category: 'Sports',
      tags: ['fitness', 'bike'],
    },
    {
      id: '77777',
      name: 'Virtual Reality Headset',
      image: '/public/Virtual Reality Headset.jfif',
      price: 299.99,
      inStock: 1,
      createdAt: new Date('2020-09-01'),
      updatedAt: new Date('2020-09-15'),
      description: 'A virtual reality headset for an immersive experience',
      category: 'Electronics',
      tags: ['vr', 'gaming'],
    },
    {
      id: '88888',
      name: '/public/Gaming Chair.jfif',
      image: '/public/Fitness Bike.jfif',
      price: 199.99,
      inStock: 2,
      createdAt: new Date('2021-07-01'),
      updatedAt: new Date('2021-07-15'),
      description: 'A gaming chair for comfort and style',
      category: 'Furniture',
      tags: ['gaming', 'chair'],
    },
  ];

  getProducts(): Product[] {
    return this.products;
  }

  addProduct(product: Product): void {
    this.products.push(product);
  }

  getProductById(id: string): Product | undefined {
    return this.products.find(product => product.id === id);
  }

  updateProduct(updatedProduct: Product): void {
    const index = this.products.findIndex(product => product.id === updatedProduct.id);
    if (index !== -1) {
      this.products[index] = updatedProduct;
    }
  }
}
