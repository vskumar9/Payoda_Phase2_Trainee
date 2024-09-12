import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../service/api.service';
import { FormsModule, NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Employee } from '../../Modules/Employee';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-add-employee',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css'],
})
export class AddEmployeeComponent implements OnInit {
  data: any;
  employee: Employee = {
    EmployeeId: 0,
    Name: '',
    Salary: 0,
    JoiningDate: new Date(),
    CompanyId: 0,
    Company: null,
  };

  constructor(private api: ApiService, private router: Router) {}

  ngOnInit(): void {
    // Use ngOnInit
    this.api.getCompany().subscribe((data) => {
      this.data = data;
    });
  }

  onSubmit() {
    this.api.postEmployee(this.employee).subscribe((data) => {
      console.log(data);
      this.router.navigate(['/']);
    });
    console.log('Employee Data:', this.employee);
  }
}
