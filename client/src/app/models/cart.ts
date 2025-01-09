import { Product } from "./product";

export interface Cart {
    items: Array<Item> 
}

export interface Item {
    product: Product,
    quantity: number
}
