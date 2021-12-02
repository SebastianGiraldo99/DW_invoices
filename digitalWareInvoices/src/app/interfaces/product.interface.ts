export interface Product{
    IdProduct : number;
    Name : string;
    Price : number;
    Stock: number;
    Category : Category;
}

export interface Category{
    IdCategory : number;
    Name : string;
    Description : string;
}