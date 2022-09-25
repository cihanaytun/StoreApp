import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { BasketService } from 'src/app/basket/basket.service';
import { IBasket, IBasketItem } from '../../models/basket';
import { IOrderItem } from '../../models/order';

@Component({
  selector: 'app-basket-summray',
  templateUrl: './basket-summray.component.html',
  styleUrls: ['./basket-summray.component.scss']
})
export class BasketSummrayComponent implements OnInit {
 // basket$ : Observable<IBasket>;
  @Output() decrement : EventEmitter<IBasketItem> = new EventEmitter<IBasketItem>();
  @Output() increment : EventEmitter<IBasketItem> = new EventEmitter<IBasketItem>();
  @Output() remove : EventEmitter<IBasketItem> = new EventEmitter<IBasketItem>();
  @Input() isBasket = true;
  @Input() items:IBasketItem[] | IOrderItem[]= [];
  @Input() isOrder=false;

  constructor(private basketService: BasketService) { }

  ngOnInit(){
    //this.basket$ = this.basketService.basket$;
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
