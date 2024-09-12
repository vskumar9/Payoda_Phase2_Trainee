import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Company } from '../Modules/Company';
import { Employee } from '../Modules/Employee';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private API_Company = "https://localhost:7298/api/Company";
  private API_Employee = "https://localhost:7298/api/Employee";

  constructor(private http: HttpClient) { }

  getCompany(): Observable<any> {
    return this.http.get(this.API_Company);
  }

  getById(id: number): Observable<any> {
    return this.http.get(`${this.API_Company}/${id}`);
  }

  post(company: Company): Observable<any> {
    return this.http.post(this.API_Company, company);
  }

  delete(id: number): Observable<any> {
    return this.http.delete(`${this.API_Company}/${id}`);
  }

  update(id:number, company: Company):Observable<any>{
    return this.http.put(`${this.API_Company}/${id}`, company);
  }

  postEmployee(employee: Employee): Observable<any> {
    return this.http.post(this.API_Employee, employee);
  }

  // update(id:number,company: Company): Observable<Company> {
  //   return this.http.put<Company>(`${this.API_URL}/${id}`,company);
  // }
}
