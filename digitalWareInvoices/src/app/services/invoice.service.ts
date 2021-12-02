import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {Invoice} from '../interfaces/invoice.interface';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InvoiceService {
  private base_url : string = environment.base_url;

  constructor(private http:HttpClient) {
   }

   getInvoices(): Observable<Invoice[]>{
    return this.http.get<Invoice[]>(`${
      this.base_url
    }Invoices`);
  }

  setInvoice(invoice: Invoice):any{
    return this.http.post<Invoice[]>(`${
      this.base_url
    }Invoices`, invoice);
  }
}
