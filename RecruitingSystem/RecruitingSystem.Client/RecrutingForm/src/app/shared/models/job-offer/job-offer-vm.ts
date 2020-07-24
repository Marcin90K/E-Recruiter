import { JobPositionVM } from '../job-position/job-position-vm';
import { RecruiterVM } from '../recruiter/recruiter-vm';

export interface JobOfferVM {
  id: string;
  jobPosition: JobPositionVM;
  description: string;
  dateOfAdding: Date;
  dateOfExpiration: Date;
  requirements: string;
  owner: RecruiterVM;
}
