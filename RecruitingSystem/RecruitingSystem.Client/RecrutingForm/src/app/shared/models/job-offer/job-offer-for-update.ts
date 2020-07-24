import { JobPopsitionForManipulation } from '../job-position/job-position-for-manipulation ';
import { RecruiterForManipulation } from '../recruiter/recruiter-for-manipulation';

export interface JobOfferForUpdate {
  jobPosition: JobPopsitionForManipulation;
  description: string;
  dateOfExpiration: Date;
  requirements: string;
  owner: RecruiterForManipulation;
}
