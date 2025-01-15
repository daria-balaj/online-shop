import { Component, Input, NgModule } from '@angular/core';
import { Product } from '../../models/product';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { CurrencyPipe } from '@angular/common';
import { Router, RouterOutlet, RouterLink, ActivatedRoute, ParamMap } from '@angular/router';
import { ProductService } from '../../services/product.service';
import { CartService } from '../../services/cart.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-product-page',
  imports: [
    FormsModule,
    RouterLink,
    MatIconModule,
    MatButtonModule,
    CurrencyPipe
  ],
  templateUrl: './product-page.component.html',
  styleUrl: './product-page.component.css'
})

export class ProductPageComponent {
  product: Product = {
    id: 0,
    title: '',
    description: '',
    price: 0,
    image: ''
  };
  quantity: number = 1;
  productID: number | undefined;

  constructor(private route: ActivatedRoute, private productService: ProductService, private cartService: CartService) {}

  ngOnInit() {
    this.route.queryParams.subscribe({ next: (params) => {
      this.productID = params['id'];
    }});
    if (this.productID)
    this.productService.getProductByID(this.productID).subscribe(
      p => this.product = p
    );
  }

  increaseQty(): void {
    this.quantity += 1;
  }

  decreaseQty(): void {
    this.quantity -= 1;
  }

  onAdd() {
    this.cartService.addToCart({ product: this.product, quantity: this.quantity });
  }

}
