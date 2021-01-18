import {ProductOption} from '../ProductOption/product-option.model';
import {ProductOptionTariffPrice} from './product-option-tariff-price.model';

export class ProductOptionTariff {
  id: number;
  productOptionId: number;
  productOption: ProductOption;
  name: string;
  prices: ProductOptionTariffPrice[];
}
