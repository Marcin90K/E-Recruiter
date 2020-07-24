import { CandidateVM } from './candidate-vm';
import { Pagination } from '../pagination';

export interface CandidateListVM {
  candidates: CandidateVM[];
  pagination: Pagination;
}
