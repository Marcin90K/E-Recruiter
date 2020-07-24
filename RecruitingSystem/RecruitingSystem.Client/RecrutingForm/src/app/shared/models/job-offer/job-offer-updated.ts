import { JobPositionVM } from '../job-position/job-position-vm';

export interface JobOfferUpdated {
  id: string;
  jobPosition: JobPositionVM;
  description: string;
  dateOfExpiration: Date;
  requirements: string;
  ownerId: string;
}
