import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MatTableModule} from '@angular/material/table';
import { ProductService } from '../../services/product.service';
import { Product } from '../../models/product';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-admin',
  imports: [
    MatTableModule,
    CommonModule,
    MatCardModule,
    MatIconModule
  ],
  templateUrl: './admin.component.html',
  styleUrl: './admin.component.css'
})
export class AdminComponent implements OnInit {
  products: Product[] = [];
  columns: string[] = ['id', 'title', 'description', 'price', 'image'];
  constructor(private productService: ProductService) {}

  ngOnInit() {
    this.productService.searchProducts('').subscribe({
      next: list => this.products = list
    });
    console.log(this.products);
  }

  delete(id: number) {
    this.productService.deleteProduct(id).subscribe({});
  }

}
