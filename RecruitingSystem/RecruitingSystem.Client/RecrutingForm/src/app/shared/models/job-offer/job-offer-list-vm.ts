import { JobOfferVM } from './job-offer-vm';
import { Pagination } from '../pagination';

export interface JobOfferListVM {
  jobOffers: JobOfferVM[];
  pagination: Pagination;
}
