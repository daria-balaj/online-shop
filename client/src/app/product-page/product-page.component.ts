import { Component, Input } from '@angular/core';
import { Product } from '../models/product';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { CurrencyPipe } from '@angular/common';
import { Router, RouterOutlet, RouterLink, ActivatedRoute, ParamMap } from '@angular/router';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-product-page',
  imports: [
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
  productID: number | undefined;

  constructor(private route: ActivatedRoute, private productService: ProductService) {}

  ngOnInit() {
    this.route.queryParams.subscribe({ next: (params) => {
      this.productID = params['id'];
    }});
    if (this.productID)
    this.productService.getProductByID(this.productID).subscribe(
      p => this.product = p
    );
    console.log(this.productID);
  }

}
