import { CandidateBasicInfo } from './basic-candidate-info.model';
import { CandidateEducation } from './candidate-education';
import { CandidateExperience } from './candidate-experience';
import { JobPosition } from './job-position';
import { JobBasicInfo } from './basic-job-info';

export interface CandidateProfile {
  id: string;
  jobPosition: JobBasicInfo;
  basicInfo: CandidateBasicInfo;
  educationInfo: CandidateEducation[];
  candidateExperience: CandidateExperience[];
}
