import { Client } from "./client.interface";
import { Product } from "./product.interface";
import { Seller } from "./seller.interface";

export interface Invoice{
    IdInvoice? : number;
    Date? : Date;
    Details? : DetailInvoice[];
    Client? : Client;
    Saller? : Seller;
    Total? :number;
}

export interface DetailInvoice{
    IdDetail : number;
    Ammount : number;
    Product: Product;
}