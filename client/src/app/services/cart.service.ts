import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, take } from 'rxjs';
import { Cart, Item } from '../models/cart';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  cart$ = new BehaviorSubject<Item[]>([]);

  constructor() { }

  addToCart(item: Item) {
    let items = [ ...this.cart$.value ];
    let existingItem = items.find((_item) => _item.product.id === item.product.id);

    if (existingItem) {
      existingItem.quantity += 1;
    }
    else {
      items.push(item);
    }
    this.cart$.next(items);
    this.updateLocalStorage();
  }

  setCartContents() {
    let cartJSON = localStorage.getItem('cart');
    if (cartJSON != null) {
      this.cart$.next(JSON.parse(cartJSON));
    }
  }

  getCartTotal() : number {
    return this.cart$.value.reduce(
      (sum, item) => sum + ( item.product.price * item.quantity ), 0
    );
  }

  getItemCount() : number {
    return this.cart$.value.map((item) => item.quantity).reduce(
      (prev, current) => prev + current, 0
    );
  }

  
  clearCart() : void {
    this.cart$.next([]);
    this.updateLocalStorage();
  }
  
  updateQty(itemID: number, units: number) {
    let items = [ ...this.cart$.value ];
    let existingItem = items.find((_item) => _item.product.id === itemID);

    if (existingItem) {
      existingItem.quantity += units;
      this.cart$.next(items);
      this.updateLocalStorage();
    }
    
  }
  
  removeFromCart(id: number) {
    console.log(this.cart$.value);
    let items = this.cart$.value.filter((item) => item.product.id != id);
    this.cart$.next(items);
    console.log(items);
    this.updateLocalStorage();
  }
  
  updateLocalStorage() : void {
    localStorage.setItem('cart', JSON.stringify(this.cart$.value));
  }

}
