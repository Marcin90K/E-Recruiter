import { JobPopsitionForManipulation } from '../job-position/job-position-for-manipulation ';
import { RecruiterForManipulation } from '../recruiter/recruiter-for-manipulation';

export interface JobOfferForCreation {
  //jobPosition: JobPopsitionForManipulation;
  jobPositionId: string;
  description: string;
  dateOfExpiration: Date;
  requirements: string;
  //owner: RecruiterForManipulation;
  ownerId: string;
}
