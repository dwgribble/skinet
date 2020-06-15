import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  title = 'Nazca Academy';


  constructor(  // inject http client here

    ) {}

  ngOnInit(): void {
    // call api in here


  }

}
