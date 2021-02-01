import {Product} from '../product/product.model';

export class ProductOption
{
  id: number;
  publicId: string;
  nomenclatureId: string;
  name: string;
  productId: number;
  product: Product;
  isMultiple: boolean;
  accountingName: string;
}
