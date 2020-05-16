import { CandidateBasicData } from './candidate-basic-data';
import { CandidateEducation } from './candidate-education';
import { CandidateExperience } from './candidate-experience';
import { JobPosition } from './job-position';
import { JobBasicInfo } from './basic-job-info';

export interface CandidateProfile {
  id: string;
  jobPosition: JobBasicInfo;
  basicInfo: CandidateBasicData;
  educationInfo: CandidateEducation[];
  candidateExperience: CandidateExperience[];
}
