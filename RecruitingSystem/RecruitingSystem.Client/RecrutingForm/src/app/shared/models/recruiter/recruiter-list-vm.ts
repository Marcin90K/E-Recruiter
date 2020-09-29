import { Pagination } from './../pagination';
import { RecruiterVM } from './recruiter-vm';

export interface RecruiterListVM {
  recruiters: RecruiterVM[];
  pagination: Pagination;
}
