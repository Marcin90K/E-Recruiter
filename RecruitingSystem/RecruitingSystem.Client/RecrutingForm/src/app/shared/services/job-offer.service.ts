import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class JobOfferService {

  private baseUrl: string;
  private section: 'joboffer';
  private searchParam = 'search';
  private pageNumber = 'pageNumber';
  private pageSize = 'pageSize';

  constructor(private http: HttpClient) {
    this.baseUrl = environment.API_URL + '/' + this.section;
  }


  createJobOffer() {

  }
}
