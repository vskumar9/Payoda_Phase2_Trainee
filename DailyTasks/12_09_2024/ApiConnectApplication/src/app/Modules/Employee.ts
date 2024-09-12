import { Company } from "./Company";

export interface Employee
{
    EmployeeId:number;
    Name:string;
    Salary:number;
    JoiningDate:Date;
    CompanyId:number;
    Company:any;
}