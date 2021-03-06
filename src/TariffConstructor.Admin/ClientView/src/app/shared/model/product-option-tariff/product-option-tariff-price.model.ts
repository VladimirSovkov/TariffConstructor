import {Price} from '../value-object/price.model';
import {ProlongationPeriod} from '../value-object/prolongation-period.model';

export class ProductOptionTariffPrice {
  id: number;
  price: Price;
  period: ProlongationPeriod;
}
