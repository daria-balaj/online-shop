import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { ProductListComponent } from './components/product-list/product-list.component';
import { ProductPageComponent } from './components/product-page/product-page.component';
import { SignupFormComponent } from './components/signup-form/signup-form.component';
import { CartComponent } from './components/cart/cart.component';
import { AdminComponent } from './components/admin/admin.component';
import { LoginFormComponent } from './components/login-form/login-form.component';

export const routes: Routes = [
    { path: 'products/all', component: ProductListComponent },
    { path: '', redirectTo: 'products/all', pathMatch: 'full' },
    { path: 'search', component: ProductListComponent},
    { path: 'product-details', component: ProductPageComponent },
    { path: 'cart', component: CartComponent },
    { path: 'signup', component: SignupFormComponent },
    { path: 'login', component: LoginFormComponent },
    { path: 'admin', component: AdminComponent },
    { path: '**', component: ProductListComponent, pathMatch: 'full' },
    // lazy loading a component { path: 'lazy', loadComponent: () => import('./lazy.component').then(c => c.LazyComponent) }
];
