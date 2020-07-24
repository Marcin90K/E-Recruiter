import { AddressForManipulation } from '../address/address-for-manipulation';
import { PersonBasicDataForManipulation } from '../person-basic-data/person-basic-data-for-manipulation';


export interface CandidateBasicDataForManipulation {
  id: string;
  address: AddressForManipulation;
  personBasicData: PersonBasicDataForManipulation;
}
