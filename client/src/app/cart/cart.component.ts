import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { RouterLink } from '@angular/router';
import { Product } from '../models/product';
import { Cart, Item } from '../models/cart';
import { MatDividerModule } from '@angular/material/divider';
import { CurrencyPipe } from '@angular/common';
import { CartService } from '../services/cart.service';
import { take } from 'rxjs';


@Component({
  selector: 'app-cart',
  imports: [
    CommonModule,
    MatButtonModule,
    MatCardModule,
    MatIconModule,
    MatDividerModule,
    RouterLink
  ],
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.css'
})
export class CartComponent implements OnInit {
  cart: Item[] = [];

  constructor (protected _cartService: CartService) {}
  
  ngOnInit() {
    this._cartService.cart$.subscribe({
      next: items => this.cart = items
    })
    // let cartJSON = localStorage.getItem('cart');
    // if (cartJSON != null) {
    //   this.cart = JSON.parse(cartJSON);
    // }
  }

  onQtyDecrease(id: number) : void {
    this._cartService.updateQty(id, -1);
  }

  onQtyIncrease(id: number) : void {
    this._cartService.updateQty(id, 1);
  }

  onRemove(itemID: number) : void {
    this._cartService.removeFromCart(itemID);
  }

}
