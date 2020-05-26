import { CandidateForCreation } from './Candidate/candidate-for-creation';

export interface CandidataDataToBeSent {
  candidateProfile: CandidateForCreation;
  additionalNotes: string;
}
