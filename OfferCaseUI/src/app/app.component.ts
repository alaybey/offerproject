import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, RouterOutlet } from '@angular/router';
import { OfferService } from './services/Offer.service';
import { CommonModule, NgFor } from '@angular/common';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzDividerModule } from 'ng-zorro-antd/divider';
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, NgFor, NzTableModule, NzDividerModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent implements OnInit {
  title = 'OfferCaseUI';

  constructor(
    private offerService: OfferService,
    private router: Router,
    private activateRoute: ActivatedRoute
  ) { }
  offerList: any[] = [];
  pagination: any;

  ngOnInit(): void {
    this.loadData();
  }

  onPageIndexChange($event:any){
    this.router.navigate([],{
      relativeTo:this.activateRoute,
      queryParams: { page: $event},
      queryParamsHandling: "merge"
    })
  }

  loadData(){
    let page: Number = 1;
    let size: Number = 25;
    this.activateRoute.queryParams.subscribe((data: any) =>{
      if(data != null && data.size != null){
        page = data.page;
        size = data.size;
        this.getData(page, size);
      }
    })
  }

  getData(page: Number, size: Number){
    this.offerService.getOffers({ page, size }).subscribe((data: any) => {
      this.offerList = data.result.data;
      this.pagination = {
        pages: data.result.pages,
        current: data.result.current,
        total: data.result.total,
        size,
      };
    });
  }
}
