import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {
  employees: any;
  constructor(private httpclient: HttpClient) { }

  ngOnInit(): void {
    this.httpclient.get("http://localhost:60338/api/employee?hiringDate=2020-06-16", { headers:new HttpHeaders(
      {'Access-Control-Allow-Origin': 'http://localhost:4200', 'Origin':'http://localhost:4200', 'Access-Control-Allow-Credentials': 'true'}) })
    .subscribe(res =>{
      console.log(res)
      this.employees = res
    })
  }

}
