import { Injectable } from '@angular/core';
import { Product } from '../models/product';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  // products: Product[] = [];
  constructor(private httpClient: HttpClient) { }

  readonly httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
    })
  };

  getProducts() : Observable<Product[]> {
    return this.httpClient.get<Product[]>("https://localhost:7074/products", this.httpOptions);
  }

  getProductByID(id: number) : Observable<Product> {
    console.log(`${environment.apiUrl}/products/${id}`);
    return this.httpClient.get<Product>(`${environment.apiUrl}/products/${id}`);
  }
}
