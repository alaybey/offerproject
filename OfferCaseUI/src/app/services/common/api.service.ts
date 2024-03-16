import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environment/environment';
@Injectable({
  providedIn: 'root'
})
export class ApiService {
  BASE_URL: string = environment.apiUrl;
  constructor(private http: HttpClient) { }

  public get(uri: string, params: any): any{
    const queryParams = new HttpParams(params);
    return this.http.get(this.BASE_URL.concat(uri), {params: params})
  }

  public post(uri: string, data: any): any{
    return this.http.post(this.BASE_URL.concat(uri), data)
  }

  public put(uri: string, data: any): any{
    return this.http.put(this.BASE_URL.concat(uri), data)
  }

  public delete(uri: string, params: any): any{
    return this.http.delete(this.BASE_URL.concat(uri), params)
  }
}
