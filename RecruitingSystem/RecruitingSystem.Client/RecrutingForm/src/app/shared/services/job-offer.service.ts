import { JobOfferUpdated } from './../models/job-offer/job-offer-updated';
import { JobOfferForUpdate } from './../models/job-offer/job-offer-for-update';
import { JobOfferVM } from './../models/job-offer/job-offer-vm';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JobOfferForCreation } from '../models/job-offer/job-offer-for-creation';
import { JobOfferCreated } from '../models/job-offer/job-offer-created';
import { Observable } from 'rxjs';
import { JobOfferListVM } from '../models/job-offer/job-offer-list-vm';

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


  getJobOffer(id: string): Observable<JobOfferVM> {
    const url = this.baseUrl + '/' + id;
    return this.http.get<JobOfferVM>(url);
  }

  getJobOffers(search = '' , pageNumber = 1, pageSize = 10): Observable<JobOfferListVM> {
    const options = {
      params: new HttpParams().set(this.searchParam, search)
                              .set(this.pageNumber, pageNumber.toString())
                              .set(this.pageSize, pageSize.toString())
    };

    return this.http.get<JobOfferListVM>(this.baseUrl, options);
  }

  addJobOffer(jobOffer: JobOfferForCreation): Observable<JobOfferCreated>  {
    console.log('Job offer for creation ' + JSON.stringify(jobOffer));
    return this.http.post<JobOfferCreated>(this.baseUrl, jobOffer);
  }

  updateJobOffer(jobOffer: JobOfferForUpdate): Observable<JobOfferUpdated> {
    console.log('Job offer for update: ' + JSON.stringify(jobOffer));
    return this.http.put<JobOfferUpdated>(this.baseUrl, jobOffer);
  }

  deleteJobOffer(id: string): Observable<{}> {
    const url = this.baseUrl + '/' + id;
    return this.http.delete<{}>(url);
  }
}
