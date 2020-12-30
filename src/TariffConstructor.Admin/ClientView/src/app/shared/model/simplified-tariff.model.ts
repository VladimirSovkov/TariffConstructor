import {PaymentType} from './value-object/payment-type.model';

export interface SimplifiedTariff{
  id: number;
  tenantId: number;
  name: string;
  paymentType: PaymentType;
}
