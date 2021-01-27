import {ContractKind} from '../contract-kind/contract-kind.model';

export interface TariffToContractKindBinding{
  id: number;
  tariffId: number;
  contractKindId: number;
  contractKind: ContractKind;
}
