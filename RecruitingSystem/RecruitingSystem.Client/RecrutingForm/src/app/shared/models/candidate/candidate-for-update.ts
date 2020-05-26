import { CandidateBasicDataForManipulation } from '../candidate-basic-data/candidate-basic-data-for-manipulation';
import { EducationForManipulation } from '../education/education-for-manipulation';
import { ExperienceForManipulation } from '../experience/experience-for-manipulation';

export interface CandidateForUpdate {
  id: string;
  candidateBasicData: CandidateBasicDataForManipulation;
  educations: EducationForManipulation[];
  experiences: ExperienceForManipulation[];
}
