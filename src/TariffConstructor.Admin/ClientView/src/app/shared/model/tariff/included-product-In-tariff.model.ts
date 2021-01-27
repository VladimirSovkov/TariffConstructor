import {Product} from '../product/product.model';

export class IncludedProductInTariff {
  id: number;
  tariffId: number;
  productId: number;
  product: Product;
  relativeWeight: number;
}
