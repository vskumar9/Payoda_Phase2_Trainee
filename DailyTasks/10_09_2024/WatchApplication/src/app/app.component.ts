import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'WatchApplication';

  list?: Watch[] = [
    {
      id: 'NWRB3RU',
      brand: 'Tissot',
      name: 'Le Locle Powermatic 80',
      price: 7500,
      rating: 5,
      image: '/public/Le Locle Powermatic 80.jfif',
      stock: 8,
    },
    {
      id: 'NWRB4RU',
      brand: 'Fossil',
      name: 'Grant Chronograph',
      price: 3500,
      rating: 4,
      image: '/public/Grant Chronograph.jfif',
      stock: 5,
    },
    {
      id: 'NWRB5RU',
      brand: 'Skagen',
      name: 'Ancher',
      price: 2800,
      rating: 1,
      image: '/public/SkagenAncher.jfif',
      stock: 2,
    },
    {
      id: 'NWRB6RU',
      brand: 'Citizen',
      name: 'BM8475-03E',
      price: 12000,
      rating: 2,
      image: '/public/BM8475-03E.jfif',
      stock: 4,
    },
    {
      id: 'NWRB7RU',
      brand: 'Seiko',
      name: '5 Sports',
      price: 4500,
      rating: 4,
      image: '/public/Seiko5 Sports.jfif',
      stock: 3,
    },
    {
      id: 'NWRB8RU',
      brand: 'Omega',
      name: 'Seamaster Aqua Terra',
      price: 18000,
      rating: 4,
      image: '/public/Seamaster Aqua Terra.jfif',
      stock: 4,
    },
  ];

  cartItems?: Watch[] = [];
  buyItems?: Watch[] = [];

  addToCart(watch: any): void {
    let val = confirm(`Add ${watch.name} to cart`);
    if (val) {
      console.log(`Added ${watch.name} to cart`);
      console.log(watch);
      this.cartItems?.push(watch);
    }
  }

  buyNow(watch: any): void {
    let val = confirm(`Buying ${watch.name} now`);
    if (val) {
      console.log(`Buying ${watch.name} now`);
      console.log(watch);
      this.buyItems?.push(watch);
    }
  }

  numberVal: number | undefined = 0;
  removeCart(watch: any) {
    let val = confirm(`Remove ${watch.name} from cart`);
    if (val) {
      this.numberVal = this.cartItems!.indexOf(watch);
      if (this.numberVal !== -1) {
        this.cartItems?.splice(this.numberVal, 1);
      } else {
        console.log(`Watch not found in cart`);
      }
      console.log('After:', this.cartItems);
    }
  }

  getRatingColor(rating: number): string {
    if (rating >= 4) {
      return 'green';
    } else if (rating >= 2) {
      return 'orange';
    } else {
      return 'red';
    }
  }

  showCart: boolean = false;
  showOrder: boolean = false;
  toggleCart(){
        this.showCart = !this.showCart;
    }
    toggleOrder(){
        this.showOrder = !this.showOrder;
    }




}

class Watch {
  id?: string;
  brand?: string;
  name?: string;
  price?: number;
  rating?: number;
  image?: string;
  stock: number =0;
}
