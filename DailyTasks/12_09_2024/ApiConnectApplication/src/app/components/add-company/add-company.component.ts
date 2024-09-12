import { Component } from '@angular/core';
import { Company } from '../../Modules/Company';
import { ApiService } from '../../service/api.service';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule, NgModel } from '@angular/forms';

// import { Route } from '@angular/router';

@Component({
  selector: 'app-add-company',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './add-company.component.html',
  styleUrl: './add-company.component.css'
})
export class AddCompanyComponent {

  company: Company = {companyId: 0, name: '',Employees:[]};

  constructor(private api: ApiService, private router:Router){}

  onSubmit():void{
    this.api.post(this.company).subscribe((data) => { console.log(data); this.router.navigate(['/'])})

  }


}
