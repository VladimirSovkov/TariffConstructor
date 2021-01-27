import {ProductOption} from '../productOption/product-option.model';

export class IncludedProductOptionInTariff {
  id: number;
  quantity: number;
  tariffId: number;
  productOptionId: number;
  productOption: ProductOption;
}
