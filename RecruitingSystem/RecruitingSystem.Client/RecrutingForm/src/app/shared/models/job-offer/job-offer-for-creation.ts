import { JobPopsitionForManipulation } from '../job-position/job-position-for-manipulation ';
import { RecruiterForManipulation } from '../recruiter/recruiter-for-manipulation';

export interface JobOfferForCreation {
  jobPositionId: string;
  description: string;
  dateOfExpiration: Date;
  requirements: string;
  ownerId: string;
}
