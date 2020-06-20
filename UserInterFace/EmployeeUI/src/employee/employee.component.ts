import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {
  employees: any;
  hiringDate:any = "";

  constructor(private httpclient: HttpClient) { }

  ngOnInit(): void {
    this.search();
  }


  search() {
    this.httpclient.get("http://localhost:60338/api/employees?hiringDate=" + this.hiringDate, { 
      headers: new HttpHeaders({ 'Access-Control-Allow-Origin': 'http://localhost:4200', 'Access-Control-Allow-Credentials': 'true' }) })
      .subscribe(res => {
        this.employees = res;
      });
  }
}
