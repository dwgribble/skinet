import { Component, OnInit, Input, TemplateRef } from '@angular/core';
import { IProduct } from 'src/app/shared/models/product';
import { BasketService } from 'src/app/basket/basket.service';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';



@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.scss']
})
export class ProductItemComponent implements OnInit {
  @Input() product: IProduct;
  bsModalRef: BsModalRef;

  constructor(private basketService: BasketService, private modalService: BsModalService) { }

  ngOnInit(): void {
  }

  addItemToBasket() {
    console.log(this.product.pictureUrl);
    if (this.product.pictureUrl.includes('codelearner1thumbnail')) {
        window.open('https://nazcastorage.blob.core.windows.net/blob/games/games/CodeLearner_Scene1_S/index.html', '_blank');
    }
    // https://localhost:5001/images/products/codelearner1thumbnail.jpg
    this.basketService.addItemToBasket(this.product);
    // window.open('http://www.google.com', '_blank');
  }

  openModalWithComponent() {
    const initialState = {
      list: this.product.description,
      // title: 'Modal with component'
      title: this.product.name
    };
    this.bsModalRef = this.modalService.show(ModalContentComponent, {initialState});
    this.bsModalRef.content.closeBtnName = 'Close';
  }
}

/* This is a component which we pass in modal*/

@Component({
  selector: 'app-modal-content',
  template: `
    <div class="modal-header">
      <!--<h4 class="modal-title pull-left">{{title}}</h4>-->
      <h4 class="modal-title pull-left">{{title}}</h4>
      <button type="button" class="close pull-right" aria-label="Close" (click)="bsModalRef.hide()">
        <span aria-hidden="true">&times;</span>
      </button>
    </div>
    <div class="modal-body">
      <ul>
        <li>{{list}}</li>
      </ul>
    </div>
    <div class="modal-footer">
      <button type="button" class="btn btn-default" (click)="bsModalRef.hide()">{{closeBtnName}}</button>
    </div>
  `
})

export class ModalContentComponent implements OnInit {
  title: string;
  closeBtnName: string;
  // list: any[] = [];
  list: string;

  constructor(public bsModalRef: BsModalRef) {}

  ngOnInit() {
    // this.list.push('Try an empty string');
    console.log(this.list);
    // this.list.push(product);
  }

}
