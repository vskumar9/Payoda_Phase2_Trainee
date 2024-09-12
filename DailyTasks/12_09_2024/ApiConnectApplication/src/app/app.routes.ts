import { Routes } from '@angular/router';
import { CompanyListComponent } from './components/company-list/company-list.component';
import { CompanyDetailsComponent } from './components/company-details/company-details.component';
import { AddCompanyComponent } from './components/add-company/add-company.component';
import { UpdateCompanyComponent } from './components/update-company/update-company.component';
import { AddEmployeeComponent } from './components/add-employee/add-employee.component';

export const routes: Routes = [
    // { path: '',   redirectTo: '/CompanyList', pathMatch: 'full' },
    { path: '', component: CompanyListComponent },
    { path: 'NewCompany', component: AddCompanyComponent },
    { path: 'CompanyDetails/:id', component: CompanyDetailsComponent },
    { path: 'CompanyUpdate/:id', component: UpdateCompanyComponent },
    { path: 'NewEmployee', component:  AddEmployeeComponent },



];
