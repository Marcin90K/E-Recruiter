import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JobOfferForCreation } from '../models/job-offer/job-offer-for-creation';
import { JobOfferCreated } from '../models/job-offer/job-offer-created';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class JobOfferService {

  private baseUrl: string;
  private section = 'joboffers';
  private searchParam = 'search';
  private pageNumber = 'pageNumber';
  private pageSize = 'pageSize';

  constructor(private http: HttpClient) {
    this.baseUrl = environment.API_URL + this.section;
  }


  addJobOffer(jobOffer: JobOfferForCreation): Observable<JobOfferCreated>  {
    console.log('Job offer for creation ' + JSON.stringify(jobOffer));

    return this.http.post<JobOfferCreated>(this.baseUrl, jobOffer);
  }
}
