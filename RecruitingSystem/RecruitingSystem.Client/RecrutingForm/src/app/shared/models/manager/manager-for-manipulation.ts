import { EmployeeForManipulation } from '../employee/employee-for-manipulation';
import { Department } from '../department';
import { RecruiterForManipulation } from '../recruiter/recruiter-for-manipulation';

export interface ManagerForManipulation {
  employee: EmployeeForManipulation;
  department: Department;
  recruiters: RecruiterForManipulation[];
}
