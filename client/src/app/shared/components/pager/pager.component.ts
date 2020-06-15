import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-pager',
  templateUrl: './pager.component.html',
  styleUrls: ['./pager.component.scss']
})
export class PagerComponent implements OnInit {
  // Input property is something we receive from a parent component
  // Output property is a way for a child component to emit output to parent
  @Input() totalCount: number;
  @Input() pageSize: number;
  @Output() pageChanged = new EventEmitter<number>();

  constructor() { }

  ngOnInit(): void {
  }

  onPagerChange(event: any){
    this.pageChanged.emit(event.page);
  }

}
