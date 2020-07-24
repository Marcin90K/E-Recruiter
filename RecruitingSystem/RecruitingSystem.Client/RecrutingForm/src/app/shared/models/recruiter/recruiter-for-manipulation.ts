import { JobOfferForCreation } from '../job-offer/job-offer-for-creation';
import { EmployeeForManipulation } from '../employee/employee-for-manipulation';

export interface RecruiterForManipulation {
  ownedJobOffers: JobOfferForCreation[];
  employee: EmployeeForManipulation;
  managerId: string;
}
