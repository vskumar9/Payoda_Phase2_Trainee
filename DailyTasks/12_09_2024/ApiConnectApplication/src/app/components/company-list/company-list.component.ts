import { Component } from '@angular/core';
import { ApiService } from '../../service/api.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-company-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './company-list.component.html',
  styleUrl: './company-list.component.css'
})
export class CompanyListComponent {

  data:any;

  constructor(private api: ApiService){}

  ngOnInit():void{
    this.api.getCompany().subscribe(data => {this.data = data;});
  }

}
