import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-student-completed',
  templateUrl: './student-completed.component.html',
  styleUrls: ['./student-completed.component.scss']
})
export class StudentCompletedComponent implements OnInit {

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
  }

}
