export class Product {
  id?: string;
  name?: string;
  description?: string;
  price?: number;
  inStock: number = 0;
  category?: string;
  tags?: string[];
  createdAt?: Date;
  updatedAt?: Date;
  image?: string;
}

