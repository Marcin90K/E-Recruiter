import { JobPositionVM } from '../job-position/job-position-vm';

export interface JobOfferCreated {
  id: string;
  jobPosition: JobPositionVM;
  description: string;
  dateOfAdding: Date;
  dateOfExpiration: Date;
  requirements: string;
  ownerId: string;
}
