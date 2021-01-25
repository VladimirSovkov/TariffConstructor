import {TariffAdvancePrice} from './tariff-advance-price.model';
import {IncludedProductInTariff} from './included-product-In-tariff.model';
import {TariffToContractKindBinding} from './tariff-to-contract-kind-binding.model';
import {TariffPrice} from './tariff-price.model';
import {IncludedProductOptionInTariff} from './included-product-option-in-tariff.model';
import { PaymentType } from '../value-object/payment-type.model';
import {TariffTestPeriod} from './tariff-test-period.model';

export class Tariff{
  id: number;
  name: string;
  isArchived: boolean;
  testPeriod: TariffTestPeriod = new TariffTestPeriod();
  accountingName: string;
  paymentType: string;
  awaitingPaymentStrategy: string;
  accountingTariffId: string;
  settingsPresetId: number;
  termsOfUseId: number;
  isAcceptanceRequired: boolean;
  isGradualFinishAvailable: boolean;
  prices: TariffPrice[] = [];
  advancePrices: TariffAdvancePrice[] = [];
  includedProducts: IncludedProductInTariff[] = [];
  includedProductOptions: IncludedProductOptionInTariff[] = [];
  contractKindBindings: TariffToContractKindBinding[] = [];
}

