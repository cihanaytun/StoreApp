import { Component, OnInit } from '@angular/core';
import { map, Observable } from 'rxjs';
import { BreadcrumbService } from 'xng-breadcrumb';
import { BusyService } from '../services/busy.service';

@Component({
  selector: 'app-section-header',
  templateUrl: './section-header.component.html',
  styleUrls: ['./section-header.component.scss']
})
export class SectionHeaderComponent implements OnInit {
  breadcrumb$:Observable<any[]>;
  
  constructor(private bcService : BreadcrumbService,private busyService: BusyService) { }

  ngOnInit(){
    this.busyService.busy();
    this.breadcrumb$ = this.bcService.breadcrumbs$;
  }
  ngAfterViewInit(){
  this.busyService.idle();
  }
}
