import { Component, OnChanges, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductCardComponent } from '../product-card/product-card.component';
import { MatGridListModule } from '@angular/material/grid-list';
import { Product } from '../../models/product';
import { CartService } from '../../services/cart.service';
import { ProductService } from '../../services/product.service';
import { ActivatedRoute } from '@angular/router';

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
export class ProductListComponent implements OnChanges {
  products: Product[] = [];
  @Input('q') searchQuery: string = '';
 
  constructor(private _cartService: CartService, private _productService: ProductService) {}

  ngOnChanges() {
    this._productService.searchProducts(this.searchQuery ?? '').subscribe({
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
