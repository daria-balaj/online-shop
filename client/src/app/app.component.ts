import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginFormComponent } from './login-form/login-form.component';
import { RouterOutlet, RouterLink } from '@angular/router';
import { SignupFormComponent } from "./signup-form/signup-form.component";
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatBadgeModule } from '@angular/material/badge';
import { ProductListComponent } from "./product-list/product-list.component";
import { CartService } from './services/cart.service';
import { Cart, Item } from './models/cart';
import { ProductService } from './services/product.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  imports: [
    CommonModule,
    RouterOutlet,
    RouterLink,
    // LoginFormComponent,
    MatIconModule,
    MatToolbarModule,
    MatBadgeModule,
    // SignupFormComponent,
    // ProductListComponent,
  ],
  providers: [ ProductService, HttpClient ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'client';
  cart: Item[] = [];
  constructor (public _cartService: CartService) {}
  
  ngOnInit() {
    this._cartService.setCartContents();
    this._cartService.cart$.subscribe({
      next: items => this.cart = items
    })
  }
}
