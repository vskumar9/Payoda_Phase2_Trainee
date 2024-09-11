import { Routes } from '@angular/router';
import { ProductListComponent } from './product-list/product-list.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { AddProductComponent } from './add-product/add-product.component';
import { EditProductComponent } from './edit-product/edit-product.component';


export const routes: Routes = [
    { path: '',   redirectTo: '/Products', pathMatch: 'full' },
    { path: 'Products', component: ProductListComponent },
    { path: 'AddProduct', component: AddProductComponent },
    { path: 'Edit-product/{id}', component: EditProductComponent },
    { path: '**', component: PageNotFoundComponent },
];
