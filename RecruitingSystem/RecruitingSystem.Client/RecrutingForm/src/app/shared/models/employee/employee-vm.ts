import { PersonBasicDataVM } from '../person-basic-data/person-basic-data-vm';

export interface EmployeeVM {
  id: string;
  employeeCompanyId: string;
  personBasicData: PersonBasicDataVM;
}
