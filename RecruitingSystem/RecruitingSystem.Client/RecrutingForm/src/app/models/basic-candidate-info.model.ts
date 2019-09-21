import { Address } from './address';


export interface CandidateBasicInfo {
  firstName: string;
  lastName: string;
  dateOfBirth: Date;
  address: Address;
  email: string;
  phone: number;
}
