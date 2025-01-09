import { Component, NgModule, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductCardComponent } from '../product-card/product-card.component';
import { MatGridListModule } from '@angular/material/grid-list';
import { Product } from '../models/product';
import { CartService } from '../services/cart.service';
import { Item } from '../models/cart';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-product-list',
  imports: [
    MatGridListModule,
    ProductCardComponent,
    CommonModule
],
  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.css'
})
export class ProductListComponent implements OnInit {
  products: Product[] = [];

  constructor(private _cartService: CartService, private _productService: ProductService) {}

  ngOnInit() {
    this._productService.getProducts().subscribe({
      next: response => this.products = response
    })
  }

  addProductToCart(_product: Product) : void {
    this._cartService.addToCart({
      product: _product,
      quantity: 1
    });
  }

}
