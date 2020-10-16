import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment.prod';

@Component({
  selector: 'app-value',
  templateUrl: './value.component.html',
  styleUrls: ['./value.component.scss']
})
export class ValueComponent implements OnInit {
  values: any;
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getValues();
  }

  getValues() {
    // for a get provide the route to the endpoint
    // this.http.get<IProduct>(this.baseUrl + 'products/' + id);
    this.http.get(this.baseUrl + 'values').subscribe(response => {
      this.values = response;
    }, error => {
      console.log(error);
    });
  }

}
