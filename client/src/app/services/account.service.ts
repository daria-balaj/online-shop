import { Injectable } from '@angular/core';
import { User } from '../models/user';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { BehaviorSubject, map, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(private httpClient: HttpClient) { }

  currentUser = new BehaviorSubject<User | null>(null);

  currentUser$ = this.currentUser.asObservable();

  register(newUser: any) {
    return this.httpClient.post<User>(`${environment.apiUrl}/register`, newUser).pipe(
      map(user => {
        console.log(user);
        if (user) {
          this.currentUser.next(user);
          console.log("current user:", this.currentUser);
          localStorage.setItem("token", user.token);
          return true;
        }
        return false;
      })
    )    
  }

  login(email: string, password: string) : Observable<boolean> {
    return this.httpClient.post<string>(`${environment.apiUrl}/login`, { email: email, password: password }).pipe(
      map((response: any) => {
        console.log(response);
        if (response) {
          localStorage.setItem("token", response.token);
          this.currentUser.next(response);
          return true;
        }
        return false;
      } )
    )
  }

  logout() {
    localStorage.removeItem('user');
    this.currentUser.next(null);
  }

  
}
