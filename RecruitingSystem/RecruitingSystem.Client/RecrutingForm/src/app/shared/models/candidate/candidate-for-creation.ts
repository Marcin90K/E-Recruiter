import { CandidateBasicDataForManipulation } from '../candidate-basic-data/candidate-basic-data-for-manipulation';
import { EducationForManipulation } from '../education/education-for-manipulation';
import { ExperienceForManipulation } from '../experience/experience-for-manipulation';
import { JobBasicInfo } from '../basic-job-info';

export interface CandidateForCreation {
  //id: string;
  //jobPosition: JobBasicInfo;
  candidateBasicData: CandidateBasicDataForManipulation;
  educations: EducationForManipulation[];
  experiences: ExperienceForManipulation[];
}
