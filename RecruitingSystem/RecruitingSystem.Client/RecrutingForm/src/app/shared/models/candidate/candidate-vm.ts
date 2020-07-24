import { CandidateBasicDataVM } from '../candidate-basic-data/candidate-basic-data-vm';
import { EducationVM } from '../education/education-vm';
import { ExperienceVM } from '../experience/experience-vm';

export interface CandidateVM {
  id: string;
  candidateBasicData: CandidateBasicDataVM;
  educations: EducationVM[];
  experiences: ExperienceVM[];
}
