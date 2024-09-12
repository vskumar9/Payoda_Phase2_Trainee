import { Component } from '@angular/core';
import { Company } from '../../Modules/Company';
import { ApiService } from '../../service/api.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-update-company',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './update-company.component.html',
  styleUrl: './update-company.component.css'
})
export class UpdateCompanyComponent {
  company: Company = { companyId: 0, name: '', Employees : [] };

  constructor(
    private apiService: ApiService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.loadCompany();
  }

  loadCompany(): void {
    const id = +this.route.snapshot.paramMap.get('id')!;
    this.apiService.getById(id).subscribe(
      (company) => this.company = company,
      (error: any) => console.error('Error loading company', error)
    );
  }

  onUpdate(): void {
    const id = this.company.companyId;
    this.apiService.update(id,this.company).subscribe(
      (response) => {
        console.log('Company updated successfully!', response);
        this.router.navigate(['/']);
      },
      (error) => console.error('Error updating company', error)
    );
  }
}