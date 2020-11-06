import { LoginBasic } from './login-basic';

export interface LoginWithEmployee extends LoginBasic {
  isEmployee: boolean;
}
