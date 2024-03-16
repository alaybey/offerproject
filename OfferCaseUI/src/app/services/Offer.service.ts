import { Injectable } from '@angular/core';
import { ApiService } from './common/api.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OfferService {

  private URI:string = '/offer';
  constructor(private api:ApiService) { 
  }


  getOffers(page:any): Observable<any>{
    return this.api.get(this.URI, {page: page.page, size:page.size})
  }

}
