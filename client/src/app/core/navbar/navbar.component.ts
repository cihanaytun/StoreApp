import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { BasketService } from 'src/app/basket/basket.service';
import { IBasket } from 'src/app/shared/models/basket';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  title = 'Store-Navbar';
  
  constructor(private basketService : BasketService) {}
  basket$ : Observable<IBasket>;

  ngOnInit(){
    this.basket$ = this.basketService.basket$;
  }

}
