import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

import {  IBasketItem } from '../../models/basket';


@Component({
  selector: 'app-basket-summray',
  templateUrl: './basket-summray.component.html',
  styleUrls: ['./basket-summray.component.scss']
})
export class BasketSummrayComponent implements OnInit {
  @Output() decrement : EventEmitter<IBasketItem> = new EventEmitter<IBasketItem>();
  @Output() increment : EventEmitter<IBasketItem> = new EventEmitter<IBasketItem>();
  @Output() remove : EventEmitter<IBasketItem> = new EventEmitter<IBasketItem>();
  @Input() isBasket = true;
  @Input() items:any;
  @Input() isOrder=false;

  constructor() { }

  ngOnInit(){
  }

  decrementItemQuantity(item : IBasketItem){
    this.decrement.emit(item);
  }

  incrementItemQuantity(item : IBasketItem){
    this.increment.emit(item);
  }
  
  removeBasketItem(item : IBasketItem){
    this.remove.emit(item);
  }
}
