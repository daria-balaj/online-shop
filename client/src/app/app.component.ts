import { Component, OnInit, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet, RouterLink, Router } from '@angular/router';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatBadgeModule } from '@angular/material/badge';
import { CartService } from './services/cart.service';
import { Item } from './models/cart';
import { ProductService } from './services/product.service';
import { HttpClient } from '@angular/common/http';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';


@Component({
  selector: 'app-root',
  imports: [
    CommonModule,
    RouterOutlet,
    RouterLink,
    MatIconModule,
    MatToolbarModule,
    MatBadgeModule,
    FormsModule
  ],
  providers: [ ProductService, HttpClient ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'client';
  cart: Item[] = [];

  search: string = '';
  //search = new FormControl('');
  constructor (public _cartService: CartService, private router: Router) {}
  
  ngOnInit() {
    this._cartService.setCartContents();
    this._cartService.cart$.subscribe({
      next: items => this.cart = items
    })
  }

  onSearch() {
    // console.log("search value: ", this.search);
    console.log("onSearch");
    this.router.navigate(["/search"], {
      queryParams: { q: this.search }
    });
  }
}
