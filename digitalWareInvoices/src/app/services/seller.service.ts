import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Seller } from '../interfaces/seller.interface';

@Injectable({
  providedIn: 'root'
})
export class SellerService {
  private base_url : string = environment.base_url;
  constructor(private http:HttpClient) { 
  }
  getSellers(): Observable<Seller[]>{
    return this.http.get<Seller[]>(`${
      this.base_url
    }Saller`);
  }
}
