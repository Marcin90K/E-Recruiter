import { JobOfferVM } from '../job-offer/job-offer-vm';
import { EmployeeVM } from '../employee/employee-vm';

export interface RecruiterVM {
  id: string;
  ownedJobOffers: JobOfferVM[];
  employee: EmployeeVM;
  managerId: string;
  fullName: string;
}
