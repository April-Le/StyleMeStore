export interface IProductResponse {
  productItems: IProductItem[];
}

export interface IProductItem {
  id: number;
  type: string;
  size: number;
  colour: string;
  price: number;
  availableOn: string;
}
