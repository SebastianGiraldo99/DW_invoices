import { Component, OnInit } from '@angular/core';
import { ClientService } from 'src/app/services/client.service';
import { Client } from 'src/app/interfaces/client.interface';
import { Product } from 'src/app/interfaces/product.interface';
import { ProductService } from 'src/app/services/product.service';
import { SellerService } from 'src/app/services/seller.service';
import { Seller } from 'src/app/interfaces/seller.interface';
import { Invoice } from 'src/app/interfaces/invoice.interface';
import { InvoiceService } from 'src/app/services/invoice.service';

@Component({
  selector: 'app-invoice',
  templateUrl: './invoice.component.html',
})
export class InvoiceComponent implements OnInit {
  clients : Client[] = [];
  employee: any;
  positions: any = [];
  states: any = [];
  products : Product[] = [];
  sellers : Seller[] = [];
  invoice : Invoice = {};
  invoices :Invoice[]= [];
  buttonOptions = {
    text: "Submit",
    onClick: "save()",
    }
  constructor(private client_s : ClientService, private product_s : ProductService, private seller_s : SellerService, private invoice_s: InvoiceService) { }

  ngOnInit(): void {

    
    this.getClients();
    this.getProducs();
    this.getSeller();
    this.getInvoices();

  }

  save(e:any){
    this.invoice_s.setInvoice(this.invoice);
  }

  getClients(){
    this.client_s.getClient().subscribe(x => {
      this.clients = x
    });
  }

  getProducs(){
    this.product_s.getProduct().subscribe(x =>{
      this.products = x
    });
  }
  
  getSeller(){
    this.seller_s.getSellers().subscribe(x =>{
      this.sellers = x
    });
  }

  getInvoices(){
    this.invoice_s.getInvoices().subscribe(x=>{
      this.invoices = x
      console.log(this.invoices)
    });

  }
}
