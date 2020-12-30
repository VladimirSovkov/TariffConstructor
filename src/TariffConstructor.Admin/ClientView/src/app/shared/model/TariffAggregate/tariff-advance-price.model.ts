import {Price} from '../value-object/price.model';
import {ProlongationPeriod} from '../value-object/prolongation-period.model';

export interface TariffAdvancePrice {
  id: number;
  price: Price;
  period: ProlongationPeriod;
  tariffId: number;
}
