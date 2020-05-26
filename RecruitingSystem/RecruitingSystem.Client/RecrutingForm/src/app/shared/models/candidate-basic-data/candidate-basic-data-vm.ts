import { AddressVM } from '../address/address-vm';
import { PersonBasicDataVM } from '../person-basic-data/person-basic-data-vm';


export interface CandidateBasicDataVM {
  id: string;
  address: AddressVM;
  personBasicData: PersonBasicDataVM;
  candidateId: string;
}
