import { Component } from '@angular/core';
import { ApiService } from '../../service/api.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Company } from '../../Modules/Company';
import { CommonModule } from '@angular/common';
import { error } from 'console';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-company-details',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './company-details.component.html',
  styleUrl: './company-details.component.css'
})
export class CompanyDetailsComponent {
  company:  Company = {companyId :0, name: '', Employees: []};
  constructor(private api:ApiService, private route: ActivatedRoute, private router:Router) {}

  ngOnInit():void{
    const id = +this.route.snapshot.params['id'];
    this.api.getById(id).subscribe((data) => { 
      console.log(data);
      this.company =  data;
      //console.log(this.company)
     },
    (error)=> console.error('Error fetching',error) );
     
  }

  delete(id:number){
    this.api.delete(id).subscribe((data) => {console.log("Deleted."); this.router.navigate(['/'])});
  } 
  update(companyId: number) {
    this.router.navigate(['/CompanyUpdate', companyId]);
  }


}
