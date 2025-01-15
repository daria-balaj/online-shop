import { Component, OnChanges, Input, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductCardComponent } from '../product-card/product-card.component';
import { MatGridListModule } from '@angular/material/grid-list';
import { Product } from '../../models/product';
import { CartService } from '../../services/cart.service';
import { ProductService } from '../../services/product.service';
import { ActivatedRoute } from '@angular/router';
import {MatExpansionModule} from '@angular/material/expansion';
import { MatSelectModule } from '@angular/material/select';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-product-list',
  imports: [
    MatGridListModule,
    ProductCardComponent,
    CommonModule,
    FormsModule,
    MatExpansionModule,
    MatSelectModule,
    MatCheckboxModule,
    MatFormFieldModule
],
  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.css'
})
export class ProductListComponent implements OnChanges {
  products: Product[] = [];
  @Input('q') searchQuery: string = '';
  selectedSortOption: string = '';
  inStockOnly: boolean = false;
 
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

  sortProducts() : void {
    switch(this.selectedSortOption) {
      case "alphabetical":
        this.products.sort((a, b) => {
          return (a.title < b.title) ? - 1 : 1;
        });
        break;
      case "priceAsc":
        this.products.sort((a, b) => {
          return (a.price < b.price) ? -1 : 1
        });
        break;
        case "priceDesc":
          this.products.sort((a, b) => {
            return (a.price > b.price) ? -1 : 1
          });
          break;
    }
  }

}
