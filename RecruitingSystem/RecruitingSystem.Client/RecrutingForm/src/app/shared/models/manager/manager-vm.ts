import { EmployeeVM } from '../employee/employee-vm';
import { Department } from '../department';
import { RecruiterVM } from '../recruiter/recruiter-vm';

export interface ManagerVM {
  id: string;
  employee: EmployeeVM;
  department: Department;
  recruiters: RecruiterVM[];
}
