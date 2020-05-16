import { Address } from './address';
import { PersonBasicdata } from './person-basic-data';


export interface CandidateBasicData {
  firstName: string;
  lastName: string;
  dateOfBirth: Date;
  address: Address;
  email: string;
  phone: number;
  //personBasicData: PersonBasicdata;
}
