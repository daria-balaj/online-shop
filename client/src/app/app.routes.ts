import { Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { ProductListComponent } from './product-list/product-list.component';
import { ProductPageComponent } from './product-page/product-page.component';
import { SignupFormComponent } from './signup-form/signup-form.component';
import { CartComponent } from './cart/cart.component';

export const routes: Routes = [
    { path: '', component: ProductListComponent },
    { path: 'product-details', component: ProductPageComponent },
    { path: 'cart', component: CartComponent },
    { path: 'signup', component: SignupFormComponent },
    { path: '**', component: ProductListComponent, pathMatch: 'full' },
    // lazy loading a component { path: 'lazy', loadComponent: () => import('./lazy.component').then(c => c.LazyComponent) }
];
