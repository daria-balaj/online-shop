import { Injectable } from '@angular/core';
import { Product } from '../models/product';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
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
    return this.httpClient.get<Product[]>(`${environment.apiUrl}/products`, this.httpOptions);
  }

  getProductByID(id: number) : Observable<Product> {
    return this.httpClient.get<Product>(`${environment.apiUrl}/products/${id}`, this.httpOptions);
  }

  searchProducts(term: string): Observable<Product[]> {
    const params = new HttpParams().set('q', term);
    return this.httpClient.get<Product[]>(`${environment.apiUrl}/products`, { params });
  }
}
